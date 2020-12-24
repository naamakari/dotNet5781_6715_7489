using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIDAL;
using DO;
using DS;

namespace DL
{
    public class DLObject:IDAL
    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }
        DLObject() { }
        static DLObject Instance => instance;
        #endregion


        #region  CRUD for Bus
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
                throw new DalEmptyCollectionExeption("לא קיימים אוטובוסים פעילים במערכת");
            return TempBus;
        }
        public IEnumerable<Bus> GetAllBusesCollection()
        {
            IEnumerable<Bus> TempBus = from Bus item in DataS.buses
                                       select item;
            if (TempBus.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים אוטובוסים במערכת");
            return TempBus;
        }
        public IEnumerable<Bus> GetBusCollectionBy(Predicate<Bus> condition)
        {
            IEnumerable<Bus> TempBus = from Bus item in DataS.buses
                                       where condition(item)
                                       select item.Clone();
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
            DataS.buses.Remove(DataS.buses.Find(x => x.LicenseNumber == bus.LicenseNumber));
            DataS.buses.Add(bus.Clone());
        }
        public void DeleteBus(string liscenceNum)
        {
            if (!DataS.buses.Any(x => x.LicenseNumber == liscenceNum))
                throw new KeyNotFoundException("כבר לא קיים במערכת " + liscenceNum + " אוטובוס");
            DataS.buses.Find(x => x.LicenseNumber == liscenceNum).IsDeleted = true;
        }
        #endregion

        #region CRUD for bus line

        public void AddBusLine(BusLine busLine)
        {
            if (DataS.busLines.Any(x => x.BusId == busLine.BusId))
                throw new DalAlreayExistExeption("קיים כבר במערכת " + busLine.BusId + " קו אוטובוס מספר");
            busLine.BusId = Configuration.GetBusLineRunNum();
            DataS.busLines.Add(busLine.Clone());
        }
        public BusLine GetBusLine(int busId)
        {
            if (!DataS.busLines.Any(x => x.BusId == busId))
                throw new KeyNotFoundException("לא קיים במערכת " + busId + " קו אוטובוס מספר");
            BusLine tempBusLine = DataS.busLines.Find(x => x.BusId == busId);
            if (tempBusLine.IsDeleted == true)
                throw new KeyNotFoundException("לא פעיל " + busId + " קו אוטובוס מספר");
            return tempBusLine.Clone();
        }
        public IEnumerable<BusLine> GetBusLineCollection()
        {
            IEnumerable<BusLine> TempBusLine = from BusLine item in DataS.busLines
                                               where item.IsDeleted == false
                                               select item;
            if (TempBusLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים קווי אוטובוס פעילים במערכת");
            return TempBusLine;
        }
        public IEnumerable<BusLine> GetAllBusLinesCollection()
        {
            IEnumerable<BusLine> TempBusLine = from BusLine item in DataS.busLines
                                               select item;
            if (TempBusLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים קווי אוטובוס במערכת");
            return TempBusLine;
        }
        public IEnumerable<BusLine> GetBusLineCollectionBy(Predicate<BusLine> condition)
        {
            IEnumerable<BusLine> TempBusLine = from BusLine item in DataS.busLines
                                               where condition(item)
                                               select item.Clone();
            if (TempBusLine.Count() == 0)
                throw new DalEmptyCollectionExeption(" לא קיימים קווי אוטובוס במערכת שעונים לתנאי המבוקש");
            return TempBusLine;
        }
        public void UpdateBusLine(BusLine busLine)
        {
            if (!DataS.busLines.Any(x => x.BusId == busLine.BusId))
                throw new KeyNotFoundException("לא קיים במערכת " + busLine.BusId + " קו אוטובוס מספר");
            BusLine TempBusLine = DataS.busLines.Find(x => x.BusId == busLine.BusId);
            if (TempBusLine.IsDeleted)
                throw new KeyNotFoundException("לא פעיל " + TempBusLine.BusId + " אוטובוס");
            DataS.busLines.Remove(TempBusLine);
            DataS.busLines.Add(busLine.Clone());
        }
        public void DeleteBusLine(int busId)
        {
            if (!DataS.busLines.Any(x => x.BusId == busId))
                throw new KeyNotFoundException("כבר לא קיים במערכת " + busId + " קו אוטובוס מספר");
            //BusLine tempBusLine = DataS.busLines.Find(x => x.BusId == busLine.BusId);
            //tempBusLine.IsDeleted = true;
            DataS.busLines.Find(x => x.BusId == busId).IsDeleted = true;
        }
        #endregion

        #region CRUD for bus station
        public void AddBusStation(BusStation busStation)
        {
            if (DataS.busStations.Any(x => x.StationCode == busStation.StationCode))
                throw new DalAlreayExistExeption("קיימת כבר במערכת " + busStation.StationCode + " תחנה מספר");
            busStation.StationCode = Configuration.GetBusStationRunNum();
            DataS.busStations.Add(busStation.Clone());
        }
        public BusStation GetBusStation(int stationCode)
        {
            if (!DataS.busStations.Any(x => x.StationCode == stationCode))
                throw new KeyNotFoundException("לא קיימת במערכת " + stationCode + " תחנה מספר");
            BusStation tempBusStation = DataS.busStations.Find(x => x.StationCode == stationCode);
            if (tempBusStation.IsDeleted == true)
                throw new KeyNotFoundException("לא פעילה " + stationCode + " תחנה מספר");
            return tempBusStation.Clone();
        }
        public IEnumerable<BusStation> GetBusStationCollection()
        {
            IEnumerable<BusStation> TempBusStation = from BusStation item in DataS.busStations
                                                     where item.IsDeleted == false
                                                     select item.Clone();
            if (TempBusStation.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות אוטובוס פעילות במערכת");
            return TempBusStation;
        }
        public IEnumerable<BusStation> GetAllBusStationsCollection()
        {
            IEnumerable<BusStation> TempBusStation = from BusStation item in DataS.busStations
                                                     select item.Clone();
            if (TempBusStation.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות אוטובוס במערכת");
            return TempBusStation;
        }

        public IEnumerable<BusStation> GetBusStationCollectionBy(Predicate<BusStation> condition)
        {
            IEnumerable<BusStation> TempBusStation = from BusStation item in DataS.busStations
                                                     where condition(item)
                                                     select item.Clone();
            if (TempBusStation.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות אוטובוס במערכת");
            return TempBusStation;

        }

        public void UpdateBusStation(BusStation busStation)
        {
            if (!DataS.busStations.Any(x => x.StationCode == busStation.StationCode))
                throw new KeyNotFoundException("לא קיימת במערכת " + busStation.StationCode + " תחנה מספר");
            BusStation TempBusStation = DataS.busStations.Find(x => x.StationCode == busStation.StationCode);
            if (TempBusStation.IsDeleted)
                throw new KeyNotFoundException("לא פעילה " + busStation.StationCode + " תחנה");
            DataS.busStations.Remove(DataS.busStations.Find(x => x.StationCode == busStation.StationCode));
            DataS.busStations.Add(busStation.Clone());
        }
        public void DeleteBusStation(int busStationCode)
        {
            if (!DataS.busStations.Any(x => x.StationCode == busStationCode))
                throw new KeyNotFoundException("כבר לא קיימת במערכת " + busStationCode + " תחנה מספר");
            DataS.busStations.Find(x => x.StationCode == busStationCode).IsDeleted = true;
        }
        #endregion

        #region CRUD for following stations

        public void AddFollowingStations(FollowingStations followingStations)
        {
            if (DataS.followingStations.Any(x => x.StationCode1 + x.StationCode2 == followingStations.StationCode1 + followingStations.StationCode2))
                throw new DalAlreayExistExeption("קיימות כבר במערכת " + followingStations.StationCode1 + " , " + followingStations.StationCode2 + " תחנות עוקבות אלו ");
            DataS.followingStations.Add(followingStations.Clone());
        }
        public FollowingStations GetFollowingStation(int stationCode1, int stationCode2)
        {
            if (!DataS.followingStations.Any(x => x.StationCode1 + x.StationCode2 == stationCode1 + stationCode2))
                throw new DalAlreayExistExeption("לא קיימות במערכת " + stationCode1 + " , " + stationCode2 + " תחנות עוקבות אלו ");
            FollowingStations followingStationsTemp = DataS.followingStations.Find(x => x.StationCode1 + x.StationCode2 == stationCode1 + stationCode2);
            return followingStationsTemp.Clone();
        }
        public IEnumerable<FollowingStations> GetFollowingStationsCollection()
        {
            IEnumerable<FollowingStations> TempFollowingStations = from FollowingStations item in DataS.followingStations

                                                                   select item.Clone();
            if (TempFollowingStations.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות עוקבות במערכת");
            return TempFollowingStations;
        }
        public IEnumerable<FollowingStations> GetFollowingStationsCollectionBy(Predicate<FollowingStations> condition)
        {
            IEnumerable<FollowingStations> TempFollowingStations = from FollowingStations item in DataS.followingStations
                                                                   where condition(item)
                                                                   select item.Clone();
            if (TempFollowingStations.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות עוקבות במערכת שעונות לתנאי המבוקש");
            return TempFollowingStations;
        }
        public void UpdateFollowingStations(FollowingStations followingStations)
        {
            if (!DataS.followingStations.Any(x => x.StationCode1 + x.StationCode2 == followingStations.StationCode1 + followingStations.StationCode2))
                throw new KeyNotFoundException("לא קיימות במערכת " + followingStations.StationCode1 + " , " + followingStations.StationCode2 + " תחנות עוקבות אלו ");
            DataS.followingStations.Remove(DataS.followingStations.Find(x => x.StationCode2 == followingStations.StationCode1 + followingStations.StationCode2));
            DataS.followingStations.Add(followingStations.Clone());
        }
        public void DeleteFollowingStations(FollowingStations followingStations)
        {
            if (!DataS.followingStations.Any(x => x.StationCode1 + x.StationCode2 == followingStations.StationCode1 + followingStations.StationCode2))
                throw new KeyNotFoundException("כבר לא קיימות במערכת " + followingStations.StationCode1 + " , " + followingStations.StationCode2 + " תחנות עוקבות אלו");
            FollowingStations tempFollowingStations = DataS.followingStations.Find(x => x.StationCode1 + x.StationCode2 == followingStations.StationCode1 + followingStations.StationCode2);
            DataS.followingStations.Remove(DataS.followingStations.Find(x => x.StationCode1 + x.StationCode2 == followingStations.StationCode1 + followingStations.StationCode2));
        }
        #endregion

        #region CRUD for station at line 

        public void AddStationInLine(stationInLine stationInLine)
        {
            if (DataS.stationsInLine.Any(x => (x.LineId == stationInLine.LineId) && (x.StationCode == stationInLine.StationCode)))
                throw new DalAlreayExistExeption("קיימת כבר במערכת " + stationInLine.LineId + " תחנת זו של קו");
            DataS.stationsInLine.Add(stationInLine.Clone());
        }
        public stationInLine GetStationInLine(int lineId, int stationCode)
        {
            if (!DataS.stationsInLine.Any(x => (x.LineId == lineId) && (x.StationCode == stationCode)))
                throw new KeyNotFoundException("לא קיימת במערכת " + lineId + " תחנת קו");
            stationInLine tempStationInLine = DataS.stationsInLine.Find(x => (x.LineId == lineId) && (x.StationCode == stationCode));
            if (tempStationInLine.IsDeleted == true)
                throw new KeyNotFoundException("לא פעילה " + lineId + " תחנה זו של קו");
            return tempStationInLine.Clone();
        }
        public IEnumerable<stationInLine> GetStationInLineCollection()
        {
            IEnumerable<stationInLine> TempstationInLine = from stationInLine item in DataS.stationsInLine
                                                           where item.IsDeleted == false
                                                           select item;
            if (TempstationInLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות קו פעילות במערכת");
            return TempstationInLine;
        }
        public IEnumerable<stationInLine> GetAllStationsInLineCollection()
        {
            IEnumerable<stationInLine> TempstationInLine = from stationInLine item in DataS.stationsInLine
                                                           select item;
            if (TempstationInLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות קו במערכת");
            return TempstationInLine;
        }

        public IEnumerable<stationInLine> GetStationInLineCollectionBy(Predicate<stationInLine> condition)
        {
            IEnumerable<stationInLine> TempStationInLine = from stationInLine item in DataS.stationsInLine
                                                           where condition(item)
                                                           select item.Clone();
            if (TempStationInLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות קו פעילות במערכת העונות לתנאי המבוקש");
            return TempStationInLine;
        }
        public void UpdateStationInLine(stationInLine stationInLine)
        {
            if (!DataS.stationsInLine.Any(x => (x.LineId == stationInLine.LineId) && (x.StationCode == stationInLine.StationCode)))
                throw new KeyNotFoundException("לא קיימת במערכת " + stationInLine.LineId + " תחנת קו");
            stationInLine TempstationInLine = DataS.stationsInLine.Find(x => (x.LineId == stationInLine.LineId) && (x.StationCode == stationInLine.StationCode));
            if (TempstationInLine.IsDeleted)
                throw new KeyNotFoundException("לא פעילה " + TempstationInLine.LineId + " תחנת קו");
            DataS.stationsInLine.Remove(DataS.stationsInLine.Find(x => (x.LineId == stationInLine.LineId) && (x.StationCode == stationInLine.StationCode)));
            DataS.stationsInLine.Add(stationInLine.Clone());
        }
        public void DeleteStationInLine(stationInLine stationInLine)
        {
            if (!DataS.stationsInLine.Any(x => (x.LineId == stationInLine.LineId) && (x.StationCode == stationInLine.StationCode)))
                throw new KeyNotFoundException("כבר לא קיימת במערכת " + stationInLine.LineId + " תחנת קו");
            DataS.stationsInLine.Find(x => x.LineId == stationInLine.LineId).IsDeleted = true;
        }
        #endregion

        #region CRUD for User
       public void AddUser(User user)
        {
            if (DataS.users.Any(x => x.UserName == user.UserName))
                throw new DalAlreayExistExeption("כבר קיים במערכת " + user.UserName + " שם המשתמש");
            DataS.users.Add(user.Clone());  
        }
      public User GetUser(string UserName)
        {
            if (!DataS.users.Any(x => x.UserName == UserName))
                throw new KeyNotFoundException("לא קיים במערכת " + UserName + " המשתמש");
            return DataS.users.Find(x => x.UserName == UserName).Clone();
        }
       public IEnumerable<User> GetUsersCollection()
        {

        }
        IEnumerable<User> GetUserCollectionBy(Predicate<User> predicate);
        void UpdateUser(User user);
        void DeleteUser(User user);
        #endregion
    }
}
