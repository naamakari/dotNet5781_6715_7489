using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIDAL;
using APIBL;

namespace BL
{
    //לממש את הפונקציות של עדכון תחנה ראשונה ואחרונה
    //לעדכן בקובץ הנתונים
    public class BLIMP : IBL
    {

        readonly IDAL dal = DalFactory.GetDal();
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

        void updateFirstStation(int code, int busId);
        void updateLastStation(int code, int busId);

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
                                                      LastStationCode=busLine.NumberLastStation                                                      
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


                BO.stationInLine stationInLineBO = new BO.stationInLine();
                Predicate<DO.stationInLine> condition = item => item.LineId == busLineBL.BusId;
                IEnumerable<DO.stationInLine> stationsDO = dal.GetStationInLineCollectionBy(condition);
                busLineBL.CollectionOfStation = from DO.stationInLine item in stationsDO
                                                select new BO.stationInLine()
                                                {
                                                    LineId = item.LineId,
                                                    StationCode = item.StationCode,
                                                    IsFirstStation = item.IsFirstStation,
                                                    IsLastStation = item.IsLastStation,
                                                    IsDeleted = item.IsDeleted,
                                                    IndexStationAtLine = item.IndexStationAtLine

                                                };
                return busLineBL;
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }

    }
}
