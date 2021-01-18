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
         void ReturnFromRefuel(Bus bus);

        void SendToTreat(Bus bus);
        void ReturnFromTreat(Bus bus);

        void UpdateFirstStation(int code, int busId);
        void UpdateLastStation(int code, int busId);
        IEnumerable<BusLineBL> GetPossiblePath(int startStationCode, int lastStationCode);
        bool ifFirstRealyFirstAndLastRealyLast(DO.BusLine busLine1, DO.BusLine busLine2, int firstStation, int lastStation);

        BusLineBL ReturnShortPath(int startStationCode, int lastStationCode);
        float TimeBetweenStations(int startStationCode, int lastStationCode,int numLine);
        float Distance(int startStationCode, int destStationCode);//v
        LineTiming GetLineTiming(BusLineBL CurrentBusLineBL, BusStation CurrentBusStation, BO.BusStation LastCurrentBusStation);
        IEnumerable<LineTiming> GetLineTimingsAccordingLine(IEnumerable<BusLineBL> busLineBLs ,BO.BusStation CurrentBusStation, BO.BusStation LastCurrentBusStation);

        void AddBus(Bus bus);
        Bus GetBus(string lisenceNum);
        void DeleteBus(string lisenceNum);
        void UpdateBus(Bus bus);
        IEnumerable<Bus> GetAllBuses();
        IEnumerable<Bus> GetAllBusesBy(Predicate<BO.Bus> condition);
        string setLicenseNumberTo(string licenseNumber);
        string setLicenseNumberFrom(string licenseNumber);
        void AddBusStation(BusStation busStation);
        BusStationBL ToBusStationBL(DO.BusStation busStationDO);
        void DeleteBusStation(int code);
        void UpdateBusStation(BusStation busStation);
        BusStationBL GetBusStationBL(int stationID);
        IEnumerable<BusStationBL> GetAllStations();
        IEnumerable<BusStationBL> GetAllStationsBy(Predicate<BO.BusStationBL> condition);
        StationInLine getStationInLine(int lineId, int stationCode);

        int AddBusLine(BusLineBL busLine);
        BusLineBL ToBusLineBL(DO.BusLine busLineDO);
        void DeleteBusLine(BusLineBL busLine);
        void UpdateBusLine(BusLine busLine);
        void AddStationToBus(StationInLine stationLine);
        BusLineBL GetBusLineBL(int busID);
        IEnumerable<BusLineBL> GetAllLines();
        IEnumerable<BusLineBL> GetAllLinesBy(Predicate<BO.BusLine> condition);

       void AddFollowingStations(FollowingStations following);
        FollowingStations GetFollowingStations(FollowingStations following);
        void deleteFollowingStations(int statioCode);

        void DeleteStationInLine(StationInLine stationLine);

        void addUser(string name, string password, bool isManager);
        BO.Permission isAllowEntry(string name, string password);

        void AddLineTrip(Frequency frequency, int lineId, int numLine);
        void UpdateLineTrip(Frequency frequency, int lineId, int numLine);
    }
}
