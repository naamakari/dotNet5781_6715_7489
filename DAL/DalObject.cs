using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using APIDAL;
using DS;

namespace DAL
{
    class DalObject : IDAL
    {
        #region singelton
        static readonly DalObject instance = new DalObject();
        static DalObject() { }
        DalObject() { }
        static DalObject Instance => instance;
        #endregion

        public void AddBus(Bus bus)
        {
            if (DataS.buses.Any(x => x.LicenseNumber == bus.LicenseNumber))
                throw new DalAlreayExistExeption("קיים כבר במערכת " + bus.LicenseNumber + " אוטובוס");
            DataS.buses.Add(bus.Clone());
        }
        public Bus GetBus(string Id)
        {
            if (!DataS.buses.Any(x => x.LicenseNumber == Id))
                throw new KeyNotFoundException("לא קיים במערכת " + Id + " אוטובוס");
            Bus tempBus = DataS.buses.Find(x => x.LicenseNumber == Id);
            if (tempBus.IsDeleted == true)
                throw new KeyNotFoundException("לא פעיל " + Id + " אוטובוס");
            return tempBus.Clone();
        }
        public IEnumerable<Bus> GetBusCollection()
        {
            IEnumerable<Bus> TempBus = from Bus item in DataS.buses
                                       where item.IsDeleted == false
                                       select item;
            if (TempBus.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים אוטובוסים במערכת");
            return TempBus;
        }
        public void UpdateBus(Bus bus)
        {
            if (!DataS.buses.Any(x => x.LicenseNumber == bus.LicenseNumber))
                throw new KeyNotFoundException("לא קיים במערכת " + bus.LicenseNumber + " אוטובוס");
            Bus TempBus = DataS.buses.Find(x => x.LicenseNumber == bus.LicenseNumber);
            if (TempBus.IsDeleted)
                throw new KeyNotFoundException("לא פעיל " + TempBus.LicenseNumber + " אוטובוס");
            DataS.buses.Remove(TempBus);
            DataS.buses.Add(bus.Clone());
        }
        public void DeleteBus(Bus bus)
        {
            if (!DataS.buses.Any(x => x.LicenseNumber == bus.LicenseNumber))
                throw new KeyNotFoundException("כבר לא קיים במערכת " + bus.LicenseNumber + " אוטובוס");
            Bus tempBus = DataS.buses.Find(x => x.LicenseNumber == bus.LicenseNumber);
            tempBus.IsDeleted = true;
        }

        /// <summary>
        /// CRUD for bus line
        /// </summary>
       public void AddBusLine(BusLine busLine)
        {
            if (DataS.busLines.Any(x =>x.BusId==busLine.BusId))
                throw new DalAlreayExistExeption("קיים כבר במערכת " + busLine.BusId + " קו אוטובוס מספר");
            DataS.busLines.Add(busLine.Clone());
        }
      public  BusLine GetBusLine(int busId)
        {
            if (!DataS.busLines.Any(x => x.BusId == busId))
                throw new KeyNotFoundException("לא קיים במערכת " + busId + " קו אוטובוס מספר");
            BusLine tempBusLine = DataS.busLines.Find(x => x.BusId == busId);
            if (tempBusLine.IsDeleted == true)
                throw new KeyNotFoundException("לא פעיל " + busId + " קו אוטובוס מספר");
            return tempBusLine.Clone();
        }
      public  IEnumerable<BusLine> GetBusLineCollection()
        {
            IEnumerable<BusLine> TempBusLine = from BusLine item in DataS.busLines
                                       where item.IsDeleted == false
                                       select item;
            if (TempBusLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים קווי אוטובוס במערכת");
            return TempBusLine;
        }
        IEnumerable<BusLine> GetBusLineCollection(int StationCode);
      public  void UpdateBusLine(BusLine busLine)
        {
            if (!DataS.busLines.Any(x => x.BusId == busLine.BusId))
                throw new KeyNotFoundException("לא קיים במערכת " + busLine.BusId + " קו אוטובוס מספר");
            BusLine TempBusLine = DataS.busLines.Find(x => x.BusId == busLine.BusId);
            if (TempBusLine.IsDeleted)
                throw new KeyNotFoundException("לא פעיל " + TempBusLine.BusId + " אוטובוס");
            DataS.busLines.Remove(TempBusLine);
            DataS.busLines.Add(busLine.Clone());
        }
       public void DeleteBusLine(BusLine busLine)
        {
            if (!DataS.busLines.Any(x => x.BusId == busLine.BusId))
                throw new KeyNotFoundException("כבר לא קיים במערכת " + busLine.BusId + " קו אוטובוס מספר");
            BusLine tempBusLine = DataS.busLines.Find(x => x.BusId == busLine.BusId);
            tempBusLine.IsDeleted = true;
        }

        /// <summary>
        /// CRUD for bus station
        /// </summary>

     public  void AddBusStation(BusStation busStation)
        {
            if (DataS.busStations.Any(x => x.StationCode == busStation.StationCode))
                throw new DalAlreayExistExeption("קיימת כבר במערכת " + busStation.StationCode + " תחנה מספר");
            DataS.busStations.Add(busStation.Clone());
        }
       public BusStation GetBusStation(int stationCode)
        {
            if (!DataS.busStations.Any(x => x.StationCode == stationCode))
                throw new KeyNotFoundException("לא קיימת במערכת " + stationCode + " תחנה מספר");
            BusStation tempBusStation = DataS.busStations.Find(x => x.StationCode == stationCode);
            //if (tempBusStation.IsDeleted == true)
            //    throw new KeyNotFoundException("לא פעילה " + stationCode + " תחנה מספר");
            return tempBusStation.Clone();
        }
       public IEnumerable<BusStation> GetBusStationCollection()
        {
            IEnumerable<BusStation> TempBusStation = from BusStation item in DataS.busStations
                                               where item.IsDeleted == false
                                               select item;
            if (TempBusStation.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות אוטובוס במערכת");
            return TempBusStation;
        }
      public  void UpdateBusStation(BusStation busStation)
        {
            if (!DataS.busStations.Any(x => x.StationCode == busStation.StationCode))
                throw new KeyNotFoundException("לא קיימת במערכת " + busStation.StationCode + " תחנה מספר");
            BusStation TempBusStation = DataS.busStations.Find(x => x.StationCode == busStation.StationCode);
            //if (TempBusStation.IsDeleted)
            //    throw new KeyNotFoundException("לא פעילה " + busStation.StationCode + " תחנה");
            DataS.busStations.Remove(TempBusStation);
            DataS.busStations.Add(busStation.Clone());
        }
        void DeleteBusStation(BusStation busStation)
        {
            if (!DataS.busStations.Any(x => x.StationCode == busStation.StationCode))
                throw new KeyNotFoundException("כבר לא קיימת במערכת " + busStation.StationCode + " תחנה מספר");
            BusStation tempBusStation = DataS.busStations.Find(x => x.StationCode == busStation.StationCode);
            tempBusStation.IsDeleted = true;
        }

        /// <summary>
        /// CRUD for following stations
        /// </summary>
        void AddFollowingStations(FollowingStations followingStations);
        FollowingStations GetFollowingStation(int stationCode1, int stationCode2);
        IEnumerable<FollowingStations> GetFollowingStationsCollection();
        void UpdateFoloowingStations(FollowingStations followingStations);
        void DeleteFollowingStations(FollowingStations followingStations);

        /// <summary>
        /// CRUD for station at line 
        /// </summary>
        void AddStationInLine(stationInLine stationInLine);
        stationInLine GetStationInLine(int lineId);
        IEnumerable<stationInLine> GetStationInLineCollection();
        IEnumerable<stationInLine> GetStationInLineCollection(int lineId);
        void UpdateStationInLine(stationInLine stationInLine);
        void DeleteStationInLine(stationInLine stationInLine);
    }
}
