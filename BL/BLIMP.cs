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
        #region singelton
        static readonly BLIMP instance = new BLIMP();
        static BLIMP() { }
        BLIMP() { }
        public static BLIMP Instance { get => instance; }
        #endregion
       
        
        
        
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
                busDO.BusState = DO.BusStatus.inRefule;
                dal.UpdateBus(busDO);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
        public void ReturnFromRefuel(BO.Bus bus)
        {
            try
            {
                DO.Bus busDO = dal.GetBus(bus.LicenseNumber);
                busDO.BusState = DO.BusStatus.ready;
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
                busDO.BusState = DO.BusStatus.inTreat;
                dal.UpdateBus(busDO);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }

        }
        public void ReturnFromTreat(BO.Bus bus)
        {
            try
            {
                DO.Bus busDO = dal.GetBus(bus.LicenseNumber);
                busDO.BusState = DO.BusStatus.ready;
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
                newBusLine.NumberLastStation = stationsList[stationsList.Count - 1].StationCode;
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
            //get all the lines that pass in thr start station
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
            //get all the lines that pass in thr last station
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
            try
            {
                DO.stationInLine firstStation = dal.GetStationInLine(lineId, startStationCode);
                IEnumerable<DO.stationInLine> stations = dal.GetStationInLineCollectionBy(item => (item.LineId == lineId && item.IndexStationAtLine >= firstStation.IndexStationAtLine));
                if (stations.Count()==0)
                    throw new KeyNotFoundException("לא נמצאה ברשימה " + startStationCode + " תחנה מספר");
                List<DO.stationInLine> stationsList = stations.ToList();
                float sumTime = 0;
                int i = 0;
                while (stationsList[i].StationCode != lastStationCode && i < stationsList.Count - 1)
                {
                    //plus the time of the next station and one minute for the time the bus in the station
                    sumTime += dal.GetFollowingStation(stationsList[i].StationCode, stationsList[i + 1].StationCode).TimeTravelBetweenStations + 1;
                    i++;
                }
                if (i == stationsList.Count - 1&&lastStationCode!= stationsList[i].StationCode)
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


        public BO.LineTiming GetLineTiming(BO.BusLineBL CurrentBusLineBL, BO.BusStation CurrentBusStation)
        {
            try
            {
                TimeSpan timeBetweenStations = TimeSpan.FromMinutes(TimeBetweenStations(CurrentBusLineBL.NumberFirstStation, CurrentBusStation.StationCode, CurrentBusLineBL.BusId));
                //calculate the range time for exit of the bus
                TimeSpan rangeExitBus = TimeSpan.FromSeconds(DateTime.Now.Hour * 60 * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second - timeBetweenStations.Hours * 60 * 60 - timeBetweenStations.Minutes * 60 - timeBetweenStations.Seconds);
                //this predicate return the line trip that according the current time and the line id

                Predicate<DO.LineTrip> condition = x => (x.LineId == CurrentBusLineBL.BusId && (rangeExitBus > x.StartAt && rangeExitBus < x.EndAt));
                DO.LineTrip OurLineTrip = dal.GetLineTripBy(condition);
                if (OurLineTrip == null)
                    return null;
                TimeSpan SoonExitBusTime;
                for (SoonExitBusTime = OurLineTrip.StartAt; SoonExitBusTime < rangeExitBus; SoonExitBusTime += TimeSpan.FromMinutes(OurLineTrip.Frequency))
                {
                }
                //casting for minutes and calculate the time left to wait for the bus to arrive
                TimeSpan totalMinutesForTiming;
                if (SoonExitBusTime < TimeSpan.FromSeconds(DateTime.Now.Hour * 60 * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second))
                {

                    totalMinutesForTiming = TimeSpan.FromSeconds((timeBetweenStations.Hours * 60 * 60 + timeBetweenStations.Minutes *60+ timeBetweenStations.Seconds) +
                   ( SoonExitBusTime.Hours * 60 * 60 + SoonExitBusTime.Minutes*60 + SoonExitBusTime.Seconds)- (DateTime.Now.Hour * 60 * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second));
                }
                else
                {
                    totalMinutesForTiming = TimeSpan.FromSeconds(timeBetweenStations.Hours * 60 * 60 + timeBetweenStations.Minutes*60 + timeBetweenStations.Seconds +
                                 ( SoonExitBusTime.Hours * 60 * 60 +SoonExitBusTime.Minutes*60 + SoonExitBusTime.Seconds- DateTime.Now.Hour * 60 * 60 - DateTime.Now.Minute * 60 - DateTime.Now.Second));
                }
                //Creates a new lineTiming to represent the line schedule in the UI
                BO.LineTiming lineTiming = new BO.LineTiming
                {
                    BusNumLine = OurLineTrip.NumLine,
                    LineId = OurLineTrip.LineId,
                    TripStart = SoonExitBusTime,
                    LastStation = CurrentBusLineBL.LastStation.StationName,
                    Timing = totalMinutesForTiming
                };
                return lineTiming;
            }
            catch(DO.DalEmptyCollectionExeption ex)
            {
                throw new BO.DalEmptyCollectionExeption(ex.Message, ex);
            }

        }
        public IEnumerable<BO.LineTiming> GetLineTimingsAccordingLine(IEnumerable<BO.BusLineBL> busLineBLs, BO.BusStation CurrentBusStation)
        {

            IEnumerable<BO.LineTiming> lineTimings = from item in busLineBLs
                                                     let lineTimingForPresentation = GetLineTiming(item, CurrentBusStation)
                                                     where lineTimingForPresentation != null
                                                     select lineTimingForPresentation;

            return lineTimings;
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
                busBO.LicenseNumber = setLicenseNumberTo(busBO.LicenseNumber);

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
                                                LicenseNumber = setLicenseNumberTo(item.LicenseNumber),
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
        /// <summary>
        /// set the licence number to UI
        /// </summary>
        /// <param name="licenseNumber"></param>
        /// <returns></returns>
        public string setLicenseNumberTo(string licenseNumber)
        {
            string newLicenseNumber="";
            if (licenseNumber.Length == 8)
            {
                for (int i = 0; i < 3; i++)
                    newLicenseNumber += licenseNumber[i];
                newLicenseNumber += '-';
                for (int i = 3; i < 5; i++)
                    newLicenseNumber += licenseNumber[i];
                newLicenseNumber += '-';
                for (int i = 5; i < 8; i++)
                    newLicenseNumber += licenseNumber[i];
            }
            else if (licenseNumber.Length == 7)
            {
                for (int i = 0; i < 2; i++)
                    newLicenseNumber += licenseNumber[i];
                newLicenseNumber += '-';
                for (int i = 2; i < 5; i++)
                    newLicenseNumber += licenseNumber[i];
                newLicenseNumber += '-';
                for (int i = 5; i < 7; i++)
                    newLicenseNumber += licenseNumber[i];
            }
            return newLicenseNumber;
            
        }
        public string setLicenseNumberFrom(string licenseNumber)
        {
            string newLicenseNumber = "";
            if (licenseNumber.Length == 10)
            {
                for (int i = 0; i < 3; i++)
                    newLicenseNumber += licenseNumber[i];
                for (int i = 4; i < 6; i++)
                    newLicenseNumber += licenseNumber[i];
                for (int i = 7; i < 10; i++)
                    newLicenseNumber += licenseNumber[i];
            }
            else if (licenseNumber.Length == 9)
            {
                for (int i = 0; i < 2; i++)
                    newLicenseNumber += licenseNumber[i];
                for (int i = 3; i < 6; i++)
                    newLicenseNumber += licenseNumber[i];
                for (int i = 7; i < 9; i++)
                    newLicenseNumber += licenseNumber[i];
            }
            return newLicenseNumber;
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
            BO.BusStationBL busStationBL = new BO.BusStationBL();
            try
            {
                //copy the basic properties
                
                busStationDO.Clone(busStationBL);
                busStationBL.Location= busStationBL.Latitude + "°N " +busStationBL.Longitude + "°E";
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
                return busStationBL;
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
        public int AddBusLine(BO.BusLineBL busLineBO)
        {
            try
            {
                //add the new busLine to the data
                DO.BusLine busLineDO = new DO.BusLine();
                busLineBO.Clone(busLineDO);
                int newLineID=dal.AddBusLine(busLineDO);

                //busLineDO = dal.GetBusLine();
                //add all the station of the line
                int i = 0;
                IEnumerable<DO.stationInLine> stationsLineDO = from item in busLineBO.CollectionOfStation
                                                               select new DO.stationInLine()
                                                               {
                                                                   LineId = busLineDO.BusId,
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
                for(i=0;i< listStationsLineDO.Count - 1;i++)
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
                return newLineID;

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
      public BO.FollowingStations GetFollowingStations(BO.FollowingStations following)
        {
            try
            {
                DO.FollowingStations followingStationsDO = dal.GetFollowingStation(following.StationCode1, following.StationCode2);
                BO.FollowingStations followingStationsBO = new BO.FollowingStations();
                followingStationsDO.Clone(followingStationsBO);
                return followingStationsBO;
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
            catch (DO.DalAlreayExistFollowingStationsExeption ex)
            {
                throw new BO.DalAlreayExistFollowingStationsExeption(ex.Message, ex);
            }
        }
        //public void DeleteFollowingStations(BO.FollowingStations followingBO)
        //{
        //    DO.FollowingStations followingDO = new DO.FollowingStations();
        //    followingBO.Clone(followingDO);
        //    try
        //    {
        //        dal.DeleteFollowingStations(followingDO);
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        throw new KeyNotFoundException(ex.Message, ex);
        //    }
        //}
        //public void UpdateBusFollowingStations(BO.FollowingStations followingBO)
        //{
        //    DO.FollowingStations followingDO = new DO.FollowingStations();
        //    followingBO.Clone(followingDO);
        //    try
        //    {
        //        dal.UpdateFollowingStations(followingDO);
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        throw new KeyNotFoundException(ex.Message, ex);
        //    }
        //}
        #endregion

        #region method station in line
        //public void UpdateStationInLine(BO.StationInLine stationLineBO)
        // {
        //     DO.stationInLine stationLineDO = new DO.stationInLine();
        //     stationLineBO.Clone(stationLineDO);
        //     try
        //     {
        //         dal.UpdateStationInLine(stationLineDO);
        //     }
        //     catch (KeyNotFoundException ex)
        //     {
        //         throw new KeyNotFoundException(ex.Message, ex);
        //     }
        // }
        public BO.StationInLine getStationInLine(int lineId, int stationCode)
        {

            try
            {
                DO.stationInLine stationInLineDO = dal.GetStationInLine(lineId,stationCode);
                BO.StationInLine stationInLineBO = new BO.StationInLine();
                stationInLineDO.Clone(stationInLineBO);
                return stationInLineBO;

            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
        #endregion
        //add user to the data
        public void addUser(string name, string password, bool isManager)
        {
            DO.User user = new DO.User()
            {
                UserName = name,
                Password = password,
                ManagePermission = isManager,

            };
            try
            {
                dal.AddUser(user);
            }
            catch(DO.DalAlreayExistExeption ex)
            {
                throw new BO.DalAlreayExistExeption(ex.Message, ex);
            }
        }
        //The function returns whether the user is driving or traveling
        public string isAllowEntry(string name, string password)
        {
            try
            {
                DO.User user = dal.GetUser(name,password);
                if (user.ManagePermission)
                    return "MANAGER";
                else
                    return "DRIVER";
            }
            catch(KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
        //add timetable to the data according the frequency
        public void AddLineTrip(BO.Frequency frequency, int lineId, int numLine)
        {
            switch(frequency)
            {
               
                case BO.Frequency.גבוהה:
                    dal.AddLineTrip(new DO.LineTrip
                    {
                        LineId = lineId,
                        NumLine = numLine,
                        StartAt = new TimeSpan(06, 00, 00),
                        EndAt = new TimeSpan(09, 00, 00),
                        Frequency = 5,
                    });
                    dal.AddLineTrip(new DO.LineTrip
                    {
                        LineId = lineId,
                        NumLine = numLine,
                        StartAt = new TimeSpan(09, 00, 00),
                        EndAt = new TimeSpan(13, 00, 00),
                        Frequency = 30,
                    });
                    dal.AddLineTrip(new DO.LineTrip
                    {
                        LineId = lineId,
                        NumLine = numLine,
                        StartAt = new TimeSpan(13, 00, 00),
                        EndAt = new TimeSpan(17, 00, 00),
                        Frequency = 10,
                    });
                    dal.AddLineTrip(new DO.LineTrip
                    {
                        LineId = lineId,
                        NumLine = numLine,
                        StartAt = new TimeSpan(17, 00, 00),
                        EndAt = new TimeSpan(20, 30, 00),
                        Frequency = 15,
                    });
                    dal.AddLineTrip(new DO.LineTrip
                    {
                        LineId = lineId,
                        NumLine = numLine,
                        StartAt = new TimeSpan(20, 31, 00),
                        EndAt = new TimeSpan(00, 30, 00),
                        Frequency = 30,
                    });
                    break;
                case BO.Frequency.בינונית:
                    dal.AddLineTrip(new DO.LineTrip
                    {
                        LineId = lineId,
                        NumLine = numLine,
                        StartAt = new TimeSpan(06, 00, 00),
                        EndAt = new TimeSpan(10, 00, 00),
                        Frequency = 15,
                    });
                    dal.AddLineTrip(new DO.LineTrip
                    {
                        LineId = lineId,
                        NumLine = numLine,
                        StartAt = new TimeSpan(13, 00, 00),
                        EndAt = new TimeSpan(20, 30, 00),
                        Frequency = 30,
                    });
                    dal.AddLineTrip(new DO.LineTrip
                    {
                        LineId = lineId,
                        NumLine = numLine,
                        StartAt = new TimeSpan(20, 31, 00),
                        EndAt = new TimeSpan(00, 31, 00),
                        Frequency = 60,
                    });
                    break;
                case BO.Frequency.נמוכה:
                    dal.AddLineTrip(new DO.LineTrip
                    {
                        LineId = lineId,
                        NumLine = numLine,
                        StartAt = new TimeSpan(06, 00, 00),
                        EndAt = new TimeSpan(10, 00, 00),
                        Frequency = 30,
                    });
                    dal.AddLineTrip(new DO.LineTrip
                    {
                        LineId = lineId,
                        NumLine = numLine,
                        StartAt = new TimeSpan(13, 00, 00),
                        EndAt = new TimeSpan(22, 30, 00),
                        Frequency = 90,
                    });
                    break;
            }
            
        }
    }
}

