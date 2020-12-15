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
        void UpdateBus(Bus bus);
        void DeleteBus(Bus bus);

        /// <summary>
        /// CRUD for bus line
        /// </summary>
        void AddBusLine(BusLine busLine);
        BusLine GetBusLine(int busId);
        IEnumerable<BusLine> GetBusLineCollection();
        IEnumerable<BusLine> GetBusLineCollection(int StationCode);
        void UpdateBusLine(BusLine busLine);
        void DeleteBusLine(BusLine busLine);

        /// <summary>
        /// CRUD for bus station
        /// </summary>
        
        void AddBusStation(BusStation busStation);
        BusStation GetBusStation(int stationCode);
        IEnumerable<BusStation> GetBusStationCollection();
        void UpdateBusStation(BusStation busStation);
        void DeleteBusStation(BusStation busStation);

        /// <summary>
        /// CRUD for following stations
        /// </summary>
        void AddFollowingStations(FollowingStations followingStations);
        FollowingStations GetFollowingStation(int stationCode1,int stationCode2);
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
    