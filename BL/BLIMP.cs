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
      public  void sendToRefuel(BO.Bus bus)
        {
            try
            {
                DO.Bus busDO = dal.GetBus(bus.LicenseNumber);
                busDO.KmSinceRefeul = (float)0.0;
                dal.UpdateBus(busDO);
            }
            catch(KeyNotFoundException ex)
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

        #region methods for bus
        public void AddBus(BO.Bus busBO)
        {
            DO.Bus busDO = new DO.Bus(); 
            busBO.Clone(busDO);
            try
            {
                dal.AddBus(busDO);
            }
            catch(DO.DalAlreayExistExeption ex)
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
            catch(KeyNotFoundException ex)
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
            catch(KeyNotFoundException ex)
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
            catch(KeyNotFoundException ex)
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
        public BO.BusLineBL GetBusLineBL(int Id)
        {
            try
            {
                DO.BusLine busLineDO = dal.GetBusLine(Id);
                BO.BusLineBL busLineBL = new BO.BusLineBL();
                busLineDO.Clone(busLineBL);
                BO.BusStation busStationBO1 = new BO.BusStation();
                BO.BusStation busStationBO2 = new BO.BusStation();

                DO.BusStation busStationDO1= dal.GetBusStation(busLineBL.FirstStationCode);
                DO.BusStation busStationDO2 = dal.GetBusStation(busLineBL.LastStationCode);

                busStationDO1.Clone(busStationBO1);
                busStationDO2.Clone(busStationBO2);

                busLineBL.FirstStation = busStationBO1;
                busLineBL.LastStation = busStationBO2;

                BO.stationInLine stationInLineBO = new BO.stationInLine();
                busLineBL.CollectionOfStation = from item in dal.GetStationInLineCollection()
                                                where item.LineId == Id
                                                select item.Clone(stationInLineBO)
                return busLineBL;
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
        }
        public void DeleteBusStation(int code);
        public void UpdateBusStation(BusStation busStation);

        public void AddBusLine(BO.BusLine busLineBO)
        {
            DO.BusStation busLineDO = new DO.BusStation();
            busLineBO.Clone(busLineDO);
            try
            {
                dal.AddBusStation(busLineDO);
            }
            catch (DO.DalAlreayExistExeption ex)
            {
                throw new BO.DalAlreayExistExeption(ex.Message, ex);
            }
        }
        public BusStationBL GetBusStationBL(int code);
        public void DeleteBusLine(int id);
        public void UpdateBusLine(BusLine busLine);

    }
}
