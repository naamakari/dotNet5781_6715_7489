using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIDAL;
using APIBL;

namespace BL
{

    public class BLIMP : IBL
    {

        readonly IDAL dal = DalFactory.GetDal();
        /// <summary>
        /// refule the bus
        /// </summary>
        /// <param name="bus"></param>
        public void SendToRefuel(BO.Bus bus)
        {
            try
            {
                DO.Bus busDO = dal.GetBus(bus.LicenseNumber);
                busDO.KmSinceRefeul = (float)0.0;
                dal.UpdateBus(busDO);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
        /// <summary>
        /// treat the bus
        /// </summary>
        /// <param name="bus"></param>
        public void SendToTreat(BO.Bus bus)
        {
            try
            {
                DO.Bus busDO = dal.GetBus(bus.LicenseNumber);
                busDO.KmSinceLastTreat = (float)0.0;
                busDO.DateSinceLastTreat = DateTime.Now;
                dal.UpdateBus(busDO);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }

        }

        /// <summary>
        /// update the "BO.BusLine" if the first station is deleted
        /// </summary>
        /// <param name="code"></param>
        /// <param name="busId"></param>
        public void UpdateFirstStation(int code, int busId)
        {
            //BO.StationInLine stationInLineBO = new BO.StationInLine();
            try
            {
                DO.BusLine newBusLine = dal.GetBusLine(busId);
                IEnumerable<DO.stationInLine> stationsInLine = from item in dal.GetStationInLineCollectionBy(item => item.LineId == busId)
                                                               orderby item.IndexStationAtLine
                                                               select item;
                if (stationsInLine.Count() == 2)
                    throw new BO.invalidRemoveExeption(" קיימות 2 תחנות, לא ניתן למחוק תחנה " + busId + " בקו");
                List<DO.stationInLine> stationsList = stationsInLine.ToList();
               // stationsList[0].Clone(stationInLineBO);
                //DeleteStationInLine(stationInLineBO);//delete
                //ימחק בפונקציה שקראה לו
                stationsList.Remove(stationsList[0]);//now the first station is the next station
                newBusLine.NumberFirstStation = stationsList[0].StationCode;
                dal.UpdateBusLine(newBusLine);
            }
            catch (DO.DalEmptyCollectionExeption ex)
            {
                throw new BO.DalEmptyCollectionExeption("לא קיימות תחנות בקו זה יש למחוק את הקו", ex);
             }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }

        }
        /// <summary>
        /// update the "BO.BusLine" if the last station is deleted
        /// </summary>
        /// <param name="code"></param>
        /// <param name="busId"></param>
        public void UpdateLastStation(int code, int busId)
        {
            try
            {
                DO.BusLine newBusLine = dal.GetBusLine(busId);
                IEnumerable<DO.stationInLine> stationsInLine = from item in dal.GetStationInLineCollectionBy(item => item.LineId == busId)
                                                               orderby item.IndexStationAtLine
                                                               select item;
                if (stationsInLine.Count() == 2)
                    throw new BO.invalidRemoveExeption(" קיימות 2 תחנות, לא ניתן למחוק תחנה " + busId + " בקו");
                List<DO.stationInLine> stationsList = stationsInLine.ToList();
                //dal.DeleteStationInLine(stationsList[stationsList.Count - 1]);//delete the last station
                //ימחק בפונקציה שקראה לו
                stationsList.Remove(stationsList[stationsList.Count - 1]);//now the last station is the previous station
                newBusLine.NumberFirstStation = stationsList[stationsList.Count - 1].StationCode;
                dal.UpdateBusLine(newBusLine);
            }
            catch (DO.DalEmptyCollectionExeption ex)
            {
                throw new BO.DalEmptyCollectionExeption("לא קיימות תחנות בקו זה יש למחוק את הקו", ex);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }

        }

        /// <summary>
        /// return all he lines that have direct path between two stations
        /// </summary>
        /// <param name="startStationCode"></param>
        /// <param name="lastStationCode"></param>
        /// <returns></returns>
        public IEnumerable<BO.BusLineBL> GetPossiblePath(int startStationCode, int lastStationCode)
        {
            IEnumerable<DO.BusLine> LinesInStartStation;
            IEnumerable<DO.BusLine> LinesInLastStation;
            try
            {
                LinesInStartStation = from item in dal.GetStationInLineCollectionBy(item => item.StationCode == startStationCode)
                                                              let busLine = dal.GetBusLine(item.LineId)
                                                              select busLine;
            }
            catch (DO.DalEmptyCollectionExeption ex)
            {
                throw new BO.DalEmptyCollectionExeption(startStationCode+" לא קיימים קווים העוברים בתחנה ", ex);
            }
            try
            {
                LinesInLastStation = from item in dal.GetStationInLineCollectionBy(item => item.StationCode == lastStationCode)
                                                             let busLine = dal.GetBusLine(item.LineId)
                                                             select busLine;
            }
            catch (DO.DalEmptyCollectionExeption ex)
            {
                throw new BO.DalEmptyCollectionExeption(lastStationCode + " לא קיימים קווים העוברים בתחנה ", ex);
            }
            IEnumerable<DO.BusLine> directLinePath = from start in LinesInStartStation
                                                         from last in LinesInLastStation
                                                         where start.BusId == last.BusId
                                                         select start;
            try
            {
                if (directLinePath.Count() == 0)
                    throw new BO.invalidRequestExeption(lastStationCode + ", " + startStationCode + " אין מסלול ישיר בין התחנות");
                IEnumerable<BO.BusLineBL> lines = from item in directLinePath
                                                  select GetBusLineBL(item.BusId);
                return lines;
            }


            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }


        }

