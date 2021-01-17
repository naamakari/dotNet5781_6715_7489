using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace APIDAL
{
    public interface IDAL
    {

        /// <summary>
        /// CRUD for Bus
        /// </summary>
        void AddBus(Bus bus);
        Bus GetBus(string lisceneNumber);
        IEnumerable<Bus> GetBusCollection();
        IEnumerable<Bus> GetAllBusesCollection();
        IEnumerable<Bus> GetBusCollectionBy(Predicate<Bus> predicate);
        void UpdateBus(Bus bus);
        void DeleteBus(string lisenceNum);

        /// <summary>
        /// CRUD for bus line
        /// </summary>
        int AddBusLine(BusLine busLine);
        BusLine GetBusLine(int busId);
        IEnumerable<BusLine> GetBusLineCollection();
        IEnumerable<BusLine> GetAllBusLinesCollection();
        IEnumerable<BusLine> GetBusLineCollectionBy(Predicate<BusLine> predicate);
        void UpdateBusLine(BusLine busLine);
        void DeleteBusLine(int busId);

        /// <summary>
        /// CRUD for bus station
        /// </summary>

        void AddBusStation(BusStation busStation);
        BusStation GetBusStation(int stationCode);
        IEnumerable<BusStation> GetBusStationCollection();
        IEnumerable<BusStation> GetAllBusStationsCollection();
        IEnumerable<BusStation> GetBusStationCollectionBy(Predicate<BusStation> predicate);
        void UpdateBusStation(BusStation busStation);
        void DeleteBusStation(int busStationCode);

        /// <summary>
        /// CRUD for following stations
        /// </summary>
        void AddFollowingStations(FollowingStations followingStations);
        FollowingStations GetFollowingStation(int stationCode1, int stationCode2);
        IEnumerable<FollowingStations> GetFollowingStationsCollection();
        IEnumerable<FollowingStations> GetFollowingStationsCollectionBy(Predicate<FollowingStations> predicate);

        void UpdateFollowingStations(FollowingStations followingStations);
        void DeleteFollowingStations(FollowingStations followingStations);

        /// <summary>
        /// CRUD for station at line 
        /// </summary>
        void AddStationInLine(stationInLine stationInLine);
        stationInLine GetStationInLine(int lineId, int stationCode);
        IEnumerable<stationInLine> GetStationInLineCollection();
        IEnumerable<stationInLine> GetAllStationsInLineCollection();
        IEnumerable<stationInLine> GetStationInLineCollectionBy(Predicate<stationInLine> predicate);
        void UpdateStationInLine(stationInLine stationInLine);
        void DeleteStationInLine(stationInLine stationInLine);

        /// <summary>
        /// CRUD for user
        /// </summary>
        void AddUser(User user);
        User GetUser(string userName, string password);
        IEnumerable<User> GetUsersCollection();
        IEnumerable<User> GetUserCollectionBy(Predicate<User> predicate);
        void UpdateUser(User user);
        void DeleteUser(string userName, string password);

        LineTrip GetLineTripBy(Predicate<LineTrip> predicate);
        void AddLineTrip(LineTrip lineTrip);
       IEnumerable<LineTrip> getLineTripsBy(Predicate<LineTrip> condition);
        void deleteLineTrip(LineTrip lineTrip);

        
    }
}
    