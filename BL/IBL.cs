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
        void SendToRefuel(Bus bus);//v
        void SendToTreat(Bus bus);//v
        void UpdateFirstStation(int code, int busId);//v
        void UpdateLastStation(int code, int busId);//v
        IEnumerable<BusLineBL> GetPossiblePath(int startStationCode, int lastStationCode);//v
        BusLineBL ReturnShortPath(int startStationCode, int lastStationCode);//v
        float TimeBetweenStations(int startStationCode, int lastStationCode,int numLine);//v
        float Distance(int startStationCode, int destStationCode);//v
        LineTiming GetLineTiming(BusLineBL CurrentBusLineBL, BusStation CurrentBusStation);
        IEnumerable<LineTiming> GetLineTimingsAccordingLine(IEnumerable<BusLineBL> busLineBLs ,BO.BusStation CurrentBusStation);

        //נעמה
        void AddBus(Bus bus);//v
        Bus GetBus(string lisenceNum);//v
        void DeleteBus(string lisenceNum);//v
        void UpdateBus(Bus bus);//v
        IEnumerable<Bus> GetAllBuses();//v
        IEnumerable<Bus> GetAllBusesBy(Predicate<BO.Bus> condition);//v
        string setLicenseNumberTo(string licenseNumber);
        string setLicenseNumberFrom(string licenseNumber);
        //רננה
        void AddBusStation(BusStation busStation);//v
        BusStationBL ToBusStationBL(DO.BusStation busStationDO);//v
        void DeleteBusStation(int code);//v
        void UpdateBusStation(BusStation busStation);//v
        BusStationBL GetBusStationBL(int stationID);//v
        IEnumerable<BusStationBL> GetAllStations();//v
        IEnumerable<BusStationBL> GetAllStationsBy(Predicate<BO.BusStationBL> condition);//v
        StationInLine getStationInLine(int lineId, int stationCode);


        //נעמה
        void AddBusLine(BusLineBL busLine);//V
        BusLineBL ToBusLineBL(DO.BusLine busLineDO);//v
        void DeleteBusLine(BusLineBL busLine);//v 
        void UpdateBusLine(BusLine busLine);//v
        void AddStationToBus(StationInLine stationLine);//v
        BusLineBL GetBusLineBL(int busID);//v
        IEnumerable<BusLineBL> GetAllLines();//v
        IEnumerable<BusLineBL> GetAllLinesBy(Predicate<BO.BusLine> condition);//v

        //רננה
       void AddFollowingStations(FollowingStations following);
        FollowingStations GetFollowingStations(FollowingStations following);

        // void DeleteFollowingStations(FollowingStations following);
        // void UpdateBusFollowingStations(FollowingStations following);
        void DeleteStationInLine(StationInLine stationLine);//v
                                                            // void UpdateStationInLine(StationInLine stationLine);//v

        void addUser(string name, string password, bool isManager);
        string isAllowEntry(string name, string password);
    }
}
