using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIDAL;
using DO;

namespace DL
{
    public class DLXML:IDAL
    {
        #region singelton
        static readonly DLXML instance = new DLXML();
        static DLXML() { }
        DLXML() { }
        public static DLXML Instance { get => instance; }
        #endregion

        string busesPath = @"busesXml.xml"; //XMLSerializer
        string busLinesPath = @"busLinesXml.xml"; //XMLSerializer
        string busStationsPath = @"busStationsXml.xml"; //XMLSerializer
        string followingStationsPath = @"followingStationsXml.xml"; //XMLSerializer
        string stationsInLinePath = @"stationsInLineXml.xml"; //XMLSerializer
        string users = @"usersXml.xml"; //XMLSerializer

        string LineTripsPath = @"LineTripsXml.xml"; //XElement

        #region  CRUD for Bus
        public void AddBus(Bus bus)
        {
            List<Bus> ListBuses = XMLTools.LoadListFromXMLSerializer<Bus>(busesPath);
            if (ListBuses.Any(x => x.LicenseNumber == bus.LicenseNumber))
                throw new DalAlreayExistExeption(" אוטובוס" + bus.LicenseNumber + "קיים כבר במערכת ");
            ListBuses.Add(bus); 

            XMLTools.SaveListToXMLSerializer(ListBuses, busesPath);
        }
        public Bus GetBus(string Id)
        {
            List<Bus> ListBuses = XMLTools.LoadListFromXMLSerializer<Bus>(busesPath);
            Bus tempBus = ListBuses.Find(x => x.LicenseNumber == Id);
            if (tempBus == null)
                throw new KeyNotFoundException(" אוטובוס" + Id + "לא קיים במערכת ");
            if (tempBus.IsDeleted == true)
                throw new KeyNotFoundException(" אוטובוס" + Id + "לא פעיל ");
            return tempBus;
        }
        public IEnumerable<Bus> GetBusCollection()
        {
            List<Bus> ListBuses = XMLTools.LoadListFromXMLSerializer<Bus>(busesPath);
            IEnumerable<Bus> TempBus = from Bus item in ListBuses
                                       where item.IsDeleted == false
                                       select item;
            if (TempBus.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים אוטובוסים פעילים במערכת");
            return TempBus;

        }
        public IEnumerable<Bus> GetAllBusesCollection()
        {
            List<Bus> ListBuses = XMLTools.LoadListFromXMLSerializer<Bus>(busesPath);
            IEnumerable<Bus> TempBus = from Bus item in ListBuses
                                       select item;
            if (TempBus.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים אוטובוסים במערכת");
            return TempBus;
        }
        public IEnumerable<Bus> GetBusCollectionBy(Predicate<Bus> condition)
        {
            List<Bus> ListBuses = XMLTools.LoadListFromXMLSerializer<Bus>(busesPath);
            IEnumerable<Bus> TempBus = from Bus item in ListBuses
                                       where condition(item) && item.IsDeleted == false
                                       select item;
            if (TempBus.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים אוטובוסים במערכת");
            return TempBus;
        }

        public void UpdateBus(Bus bus)
        {
            List<Bus> ListBuses = XMLTools.LoadListFromXMLSerializer<Bus>(busesPath);

            Bus TempBus = ListBuses.Find(x => x.LicenseNumber == bus.LicenseNumber);
            if (TempBus == null)
                throw new KeyNotFoundException(" אוטובוס" + bus.LicenseNumber + "לא קיים במערכת ");
            if (TempBus.IsDeleted)
                throw new KeyNotFoundException(" אוטובוס" + TempBus.LicenseNumber + "לא פעיל ");
            ListBuses.Remove(ListBuses.Find(x => x.LicenseNumber == bus.LicenseNumber));
            ListBuses.Add(bus);

            XMLTools.SaveListToXMLSerializer(ListBuses, busesPath);
        }
        public void DeleteBus(string liscenceNum)
        {
            List<Bus> ListBuses = XMLTools.LoadListFromXMLSerializer<Bus>(busesPath);
            Bus bus = ListBuses.Find(x => x.LicenseNumber == liscenceNum);
            if (bus == null)
                throw new KeyNotFoundException(" אוטובוס" + liscenceNum + "כבר לא קיים במערכת ");
            bus.IsDeleted = true;
            UpdateBus(bus);
        }
        #endregion

        #region CRUD for bus line
        public int AddBusLine(BusLine busLine)
        {
           
        }
        public BusLine GetBusLine(int busId)
        {
            
        }
        public IEnumerable<BusLine> GetBusLineCollection()
        {
           
        }
        public IEnumerable<BusLine> GetAllBusLinesCollection()
        {
            
        }
        public IEnumerable<BusLine> GetBusLineCollectionBy(Predicate<BusLine> condition)
        {
            
        }
        public void UpdateBusLine(BusLine busLine)
        {
           
        }
        public void DeleteBusLine(int busId)
        {
          
        }
        #endregion

        #region CRUD for bus station
        public void AddBusStation(BusStation busStation)
        {
           
        }
        public BusStation GetBusStation(int stationCode)
        {
            
        }
        public IEnumerable<BusStation> GetBusStationCollection()
        {
           
        }
        public IEnumerable<BusStation> GetAllBusStationsCollection()
        {
            
        }

        public IEnumerable<BusStation> GetBusStationCollectionBy(Predicate<BusStation> condition)
        {
            
        }

        public void UpdateBusStation(BusStation busStation)
        {
           
        }
        #endregion

        #region CRUD for following stations
        public void AddFollowingStations(FollowingStations followingStations)
        {
           
        }
        public FollowingStations GetFollowingStation(int stationCode1, int stationCode2)
        {
            
        }
        public IEnumerable<FollowingStations> GetFollowingStationsCollection()
        {
            
        }
        public IEnumerable<FollowingStations> GetFollowingStationsCollectionBy(Predicate<FollowingStations> condition)
        {
            
        }
        public void UpdateFollowingStations(FollowingStations followingStations)
        {
            
        }
        public void DeleteFollowingStations(FollowingStations followingStations)
        {
          
        }
        #endregion

        #region CRUD for station at line 
        public void AddStationInLine(stationInLine stationInLine)
        {
            
        }
        public stationInLine GetStationInLine(int lineId, int stationCode)
        {
            
        }
        public IEnumerable<stationInLine> GetStationInLineCollection()
        {
           
        }
        public IEnumerable<stationInLine> GetAllStationsInLineCollection()
        {
            
        }

        public IEnumerable<stationInLine> GetStationInLineCollectionBy(Predicate<stationInLine> condition)
        {
            
        }
        public void UpdateStationInLine(stationInLine stationInLine)
        {
           
        }
        public void DeleteStationInLine(stationInLine stationInLine)
        {
           
        }
        #endregion

        #region CRUD for User
        public void AddUser(User user)
        {
           
        }
        public User GetUser(string userName, string password)
        {
            
        }
        public IEnumerable<User> GetUsersCollection()
        {
            
        }
        public IEnumerable<User> GetUserCollectionBy(Predicate<User> condition)
        {
            
        }
        public void UpdateUser(User user)
        {
            
        }
        public void DeleteUser(string userName, string password)
        {
            
        }
        #endregion

        #region LineTrip
        public LineTrip GetLineTripBy(Predicate<LineTrip> predicate)
        {
            
        }
        public void AddLineTrip(LineTrip lineTrip)
        {
           
        }
        #endregion

    }
}
}