        /// <summary>
        /// return the short path between all the lines in the recived collection
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public BO.BusLineBL ReturnShortPath(int startStationCode, int lastStationCode)
        {

            IEnumerable<BO.BusLineBL> lines = GetPossiblePath(startStationCode, lastStationCode);
            float sumTime = 999999999;
            float time;
            BO.BusLineBL line = new BO.BusLineBL();
            foreach (BO.BusLineBL item in lines)
            {
                time = TimeBetweenStations(startStationCode, lastStationCode, item.BusId);
                if (time <= sumTime)
                {
                    sumTime = time;
                    line = item;
                }
            }
            return line;
        }

        /// <summary>
        /// the function get start station and last station and number of line and return the time of distance between them in this line
        /// </summary>
        /// <param name="startStationCode"></param>
        /// <param name="lastStationCode"></param>
        /// <param name="lineId"></param>
        /// <returns></returns>
        public float TimeBetweenStations(int startStationCode, int lastStationCode, int lineId)
        {
            ;
            try
            {
                DO.stationInLine firstStation = dal.GetStationInLine(lineId, startStationCode);
                IEnumerable<DO.stationInLine> stations = dal.GetStationInLineCollectionBy(item => (item.LineId == lineId && item.IndexStationAtLine >= firstStation.IndexStationAtLine));
                if (stations.Count()==0)
                    throw new KeyNotFoundException("לא נמצאה ברשימה " + startStationCode + " תחנה מספר");
                List<DO.stationInLine> stationsList = stations.ToList();
                float sumTime = 0;
                int i = 0;
                while (stationsList[i + 2].StationCode != lastStationCode || i < stationsList.Count - 2)
                {
                    //plus the time of the next station and one minute for the time the bus in the station
                    sumTime += dal.GetFollowingStation(stationsList[i].StationCode, stationsList[i + 1].StationCode).TimeTravelBetweenStations + 1;
                    i++;
                }
                if (i == stationsList.Count - 2)
                    throw new KeyNotFoundException("לא נמצאה ברשימה " + lastStationCode + " תחנה מספר");
                return sumTime;
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
            catch (DO.DalEmptyCollectionExeption ex)
            {
                throw new BO.DalEmptyCollectionExeption(lastStationCode + " לא קיימים קווים העוברים בתחנה ", ex);
            }

        }

        /// <summary>
        /// the function return distance between 2 stations
        /// </summary>
        /// <param name="startStationCode"></param>
        /// <param name="destStationCode"></param>
        /// <returns></returns>
        public float Distance(int startStationCode, int destStationCode)
        {
            DO.BusStation start = dal.GetBusStation(startStationCode);
            DO.BusStation destination = dal.GetBusStation(destStationCode);
            float dis= (float)Math.Sqrt(Math.Pow(start.Latitude - destination.Latitude, 2) + Math.Pow(start.Longitude - destination.Longitude, 2));
            dis = (float)(dis * 1.5);//To be closer to reality
            return dis;
        }

        //נעמה
        #region methods for bus
        public void AddBus(BO.Bus busBO)
        {
            DO.Bus busDO = new DO.Bus();
            busBO.Clone(busDO);
            try
            {
                dal.AddBus(busDO);
            }
            catch (DO.DalAlreayExistExeption ex)
            {
                throw new BO.DalAlreayExistExeption(ex.Message, ex);
            }
        }
        public BO.Bus GetBus(string lisenceNum)
        {
            try
            {
                DO.Bus busDO = dal.GetBus(lisenceNum);
                BO.Bus busBO = new BO.Bus();
                busDO.Clone(busBO);
                return busBO;
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }

        }
        public void DeleteBus(string lisenceNum)
        {
            try
            {
                dal.DeleteBus(lisenceNum);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
        public void UpdateBus(BO.Bus busBO)
        {
            DO.Bus busDO = new DO.Bus();
            busBO.Clone(busDO);
            try
            {
                dal.UpdateBus(busDO);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
        public IEnumerable<BO.Bus> GetAllBuses()
        {
            try
            {
                IEnumerable<BO.Bus> buses = from item in dal.GetBusCollection()
                                            select new BO.Bus()
                                            {
                                                LicenseNumber = item.LicenseNumber,
                                                StartDate=item.StartDate,
                                                Kilometraz=item.Kilometraz,
                                                KmSinceRefeul=item.KmSinceRefeul,
                                                DateSinceLastTreat=item.DateSinceLastTreat,
                                                KmSinceLastTreat=item.KmSinceLastTreat,
                                                BusState=(BO.BusStatus)item.BusState,
                                            };
                return buses;
            }
            catch (DO.DalEmptyCollectionExeption ex)
            {
                throw new BO.DalEmptyCollectionExeption(ex.Message, ex);
            }
        }
        public IEnumerable<BO.Bus> GetAllBusesBy(Predicate<BO.Bus> condition)
        {
                IEnumerable<BO.Bus> buses = from item in GetAllBuses()
                                            where condition(item)
                                            select item;
                return buses;
           
        }
        #endregion

        //רננה
        #region methods for bus-staion
        public void AddBusStation(BO.BusStation busStationBO)
        {
            DO.BusStation busStationDO = new DO.BusStation();
            busStationBO.Clone(busStationDO);
            try
            {
                dal.AddBusStation(busStationDO);
            }
            catch (DO.DalAlreayExistExeption ex)
            {
                throw new BO.DalAlreayExistExeption(ex.Message, ex);
            }
        }
        public void DeleteBusStation(int code)
        {
            BO.StationInLine stationInLineBO = new BO.StationInLine();
            try
            { 
                List<DO.stationInLine>stationInLinesDAL = dal.GetStationInLineCollectionBy(item => item.StationCode == code).ToList();

                foreach (DO.stationInLine item in stationInLinesDAL)
                {
                    item.Clone(stationInLineBO);
                    //if (item.IsFirstStation)
                    //    UpdateFirstStation(code, item.LineId);
                    //else if (item.IsLastStation)
                    //    UpdateLastStation(code, item.LineId);
                    //else
                    //יירקתי כי בפונקציה שעכשיו שולחים אליה היא שולחת לעדכון
                    DeleteStationInLine(stationInLineBO);
                }
                dal.DeleteBusStation(code);
            }
            catch (KeyNotFoundException exc)
            {
                throw new KeyNotFoundException(exc.Message, exc);
            }
            catch (DO.DalEmptyCollectionExeption ex)
            {
                throw new BO.DalEmptyCollectionExeption("לא קיימים קווים העוברים בתחנה זו", ex);
            }
        }
        public void UpdateBusStation(BO.BusStation busStation)
        {
            try
            {
                DO.BusStation busStationDAL = new DO.BusStation();
                busStation.Clone(busStationDAL);
                dal.UpdateBusStation(busStationDAL);
            }
            catch (KeyNotFoundException exc)
            {
                throw new KeyNotFoundException(exc.Message, exc);
            }
        }
        public BO.BusStationBL ToBusStationBL(DO.BusStation busStationDO)

        {
            try
            {
                //copy the basic properties
                BO.BusStationBL busStationBL = new BO.BusStationBL();
                busStationDO.Clone(busStationBL);
                IEnumerable<DO.stationInLine> stationInLinesDAL = dal.GetStationInLineCollectionBy(item => item.StationCode == busStationDO.StationCode);
                
                //creat list of lines that arrive to this station
                busStationBL.CollectionBusLines = from item in stationInLinesDAL
                                                  let busLine = dal.GetBusLine(item.LineId)
                                                  select new BO.BusLine()
                                                  {
                                                      BusId = busLine.BusId,
                                                      BusNumLine = busLine.BusNumLine,
                                                      AreaAtLand = (BO.Area)busLine.AreaAtLand,
                                                      NumberFirstStation = busLine.NumberFirstStation,
                                                      NumberLastStation = busLine.NumberLastStation
                                                  };
                return busStationBL;
            }
            catch (KeyNotFoundException exc)
            {
                throw new KeyNotFoundException(exc.Message, exc);
            }
            catch (DO.DalEmptyCollectionExeption ex)
            {
                throw new BO.DalEmptyCollectionExeption("לא קיימים קווים העוברים בתחנה זו", ex);
            }

        }
        public BO.BusStationBL GetBusStationBL(int stationID)
        {
            
            try
            {
                DO.BusStation busStationDO = dal.GetBusStation(stationID);
                return ToBusStationBL(busStationDO);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
        public IEnumerable<BO.BusStationBL> GetAllStations()
        {
            IEnumerable<BO.BusStationBL> busStationBLs = from item in dal.GetBusStationCollection()
                                                         select ToBusStationBL(item);
            return busStationBLs;
        }
        public IEnumerable<BO.BusStationBL> GetAllStationsBy(Predicate<BO.BusStationBL> condition)
        {
            IEnumerable<BO.BusStationBL> busStationBLs = from item in GetAllStations()
                                                         where condition(item)
                                                         select item;
            return busStationBLs;
        }
        #endregion

        //נעמה
        #region method for bus-line
        public void AddBusLine(BO.BusLineBL busLineBO)
        {
            try
            {
                //add the new busLine to the data
                DO.BusLine busLineDO = new DO.BusLine();
                busLineBO.Clone(busLineDO);
                dal.AddBusLine(busLineDO);

                //add all the station of the line
                int i = 0;
                IEnumerable<DO.stationInLine> stationsLineDO = from item in busLineBO.CollectionOfStation
                                                               select new DO.stationInLine()
                                                               {
                                                                   LineId = busLineBO.BusId,
                                                                   StationCode = item.StationCode,
                                                                   IndexStationAtLine = i++,
                                                                   IsDeleted = false,
                                                                   IsFirstStation = false,
                                                                   IsLastStation = false,
                                                               };
                

                List<DO.stationInLine> listStationsLineDO = stationsLineDO.ToList();
                listStationsLineDO[0].IsFirstStation = true;
                listStationsLineDO[listStationsLineDO.Count - 1].IsLastStation = true;
                foreach (var item in listStationsLineDO)
                    dal.AddStationInLine(item);

                //add to the data following stations
                for(i=0;i< listStationsLineDO.Count - 2;i++)
                {
                    float dis= Distance(listStationsLineDO[i].StationCode, listStationsLineDO[i + 1].StationCode);
                    dal.AddFollowingStations(new DO.FollowingStations()
                    {
                        StationCode1 = listStationsLineDO[i].StationCode,
                        StationCode2 = listStationsLineDO[i+1].StationCode,
                        DistanceBetweenStations=dis,
                        TimeTravelBetweenStations=dis,
                    });
                }

            }
            catch (DO.DalAlreayExistExeption ex)
            {
                throw new BO.DalAlreayExistExeption(ex.Message, ex);
            }
            
            
          
        }
        public void DeleteBusLine(BO.BusLineBL busLineBO)
        {
            try
            {
                //Delete all stations through which the line passes
                foreach(var item in busLineBO.CollectionOfStation)
                {
                    dal.DeleteStationInLine(dal.GetStationInLine(busLineBO.BusId, item.StationCode));
                }
                //delete the bus
                dal.DeleteBusLine(busLineBO.BusId);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
            catch (DO.DalEmptyCollectionExeption ex)
            {
                throw new BO.DalEmptyCollectionExeption(  "לא קיימות תחנות עבור קו זה ", ex);
            }

        }
        public void UpdateBusLine(BO.BusLine busLineBO)
        {
            try
            {
                DO.BusLine busLineDO = new DO.BusLine();
                busLineBO.Clone(busLineDO);
                dal.UpdateBusLine(busLineDO);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
        public BO.BusLineBL ToBusLineBL(DO.BusLine busLineDO)
        {
            try
            {
                //insert the basic property
                BO.BusLineBL busLineBL = new BO.BusLineBL();
                busLineDO.Clone(busLineBL);

                //insert the busStation
                BO.BusStation busStationBO1 = new BO.BusStation();
                BO.BusStation busStationBO2 = new BO.BusStation();
                DO.BusStation busStationDO1 = dal.GetBusStation(busLineBL.NumberFirstStation);
                DO.BusStation busStationDO2 = dal.GetBusStation(busLineBL.NumberLastStation);
                busStationDO1.Clone(busStationBO1);
                busStationDO2.Clone(busStationBO2);
                busLineBL.FirstStation = busStationBO1;
                busLineBL.LastStation = busStationBO2;

                //creates a list of the stations that the line passes through in order
                BO.StationInLine stationInLineBO = new BO.StationInLine();
                IEnumerable<DO.stationInLine> stationsDO = dal.GetStationInLineCollectionBy(item => item.LineId == busLineBL.BusId);
                busLineBL.CollectionOfStation = from item in stationsDO
                                                let busStation = dal.GetBusStation(item.StationCode)
                                                orderby item.IndexStationAtLine
                                                select new BO.BusStation()
                                                {
                                                    StationCode = busStation.StationCode,
                                                    Longitude = busStation.Longitude,
                                                    Latitude = busStation.Latitude,
                                                    Address = busStation.Address,
                                                    StationName = busStation.StationName
                                                };
                return busLineBL;
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
            catch (DO.DalEmptyCollectionExeption ex)
            {
                throw new BO.DalEmptyCollectionExeption("לא קיימות תחנות עבור קו זה ", ex);
            }
        }
        public void AddStationToBus(BO.StationInLine stationLineBO)
        {
            DO.stationInLine stationLineDO = new DO.stationInLine();
            stationLineBO.Clone(stationLineDO);
            try
            {
                //update the index of the other station of line
                IEnumerable<DO.stationInLine> stationsLine = from item in dal.GetStationInLineCollectionBy(item => item.LineId == stationLineBO.LineId)
                                                             where item.IndexStationAtLine >= stationLineBO.IndexStationAtLine
                                                             select item;
                List<DO.stationInLine> stationInLines= stationsLine.ToList();
                foreach(var item in stationInLines)
                {
                    item.IndexStationAtLine++;
                    dal.UpdateStationInLine(item);
                }

                dal.AddStationInLine(stationLineDO);
                //update the line if the station is first or last
                if (stationLineDO.IsFirstStation)
                {
                    DO.BusLine busLineDO = dal.GetBusLine(stationLineDO.LineId);
                    busLineDO.NumberFirstStation = stationLineDO.StationCode;
                    dal.UpdateBusLine(busLineDO);
                }
                if (stationLineDO.IsLastStation)
                {
                    DO.BusLine busLineDO = dal.GetBusLine(stationLineDO.LineId);
                    busLineDO.NumberLastStation = stationLineDO.StationCode;
                    dal.UpdateBusLine(busLineDO);
                }

            }
            catch (DO.DalAlreayExistExeption ex)
            {
                throw new BO.DalAlreayExistExeption(ex.Message, ex);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
        //רננה
        public void DeleteStationInLine(BO.StationInLine stationLineBO)
        {
            DO.stationInLine stationLineDO = new DO.stationInLine();
            stationLineBO.Clone(stationLineDO);
            try
            {
                Predicate<DO.stationInLine> predicate = item => item.LineId == stationLineBO.LineId;
                IEnumerable<DO.stationInLine> stationsOfLine = from item in dal.GetStationInLineCollectionBy(predicate)
                                                        where (item.IndexStationAtLine > stationLineBO.IndexStationAtLine)
                                                        select item;
                List<DO.stationInLine> listStation = stationsOfLine.ToList();
                for(int i=0;i<listStation.Count()-1; i++)
                {
                    listStation[i].IndexStationAtLine--;
                    dal.UpdateStationInLine(listStation[i]);
                }

                if (stationLineBO.IsFirstStation)
                    UpdateFirstStation(stationLineBO.StationCode, stationLineBO.LineId);
                else
                if (stationLineBO.IsLastStation)
                    UpdateLastStation(stationLineBO.StationCode, stationLineBO.LineId);
               
               dal.DeleteStationInLine(stationLineDO);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
        //נעמה
        public BO.BusLineBL GetBusLineBL(int busID)
        {
            try
            {
                DO.BusLine busLineDO = dal.GetBusLine(busID);
                return ToBusLineBL(busLineDO);
            }
            catch(KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
        public IEnumerable<BO.BusLineBL> GetAllLines()
        {
            IEnumerable<BO.BusLineBL> busLineBLs = from item in dal.GetBusLineCollection()
                                                   select ToBusLineBL(item);
            return busLineBLs;
        }
        public IEnumerable<BO.BusLineBL> GetAllLinesBy(Predicate<BO.BusLine> condition)
        {
            IEnumerable<BO.BusLineBL> busLineBLs = from item in GetAllLines()
                                                   where condition(item)
                                                   select  (item);
            return busLineBLs;
        }

        #endregion
        //רננה
        #region method for followingStations
        public void AddFollowingStations(BO.FollowingStations followingBO)
        {
            DO.FollowingStations followingDO = new DO.FollowingStations();
            followingBO.Clone(followingDO);
            try
            {
                dal.AddFollowingStations(followingDO);
            }
            catch (DO.DalAlreayExistExeption ex)
            {
                //throw new BO.DalAlreayExistExeption(ex.Message, ex);
            }
        }
        public void DeleteFollowingStations(BO.FollowingStations followingBO)
        {
            DO.FollowingStations followingDO = new DO.FollowingStations();
            followingBO.Clone(followingDO);
            try
            {
                dal.DeleteFollowingStations(followingDO);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
        public void UpdateBusFollowingStations(BO.FollowingStations followingBO)
        {
            DO.FollowingStations followingDO = new DO.FollowingStations();
            followingBO.Clone(followingDO);
            try
            {
                dal.UpdateFollowingStations(followingDO);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
        #endregion

        #region method station in line
       public void UpdateStationInLine(BO.StationInLine stationLineBO)
        {
            DO.stationInLine stationLineDO = new DO.stationInLine();
            stationLineBO.Clone(stationLineDO);
            try
            {
                dal.UpdateStationInLine(stationLineDO);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
        #endregion
    }
}

