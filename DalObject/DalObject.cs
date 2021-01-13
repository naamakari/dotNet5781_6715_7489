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
                throw new DalAlreayExistExeption(" אוטובוס" + bus.LicenseNumber + "קיים כבר במערכת ");
            DataS.buses.Add(bus.Clone());
        }
        public Bus GetBus(string Id)
        {    
            Bus tempBus = DataS.buses.Find(x => x.LicenseNumber == Id);
            if(tempBus==null)
                throw new KeyNotFoundException(" אוטובוס" + Id + "לא קיים במערכת ");
            if (tempBus.IsDeleted == true)
                throw new KeyNotFoundException(" אוטובוס" + Id +  "לא פעיל ");
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
                throw new KeyNotFoundException(" אוטובוס" + bus.LicenseNumber + "לא קיים במערכת ");
            if (TempBus.IsDeleted)
                throw new KeyNotFoundException( " אוטובוס" + TempBus.LicenseNumber + "לא פעיל ");
            DataS.buses.Remove(DataS.buses.Find(x => x.LicenseNumber == bus.LicenseNumber));
            DataS.buses.Add(bus.Clone());
        }
        public void DeleteBus(string liscenceNum)
        {              
            Bus bus = DataS.buses.Find(x => x.LicenseNumber == liscenceNum);
            if(bus==null)
                throw new KeyNotFoundException(" אוטובוס" + liscenceNum +"כבר לא קיים במערכת ");
            bus.IsDeleted = true;
            
        }
        #endregion

        #region CRUD for bus line

        public int AddBusLine(BusLine busLine)
        {
            busLine.BusId = Configuration.GetBusLineRunNum();
            //צריך את הבדיקה הזו?
            if (DataS.busLines.Any(x => x.BusId == busLine.BusId))
                throw new DalAlreayExistExeption(" קו אוטובוס מספר" + busLine.BusId +  "קיים כבר במערכת ");
            DataS.busLines.Add(busLine.Clone());
            return busLine.BusId;
        }
        public BusLine GetBusLine(int busId)
        {
            BusLine tempBusLine = DataS.busLines.Find(x => x.BusId == busId);
            if(tempBusLine==null)
                throw new KeyNotFoundException(" קו אוטובוס מספר" + busId + "לא קיים במערכת ");
            if (tempBusLine.IsDeleted == true)
                throw new KeyNotFoundException(" קו אוטובוס מספר" + busId +"לא פעיל ");
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
                throw new KeyNotFoundException(" קו אוטובוס מספר" + busLine.BusId +"לא קיים במערכת ");
            if (TempBusLine.IsDeleted)
                throw new KeyNotFoundException(" אוטובוס" + TempBusLine.BusId +  "לא פעיל ");
            DataS.busLines.Remove(TempBusLine);
            DataS.busLines.Add(busLine.Clone());
        }
        public void DeleteBusLine(int busId)
        {
            BusLine tempBusLine = DataS.busLines.Find(x => x.BusId ==busId);
            if(tempBusLine==null)
                    throw new KeyNotFoundException(" קו אוטובוס מספר"  + busId + "כבר לא קיים במערכת ");
            tempBusLine.IsDeleted = true;
           

        }
        #endregion

        #region CRUD for bus station
        public void AddBusStation(BusStation busStation)
        {
            busStation.StationCode = Configuration.GetBusStationRunNum();
            //צריך את הבדיקה הזו?
            if (DataS.busStations.Any(x => x.StationCode == busStation.StationCode))
                throw new DalAlreayExistExeption( " תחנה מספר" + busStation.StationCode + "קיימת כבר במערכת ");
            DataS.busStations.Add(busStation.Clone());
        }
        public BusStation GetBusStation(int stationCode)
        {
            BusStation tempBusStation = DataS.busStations.Find(x => x.StationCode == stationCode);
            if(tempBusStation==null)
                throw new KeyNotFoundException( " תחנה מספר" + stationCode + "לא קיימת במערכת ");
            if (tempBusStation.IsDeleted == true)
                throw new KeyNotFoundException( " תחנה מספר" + stationCode + "לא פעילה ");
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
                throw new KeyNotFoundException(" תחנה מספר" + busStation.StationCode + "לא קיימת במערכת ");
            if (TempBusStation.IsDeleted)
                throw new KeyNotFoundException( " תחנה" + busStation.StationCode + "לא פעילה ");
            DataS.busStations.Remove(DataS.busStations.Find(x => x.StationCode == busStation.StationCode));
            DataS.busStations.Add(busStation.Clone());
        }
        public void DeleteBusStation(int busStationCode)
        {
            BusStation busStation = DataS.busStations.Find(x => x.StationCode == busStationCode);
            if(busStation==null)
                throw new KeyNotFoundException( " תחנה מספר" + busStationCode + "כבר לא קיימת במערכת ");
            busStation.IsDeleted = true;
            
        }
        #endregion

        #region CRUD for following stations

        public void AddFollowingStations(FollowingStations followingStations)
        {
            if (DataS.followingStations.Any(x => x.StationCode1 == followingStations.StationCode1 && x.StationCode2 == followingStations.StationCode2))
                return;//It does not matter to the user if there are a couple of such stations but we do not need to add
            DataS.followingStations.Add(followingStations.Clone());
        }
        public FollowingStations GetFollowingStation(int stationCode1, int stationCode2)
        {
            FollowingStations followingStationsTemp = DataS.followingStations.Find(x => x.StationCode1 == stationCode1&& x.StationCode2 ==  stationCode2);
            if(followingStationsTemp==null)
                throw new DalAlreayExistFollowingStationsExeption( " תחנות עוקבות אלו " + stationCode1 + " , " + stationCode2 + "לא קיימות במערכת ");
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
                throw new KeyNotFoundException(" תחנות עוקבות אלו " + followingStations.StationCode1 + " , " + followingStations.StationCode2 +  "לא קיימות במערכת ");
            DataS.followingStations.Remove(followingStations1);
            DataS.followingStations.Add(followingStations.Clone());
        }
        public void DeleteFollowingStations(FollowingStations followingStations)
        {
            FollowingStations tempFollowingStations = DataS.followingStations.Find(x => x.StationCode1 == followingStations.StationCode1&& x.StationCode2  == followingStations.StationCode2);
            if(tempFollowingStations==null)
                throw new KeyNotFoundException(" תחנות עוקבות אלו" + followingStations.StationCode1 + " , " + followingStations.StationCode2 +  "כבר לא קיימות במערכת ");
            DataS.followingStations.Remove(tempFollowingStations);
        }
        #endregion
       
        #region CRUD for station at line 

        public void AddStationInLine(stationInLine stationInLine)
        {
            if (DataS.stationsInLine.Any(x =>(x.LineId == stationInLine.LineId) && (x.StationCode == stationInLine.StationCode)))
                throw new DalAlreayExistExeption(  " תחנה זו של קו" + stationInLine.LineId + "קיימת כבר במערכת ");
            DataS.stationsInLine.Add(stationInLine.Clone());
        }
        public stationInLine GetStationInLine(int lineId, int stationCode)
        {
            stationInLine tempStationInLine = DataS.stationsInLine.Find(x => (x.LineId == lineId) && (x.StationCode == stationCode));
          if(tempStationInLine==null)
                throw new KeyNotFoundException(" תחנת קו" + lineId + "לא קיימת במערכת ");
            if (tempStationInLine.IsDeleted == true)
                throw new KeyNotFoundException(" תחנה זו של קו" + lineId + "לא פעילה ");
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
                throw new KeyNotFoundException( " תחנת קו" + stationInLine.LineId + "לא קיימת במערכת ");
            if (TempstationInLine.IsDeleted)
                throw new KeyNotFoundException( " תחנת קו" + TempstationInLine.LineId + "לא פעילה ");
            DataS.stationsInLine.Remove(TempstationInLine);
            DataS.stationsInLine.Add(stationInLine.Clone());
        }
        public void DeleteStationInLine(stationInLine stationInLine)
        {
            stationInLine stationInLine1= DataS.stationsInLine.Find(x => x.LineId == stationInLine.LineId && x.StationCode == stationInLine.StationCode);
       if(stationInLine1==null)
                throw new KeyNotFoundException( " תחנת קו" + stationInLine.LineId + "כבר לא קיימת במערכת ");
            stationInLine1.IsDeleted = true;
          
        }
        #endregion

        #region CRUD for User
        public void AddUser(User user)
        {
            if (DataS.users.Any(x => x.UserName == user.UserName))
                throw new DalAlreayExistExeption(" שם המשתמש" + user.UserName +"כבר קיים במערכת ");
            DataS.users.Add(user.Clone());
        }
        public User GetUser(string userName, string password)
        {
            User user = DataS.users.Find(x => x.UserName == userName&&x.Password==password);
            if(user==null)
                throw new KeyNotFoundException( " המשתמש" + userName + "לא קיים במערכת ");
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
                throw new KeyNotFoundException(" משתמש" + user.UserName + "לא קיים במערכת ");
            DataS.users.Remove(user1);
            DataS.users.Add(user.Clone());
        }
        public void DeleteUser(string userName, string password)
        {
            User TempUser = DataS.users.Find(x => x.UserName == userName&&x.Password==password);
            if(TempUser==null)
                throw new KeyNotFoundException(" המשתמש" + userName + "כבר לא קיים במערכת ");
            if (!DataS.users.Remove(TempUser))
                throw new CanNotRemoveException("לא מצליח להסיר את המשתמש");
        }
        #endregion

      public LineTrip GetLineTripBy(Predicate<LineTrip> predicate)
        {
           LineTrip lineTrips =(from item in DataS.lineTrips
                                                       where predicate(item)
                                                       select item.Clone()).FirstOrDefault();
            //if (lineTrips == null)
               // throw new DalEmptyCollectionExeption("לא קיימת יציאת קו העונה לדרישה ");
            return lineTrips;
        }
        public void AddLineTrip(LineTrip lineTrip)
        {
            DataS.lineTrips.Add(lineTrip.Clone());
        }

    }
}
