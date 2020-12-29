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
        void AddBus(Bus bus);//v
        Bus GetBus(string lisenceNum);//v
        void DeleteBus(string lisenceNum);//v
        void UpdateBus(Bus bus);//v
        IEnumerable<Bus> GetAllBuses();//v
        IEnumerable<Bus> GetAllBusesBy(Predicate<BO.Bus> condition);//v
        //רננה
        void AddBusStation(BusStation busStation);//v
        BusStationBL ToBusStationBL(DO.BusStation busStationDO);//v
        void DeleteBusStation(int code);
        void UpdateBusStation(BusStation busStation);//v
        BusStationBL GetBusStationBL(int stationID);//v
        IEnumerable<BusStationBL> GetAllStations();
        IEnumerable<BusStationBL> GetAllStationsBy(Predicate<BO.BusStation> condition);


        //נעמה
        void AddBusLine(BusLineBL busLine);
        BusLineBL ToBusLineBL(DO.BusLine busLineDO);//v
        void DeleteBusLine(BusLineBL busLine);
        void UpdateBusLine(BusLine busLine);
        void AddStationToBus(StationInLine stationLine);
        BusLineBL GetBusLineBL(int busID);//v
        IEnumerable<BusLineBL> GetAllLines();
        IEnumerable<BusLineBL> GetAllLinesBy(Predicate<BO.BusLine> condition);

        //רננה
        void AddFollowingStations(FollowingStations following);
        void DeleteFollowingStations(FollowingStations following);
        void UpdateBusFollowingStations(FollowingStations following);
        void DeleteStationInLine(StationInLine stationLine);
        void UpdateStationInLine(StationInLine stationLine);
    }
}
