using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using DS;
using APIDAL;

namespace DL
{
    public class DalObject:IDAL
    {
        #region singelton
        static readonly DalObject instance = new DalObject();
        static DalObject() { }
        DalObject() { }
        public static DalObject Instance { get => instance; }
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
            Bus tempBus = DataS.buses.Find(x => x.LicenseNumber == Id);
            if(tempBus==null)
                throw new KeyNotFoundException("לא קיים במערכת " + Id + " אוטובוס");
            if (tempBus.IsDeleted == true)
                throw new KeyNotFoundException("לא פעיל " + Id + " אוטובוס");
            return tempBus.Clone();
        }
        public IEnumerable<Bus> GetBusCollection()
        {
            IEnumerable<Bus> TempBus = from Bus item in DataS.buses
                                       where item.IsDeleted == false
                                       select item.Clone();
            if (TempBus.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים אוטובוסים פעילים במערכת");
            return TempBus;
        }
        public IEnumerable<Bus> GetAllBusesCollection()
        {
            IEnumerable<Bus> TempBus = from Bus item in DataS.buses
                                       select item.Clone();
            if (TempBus.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים אוטובוסים במערכת");
            return TempBus;
        }
        public IEnumerable<Bus> GetBusCollectionBy(Predicate<Bus> condition)
        {
            IEnumerable<Bus> TempBus = from Bus item in DataS.buses
                                       where condition(item)&&item.IsDeleted==false
                                       select item.Clone();
            if (TempBus.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים אוטובוסים במערכת");
            return TempBus;
        }

        public void UpdateBus(Bus bus)
        {                
            Bus TempBus = DataS.buses.Find(x => x.LicenseNumber == bus.LicenseNumber);
            if(TempBus==null)
                throw new KeyNotFoundException("לא קיים במערכת " + bus.LicenseNumber + " אוטובוס");
            if (TempBus.IsDeleted)
                throw new KeyNotFoundException("לא פעיל " + TempBus.LicenseNumber + " אוטובוס");
            DataS.buses.Remove(DataS.buses.Find(x => x.LicenseNumber == bus.LicenseNumber));
            DataS.buses.Add(bus.Clone());
        }
        public void DeleteBus(string liscenceNum)
        {              
            Bus bus = DataS.buses.Find(x => x.LicenseNumber == liscenceNum);
            if(bus==null)
                throw new KeyNotFoundException("כבר לא קיים במערכת " + liscenceNum + " אוטובוס");
            bus.IsDeleted = true;
        }
        #endregion

        #region CRUD for bus line

        public void AddBusLine(BusLine busLine)
        {
            busLine.BusId = Configuration.GetBusLineRunNum();
            //צריך את הבדיקה הזו?
            if (DataS.busLines.Any(x => x.BusId == busLine.BusId))
                throw new DalAlreayExistExeption("קיים כבר במערכת " + busLine.BusId + " קו אוטובוס מספר");
            DataS.busLines.Add(busLine.Clone());
        }
        public BusLine GetBusLine(int busId)
        {
            BusLine tempBusLine = DataS.busLines.Find(x => x.BusId == busId);
            if(tempBusLine==null)
                throw new KeyNotFoundException("לא קיים במערכת " + busId + " קו אוטובוס מספר");
            if (tempBusLine.IsDeleted == true)
                throw new KeyNotFoundException("לא פעיל " + busId + " קו אוטובוס מספר");
            return tempBusLine.Clone();
        }
        public IEnumerable<BusLine> GetBusLineCollection()
        {
            IEnumerable<BusLine> TempBusLine = from BusLine item in DataS.busLines
                                               where item.IsDeleted == false
                                               select item.Clone();
            if (TempBusLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים קווי אוטובוס פעילים במערכת");
            return TempBusLine;
        }
        public IEnumerable<BusLine> GetAllBusLinesCollection()
        {
            IEnumerable<BusLine> TempBusLine = from BusLine item in DataS.busLines
                                               select item.Clone();
            if (TempBusLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים קווי אוטובוס במערכת");
            return TempBusLine;
        }
        public IEnumerable<BusLine> GetBusLineCollectionBy(Predicate<BusLine> condition)
        {
            IEnumerable<BusLine> TempBusLine = from BusLine item in DataS.busLines
                                               where condition(item)&&item.IsDeleted==false
                                               select item.Clone();
            if (TempBusLine.Count() == 0)
                throw new DalEmptyCollectionExeption(" לא קיימים קווי אוטובוס במערכת שעונים לתנאי המבוקש");
            return TempBusLine;
        }
        public void UpdateBusLine(BusLine busLine)
        {
            BusLine TempBusLine = DataS.busLines.Find(x => x.BusId == busLine.BusId);
            if(TempBusLine==null)
                throw new KeyNotFoundException("לא קיים במערכת " + busLine.BusId + " קו אוטובוס מספר");
            if (TempBusLine.IsDeleted)
                throw new KeyNotFoundException("לא פעיל " + TempBusLine.BusId + " אוטובוס");
            DataS.busLines.Remove(TempBusLine);
            DataS.busLines.Add(busLine.Clone());
        }
        public void DeleteBusLine(int busId)
        {
            BusLine tempBusLine = DataS.busLines.Find(x => x.BusId ==busId);
            if(tempBusLine==null)
                    throw new KeyNotFoundException("כבר לא קיים במערכת " + busId + " קו אוטובוס מספר");
            tempBusLine.IsDeleted = true;
        }
        #endregion

        #region CRUD for bus station
        public void AddBusStation(BusStation busStation)
        {
            busStation.StationCode = Configuration.GetBusStationRunNum();
            //צריך את הבדיקה הזו?
            if (DataS.busStations.Any(x => x.StationCode == busStation.StationCode))
                throw new DalAlreayExistExeption("קיימת כבר במערכת " + busStation.StationCode + " תחנה מספר");
            DataS.busStations.Add(busStation.Clone());
        }
        public BusStation GetBusStation(int stationCode)
        {
            BusStation tempBusStation = DataS.busStations.Find(x => x.StationCode == stationCode);
            if(tempBusStation==null)
                throw new KeyNotFoundException("לא קיימת במערכת " + stationCode + " תחנה מספר");
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
                                                     where condition(item)&&item.IsDeleted==false
                                                     select item.Clone();
            if (TempBusStation.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות אוטובוס במערכת");
            return TempBusStation;
        }

        public void UpdateBusStation(BusStation busStation)
        {
            BusStation TempBusStation = DataS.busStations.Find(x => x.StationCode == busStation.StationCode);
            if(TempBusStation==null)
                throw new KeyNotFoundException("לא קיימת במערכת " + busStation.StationCode + " תחנה מספר");
            if (TempBusStation.IsDeleted)
                throw new KeyNotFoundException("לא פעילה " + busStation.StationCode + " תחנה");
            DataS.busStations.Remove(DataS.busStations.Find(x => x.StationCode == busStation.StationCode));
            DataS.busStations.Add(busStation.Clone());
        }
        public void DeleteBusStation(int busStationCode)
        {
            BusStation busStation = DataS.busStations.Find(x => x.StationCode == busStationCode);
            if(busStation==null)
                throw new KeyNotFoundException("כבר לא קיימת במערכת " + busStationCode + " תחנה מספר");
            busStation.IsDeleted = true;
        }
        #endregion

        #region CRUD for following stations

        public void AddFollowingStations(FollowingStations followingStations)
        {
            if (DataS.followingStations.Any(x => x.StationCode1  == followingStations.StationCode1&& x.StationCode2 == followingStations.StationCode2))
                throw new DalAlreayExistExeption("קיימות כבר במערכת " + followingStations.StationCode1 + " , " + followingStations.StationCode2 + " תחנות עוקבות אלו ");
            DataS.followingStations.Add(followingStations.Clone());
        }
        public FollowingStations GetFollowingStation(int stationCode1, int stationCode2)
        {
            FollowingStations followingStationsTemp = DataS.followingStations.Find(x => x.StationCode1 == stationCode1&& x.StationCode2 ==  stationCode2);
            if(followingStationsTemp==null)
                throw new DalAlreayExistExeption("לא קיימות במערכת " + stationCode1 + " , " + stationCode2 + " תחנות עוקבות אלו ");
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
            FollowingStations followingStations1 = DataS.followingStations.Find(x => x.StationCode1 == followingStations.StationCode1 &&x.StationCode2== followingStations.StationCode2);
            if(followingStations1==null)
                throw new KeyNotFoundException("לא קיימות במערכת " + followingStations.StationCode1 + " , " + followingStations.StationCode2 + " תחנות עוקבות אלו ");
            DataS.followingStations.Remove(followingStations1);
            DataS.followingStations.Add(followingStations.Clone());
        }
        public void DeleteFollowingStations(FollowingStations followingStations)
        {
            FollowingStations tempFollowingStations = DataS.followingStations.Find(x => x.StationCode1 == followingStations.StationCode1&& x.StationCode2  == followingStations.StationCode2);
            if(tempFollowingStations==null)
                throw new KeyNotFoundException("כבר לא קיימות במערכת " + followingStations.StationCode1 + " , " + followingStations.StationCode2 + " תחנות עוקבות אלו");
            DataS.followingStations.Remove(tempFollowingStations);
        }
        #endregion
       
        #region CRUD for station at line 

        public void AddStationInLine(stationInLine stationInLine)
        {
            if (DataS.stationsInLine.Any(x =>(x.LineId == stationInLine.LineId) && (x.StationCode == stationInLine.StationCode)))
                throw new DalAlreayExistExeption("קיימת כבר במערכת " + stationInLine.LineId + " תחנת זו של קו");
            DataS.stationsInLine.Add(stationInLine.Clone());
        }
        public stationInLine GetStationInLine(int lineId, int stationCode)
        {
            stationInLine tempStationInLine = DataS.stationsInLine.Find(x => (x.LineId == lineId) && (x.StationCode == stationCode));
          if(tempStationInLine==null)
                throw new KeyNotFoundException("לא קיימת במערכת " + lineId + " תחנת קו");
            if (tempStationInLine.IsDeleted == true)
                throw new KeyNotFoundException("לא פעילה " + lineId + " תחנה זו של קו");
            return tempStationInLine.Clone();
        }
        public IEnumerable<stationInLine> GetStationInLineCollection()
        {
            IEnumerable<stationInLine> TempstationInLine = from stationInLine item in DataS.stationsInLine
                                                           where item.IsDeleted == false
                                                           select item.Clone();
            if (TempstationInLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות קו פעילות במערכת");
            return TempstationInLine;
        }
        public IEnumerable<stationInLine> GetAllStationsInLineCollection()
        {
            IEnumerable<stationInLine> TempstationInLine = from stationInLine item in DataS.stationsInLine
                                                           select item.Clone();
            if (TempstationInLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות קו במערכת");
            return TempstationInLine;
        }

        public IEnumerable<stationInLine> GetStationInLineCollectionBy(Predicate<stationInLine> condition)
        {
            IEnumerable<stationInLine> TempStationInLine = from stationInLine item in DataS.stationsInLine
                                                           where condition(item)&&item.IsDeleted==false
                                                           select item.Clone();
            if (TempStationInLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות קו פעילות במערכת העונות לתנאי המבוקש");
            return TempStationInLine;
        }
        public void UpdateStationInLine(stationInLine stationInLine)
        {
            stationInLine TempstationInLine = DataS.stationsInLine.Find(x => (x.LineId == stationInLine.LineId) && (x.StationCode == stationInLine.StationCode));
           if(TempstationInLine==null)
                throw new KeyNotFoundException("לא קיימת במערכת " + stationInLine.LineId + " תחנת קו");
            if (TempstationInLine.IsDeleted)
                throw new KeyNotFoundException("לא פעילה " + TempstationInLine.LineId + " תחנת קו");
            DataS.stationsInLine.Remove(TempstationInLine);
            DataS.stationsInLine.Add(stationInLine.Clone());
        }
        public void DeleteStationInLine(stationInLine stationInLine)
        {
            stationInLine stationInLine1= DataS.stationsInLine.Find(x => x.LineId == stationInLine.LineId && x.StationCode == stationInLine.StationCode);
       if(stationInLine1==null)
                throw new KeyNotFoundException("כבר לא קיימת במערכת " + stationInLine.LineId + " תחנת קו");
            stationInLine1.IsDeleted = true;
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
            User user = DataS.users.Find(x => x.UserName == UserName);
            if(user==null)
                throw new KeyNotFoundException("לא קיים במערכת " + UserName + " המשתמש");
            return user.Clone();
        }
        public IEnumerable<User> GetUsersCollection()
        {
            IEnumerable<User> TempUser = from User item in DataS.users
                                         select item.Clone();
            if (TempUser.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים משתמשים במערכת");
            return TempUser;
        }
        public IEnumerable<User> GetUserCollectionBy(Predicate<User> condition)
        {
            IEnumerable<User> TempUser = from User item in DataS.users
                                         where condition(item)
                                         select item.Clone();
            if (TempUser.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים משתמשים במערכת");
            return TempUser;
        }
        public void UpdateUser(User user)
        {
            User user1 = DataS.users.Find(x => x.UserName == user.UserName);
            if(user1==null)
                throw new KeyNotFoundException("לא קיים במערכת " + user.UserName + " משתמש");
            DataS.users.Remove(user1);
            DataS.users.Add(user.Clone());
        }
        public void DeleteUser(string userName)
        {
            User TempUser = DataS.users.Find(x => x.UserName == userName);
            if(TempUser==null)
                throw new KeyNotFoundException("כבר לא קיים במערכת " + userName + " המשתמש");
            if (!DataS.users.Remove(TempUser))
                throw new CanNotRemoveException("לא מצליח להסיר את המשתמש");
        }
        #endregion
    }
}
