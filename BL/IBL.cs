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
        void sendToRefuel(Bus bus);
        void sendToTreat(Bus bus);
        
        
        void AddBus(Bus bus);
        Bus GetBus(string lisenceNum);
        void DeleteBus(string lisenceNum);
        void UpdateBus(Bus bus);
        
        void AddBusStation(BusStation busStation);
        BusLineBL GetBusLineBL(int Id);
        void DeleteBusStation(int code);
        void UpdateBusStation(BusStation busStation);
        
        void AddBusLine(BusLine busLine);
        BusStationBL GetBusStationBL(int code);
        void DeleteBusLine(int id);
        void UpdateBusLine(BusLine busLine);
    }
}
