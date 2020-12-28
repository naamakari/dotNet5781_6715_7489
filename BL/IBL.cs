using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace APIBL     
{
    public interface IBL
    {
        void SendToRefuel(Bus bus);
        void SendToTreat(Bus bus);
        void UpdateFirstStation(int code, int busId);
        void UpdateLastStation(int code, int busId);
        IEnumerable<BusLineBL> GetPossiblePath(int startStationCode, int lastStationCode);
        BusLineBL ReturnShortPath(int startStationCode, int lastStationCode);
        float TimeBetweenStations(int startStationCode, int lastStationCode,int numLine);
        float Distance(int startStationCode, int destStationCode);

        //נעמה
        void AddBus(Bus bus);
        Bus GetBus(string lisenceNum);//v
        void DeleteBus(string lisenceNum);
        void UpdateBus(Bus bus);
        IEnumerable<Bus> GetAllBuses();
        IEnumerable<Bus> GetAllBusesBy(Predicate<DO.Bus> condition);
        //רננה
        void AddBusStation(BusStation busStation);
        BusStationBL ToBusStationBL(DO.BusStation busStationDO);
        void DeleteBusStation(int code);
        void UpdateBusStation(BusStation busStation);
        BusStationBL GetBusStationBL(int stationID);
        IEnumerable<BusStationBL> GetAllStations();
        IEnumerable<BusStationBL> GetAllStationsBy(Predicate<DO.BusStation> condition);


        //נעמה
        void AddBusLine(BusLineBL busLine);
        BusLineBL ToBusLineBL(DO.BusLine busLineDO);
        void DeleteBusLine(BusLineBL busLine);
        void UpdateBusLine(BusLine busLine);
        void AddStationToBus(StationInLine stationLine);
        BusLineBL GetBusLineBL(int busID);
        IEnumerable<BusLineBL> GetAllLines();
        IEnumerable<BusLineBL> GetAllLinesBy(Predicate<DO.BusLine> condition);

        //רננה
        void AddFollowingStations(FollowingStations following);
        void DeleteFollowingStations(FollowingStations following);
        void UpdateBusFollowingStations(FollowingStations following);

        
        void DeleteStationInLine(StationInLine stationLine);
        void UpdateStationInLine(StationInLine stationLine);
    }
}
