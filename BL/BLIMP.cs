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

        readonly IDAL dal = DLFactory.GetDL();
        /// <summary>
        /// refule the bus
        /// </summary>
        /// <param name="bus"></param>
        public void sendToRefuel(BO.Bus bus)
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
        public void sendToTreat(BO.Bus bus)
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
        /// update the "BO.BusLine" if the furs station is deleted
        /// </summary>
        /// <param name="code"></param>
        /// <param name="busId"></param>
        public void updateFirstStation(int code, int busId)
        {
            DO.BusLine newBusLine = dal.GetBusLine(busId);
            IEnumerable<DO.stationInLine> stationsInLine = from item in dal.GetStationInLineCollectionBy(item => item.LineId == busId)
                                                           orderby item.IndexStationAtLine
                                                           select item;
            if (stationsInLine.Count() == 2)
                throw new BO.invalidRemoveExeption(" קיימות 2 תחנות, לא ניתן למחוק תחנה " + busId + " בקו");
            List<DO.stationInLine> stationsList = stationsInLine.ToList();
            dal.DeleteStationInLine(stationsList[0]);//delete
            stationsList.Remove(stationsList[0]);//now the first station is the next station
            newBusLine.NumberFirstStation = stationsList[0].StationCode;
            dal.UpdateBusLine(newBusLine);
        }
        /// <summary>
        /// update the "BO.BusLine" if the last station is deleted
        /// </summary>
        /// <param name="code"></param>
        /// <param name="busId"></param>
        public void updateLastStation(int code, int busId)
        {
            DO.BusLine newBusLine = dal.GetBusLine(busId);
            IEnumerable<DO.stationInLine> stationsInLine = from item in dal.GetStationInLineCollectionBy(item => item.LineId == busId)
                                                           orderby item.IndexStationAtLine
                                                           select item;
            if (stationsInLine.Count() == 2)
                throw new BO.invalidRemoveExeption(" קיימות 2 תחנות, לא ניתן למחוק תחנה " + busId + " בקו");
            List<DO.stationInLine> stationsList = stationsInLine.ToList();
            dal.DeleteStationInLine(stationsList[stationsList.Count - 1]);//delete the last station
            stationsList.Remove(stationsList[stationsList.Count - 1]);//now the last station is the previous station
            newBusLine.NumberFirstStation = stationsList[stationsList.Count - 1].StationCode;
            dal.UpdateBusLine(newBusLine);
        }

        /// <summary>
        /// return all he lines that have direct path between two stations
        /// </summary>
        /// <param name="startStationCode"></param>
        /// <param name="lastStationCode"></param>
        /// <returns></returns>
        public IEnumerable<BO.BusLineBL> getPossiblePath(int startStationCode, int lastStationCode)
        {
            IEnumerable<DO.BusLine> LinesInStartStation = from item in dal.GetStationInLineCollectionBy(item => item.StationCode == startStationCode)
                                                          let busLine = dal.GetBusLine(item.LineId)
                                                          select busLine;
            IEnumerable<DO.BusLine> LinesInLastStation = from item in dal.GetStationInLineCollectionBy(item => item.StationCode == lastStationCode)
                                                         let busLine = dal.GetBusLine(item.LineId)
                                                         select busLine;
            IEnumerable<DO.BusLine> directLinePath = from start in LinesInStartStation
                                                     from last in LinesInLastStation
                                                     where start.BusId == last.BusId
                                                     select start;
            if (directLinePath.Count() == 0)
                throw new BO.invalidRequestExeption(lastStationCode + ", " + startStationCode + " אין מסלול ישיר בין התחנות");
            IEnumerable<BO.BusLineBL> lines = from item in directLinePath
                                              select GetBusLineBL(item.BusId);
            return lines;


        }

        /// <summary>
        /// return the short path between all the lines in the recived collection
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public BO.BusLineBL returnShortPath(int startStationCode, int lastStationCode)
        {
            IEnumerable<BO.BusLineBL> lines = getPossiblePath(startStationCode, lastStationCode);
            float sumTime = 999999999;
            float time;
            BO.BusLineBL line = new BO.BusLineBL();
            foreach (BO.BusLineBL item in lines)
            {
                time = timeBetweenStations(startStationCode, lastStationCode, item.BusId);
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
        public float timeBetweenStations(int startStationCode, int lastStationCode, int lineId)
        {
            IEnumerable<DO.stationInLine> stations = dal.GetStationInLineCollectionBy(item => item.LineId == lineId);
            List<DO.stationInLine> stationsList = stations.ToList();
            float sumTime = 0;
            int i = 0;
            while (stationsList[0].StationCode != startStationCode)
                stationsList.Remove(stationsList[0]);
            if (stationsList.Count == 0)
                throw new KeyNotFoundException("לא נמצאה ברשימה " + startStationCode + " תחנה מספר");
            while (stationsList[i + 2].StationCode != lastStationCode || i < stationsList.Count - 2)
            {
                //plus the time of the next station and one minute for the time the bus in the station
                sumTime += dal.GetFollowingStation(stationsList[i].StationCode, stationsList[i + 1].StationCode).TimeTravelBetweenStations + 1;
            }
            if (i == stationsList.Count - 2)
                throw new KeyNotFoundException("לא נמצאה ברשימה " + lastStationCode + " תחנה מספר");
            return sumTime;

        }

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
        #endregion

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
            try
            {

                Predicate<DO.stationInLine> predicate = item => item.StationCode == code;
                IEnumerable<DO.stationInLine> stationInLinesDAL = dal.GetStationInLineCollectionBy(predicate);
                foreach (DO.stationInLine item in stationInLinesDAL)
                {
                    if (item.IsFirstStation)
                        updateFirstStation(code, item.LineId);
                    else if (item.IsLastStation)
                        updateLastStation(code, item.LineId);
                    else
                        dal.DeleteStationInLine(item);
                }
                dal.DeleteBusStation(code);
            }
            catch (KeyNotFoundException exc)
            {
                throw new KeyNotFoundException(exc.Message, exc);
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
        public BO.BusStationBL GetBusStationBL(int code)

        {
            try
            {
                DO.BusStation busStationDAL = dal.GetBusStation(code);
                BO.BusStationBL busStationBL = new BO.BusStationBL();
                busStationDAL.Clone(busStationBL);
                Predicate<DO.stationInLine> predicate = item => item.StationCode == code;
                IEnumerable<DO.stationInLine> stationInLinesDAL = dal.GetStationInLineCollectionBy(predicate);
                BO.BusLine busLineBL = new BO.BusLine();
                busStationBL.CollectionBusLines = from item in stationInLinesDAL
                                                  let busLine = dal.GetBusLine(item.LineId)
                                                  select new BO.BusLine()
                                                  {
                                                      BusId = busLine.BusId,
                                                      BusNumLine = busLine.BusNumLine,
                                                      AreaAtLand = (BO.Area)busLine.AreaAtLand,
                                                      FirstStationCode = busLine.NumberFirstStation,
                                                      LastStationCode = busLine.NumberLastStation
                                                  };
                return busStationBL;
            }
            catch (KeyNotFoundException exc)
            {
                throw new KeyNotFoundException(exc.Message, exc);
            }
            catch (DO.DalEmptyCollectionExeption ex)
            {
                throw new BO.DalEmptyCollectionExeption(ex.Message, ex);
            }
        }
        #endregion

        #region method for bus-line
        public void AddBusLine(BO.BusLine busLineBO)
        {
            DO.BusLine busLineDO = new DO.BusLine();
            busLineBO.Clone(busLineDO);
            try
            {
                dal.AddBusLine(busLineDO);
            }
            catch (DO.DalAlreayExistExeption ex)
            {
                throw new BO.DalAlreayExistExeption(ex.Message, ex);
            }
        }
        public void DeleteBusLine(int id)
        {
            try
            {
                //Delete all stations through which the line passes
                Predicate<DO.stationInLine> condition = item => item.LineId == id;
                IEnumerable<DO.stationInLine> stationsInLine = dal.GetStationInLineCollectionBy(condition);
                foreach (DO.stationInLine item in stationsInLine)
                    dal.DeleteStationInLine(item);
                dal.DeleteBusLine(id);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
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
        public BO.BusLineBL GetBusLineBL(int Id)
        {
            try
            {
                DO.BusLine busLineDO = dal.GetBusLine(Id);
                BO.BusLineBL busLineBL = new BO.BusLineBL();
                busLineDO.Clone(busLineBL);
                BO.BusStation busStationBO1 = new BO.BusStation();
                BO.BusStation busStationBO2 = new BO.BusStation();

                DO.BusStation busStationDO1 = dal.GetBusStation(busLineBL.FirstStationCode);
                DO.BusStation busStationDO2 = dal.GetBusStation(busLineBL.LastStationCode);

                busStationDO1.Clone(busStationBO1);
                busStationDO2.Clone(busStationBO2);

                busLineBL.FirstStation = busStationBO1;
                busLineBL.LastStation = busStationBO2;


                BO.StationInLine stationInLineBO = new BO.StationInLine();
                Predicate<DO.stationInLine> condition = item => item.LineId == busLineBL.BusId;
                IEnumerable<DO.stationInLine> stationsDO = dal.GetStationInLineCollectionBy(condition);
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
        }
        #endregion

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
        public void AddStationInLine(BO.StationInLine stationLineBO)
        {
            DO.stationInLine stationLineDO = new DO.stationInLine();
            stationLineBO.Clone(stationLineDO);
            try
            {

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
        }

        public void DeleteStationInLine(BO.StationInLine stationLineBO)
        {
            DO.stationInLine stationLineDO = new DO.stationInLine();
            stationLineBO.Clone(stationLineDO);
            try
            {
                Predicate<DO.stationInLine> predicate = item => item.LineId == stationLineBO.LineId;
                IEnumerable<DO.stationInLine> stationInLinesAtTheSameLine = dal.GetStationInLineCollectionBy(predicate);
                foreach (DO.stationInLine item in stationInLinesAtTheSameLine)
                {
                    if (item.IndexStationAtLine > stationLineBO.IndexStationAtLine)
                    {
                        --item.IndexStationAtLine;
                        dal.UpdateStationInLine(item);
                    }
                }
                if (stationLineBO.IsFirstStation)
                    updateFirstStation(stationLineBO.StationCode, stationLineBO.LineId);
                else
                if (stationLineBO.IsLastStation)
                    updateLastStation(stationLineBO.StationCode, stationLineBO.LineId);
                else
                    dal.DeleteStationInLine(stationLineDO);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
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

