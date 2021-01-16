using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
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
        string usersPath = @"usersXml.xml"; //XMLSerializer

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
            //List<Bus> buses = new List<Bus>();
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111111",
            //    StartDate = new DateTime(2017, 1, 1),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 4, 1)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "2222222",
            //    StartDate = new DateTime(2017, 1, 2),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 1, 1)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "3333333",
            //    StartDate = new DateTime(2017, 3, 1),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 1, 1)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111112",
            //    StartDate = new DateTime(2017, 1, 4),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 3, 1)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111113",
            //    StartDate = new DateTime(2017, 1, 5),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 1, 5)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111145",
            //    StartDate = new DateTime(2017, 6, 1),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 6, 1)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111167",
            //    StartDate = new DateTime(2017, 1, 7),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 7, 1)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111189",
            //    StartDate = new DateTime(2017, 1, 8),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 1, 8)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1101111",
            //    StartDate = new DateTime(2017, 9, 1),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 1, 7)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111312",
            //    StartDate = new DateTime(2017, 10, 1),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 10, 1)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111415",
            //    StartDate = new DateTime(2017, 1, 1),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 11, 1)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111617",
            //    StartDate = new DateTime(2017, 1, 2),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 12, 1)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111819",
            //    StartDate = new DateTime(2017, 10, 1),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 4, 1)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111120",
            //    StartDate = new DateTime(2017, 1, 2),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 11, 4)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111121",
            //    StartDate = new DateTime(2017, 1, 4),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 12, 4)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111122",
            //    StartDate = new DateTime(2017, 3, 1),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 4, 10)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111123",
            //    StartDate = new DateTime(2017, 7, 14),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 4, 13)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111124",
            //    StartDate = new DateTime(2017, 1, 15),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 4, 14)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111125",
            //    StartDate = new DateTime(2017, 1, 16),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 4, 15)
            //});
            //buses.Add(new Bus()
            //{
            //    LicenseNumber = "1111126",
            //    StartDate = new DateTime(2017, 1, 2),
            //    Kilometraz = 8000,
            //    KmSinceRefeul = 500,
            //    BusState = BusStatus.ready,
            //    IsDeleted = false,
            //    KmSinceLastTreat = 2000,
            //    DateSinceLastTreat = new DateTime(2020, 4, 16)
            //});
            //XMLTools.SaveListToXMLSerializer(buses, busesPath);



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
            XMLTools.SaveListToXMLSerializer(ListBuses, busesPath);
        }
        #endregion

        #region CRUD for bus line
        public int AddBusLine(BusLine busLine)
        {
            List<BusLine> ListBusLines = XMLTools.LoadListFromXMLSerializer<BusLine>(busLinesPath);

            XElement helpXelement = XElement.Load(@"configurationXml.xml");
            busLine.BusId =int.Parse(helpXelement.Element("BusLineRunNum").Value);

            int kidum = int.Parse(helpXelement.Element("BusLineRunNum").Value);
            kidum+=11;
            helpXelement.Element("BusLineRunNum").Value = kidum.ToString();
            helpXelement.Save(@"configurationXml.xml");


            //צריך את הבדיקה הזו?
            //if (ListBusLines.Any(x => x.BusId == busLine.BusId))
               // throw new DalAlreayExistExeption(" קו אוטובוס מספר" + busLine.BusId + "קיים כבר במערכת ");
            ListBusLines.Add(busLine);

            XMLTools.SaveListToXMLSerializer(ListBusLines, busLinesPath);
            return busLine.BusId;
        }
        public BusLine GetBusLine(int busId)
        {
            List<BusLine> ListBusLines = XMLTools.LoadListFromXMLSerializer<BusLine>(busLinesPath);
            BusLine tempBusLine = ListBusLines.Find(x => x.BusId == busId);
            if (tempBusLine == null)
                throw new KeyNotFoundException(" קו אוטובוס מספר" + busId + "לא קיים במערכת ");
            if (tempBusLine.IsDeleted == true)
                throw new KeyNotFoundException(" קו אוטובוס מספר" + busId + "לא פעיל ");
            return tempBusLine;

        }
        public void RunBusLine(int number)
        {
            XElement helpXelement = XElement.Load(@"configurationXml.xml");
            int kidum = number;
            kidum += 11;
            helpXelement.Element("BusLineRunNum").Value = kidum.ToString();
            helpXelement.Save(@"configurationXml.xml");
        }

        public IEnumerable<BusLine> GetBusLineCollection()
        {
            // List<BusLine> busLines = new List<BusLine>();
            //XElement helpXelement = XElement.Load(@"configurationXml.xml");

            //busLines.Add(new BusLine() { BusId = int.Parse(helpXelement.Element("BusLineRunNum").Value), BusNumLine = 1, AreaAtLand = Area.Center, NumberFirstStation = 1111, NumberLastStation = 1120, IsDeleted = false });
            //RunBusLine(int.Parse(helpXelement.Element("BusLineRunNum").Value));
            //busLines.Add(new BusLine() { BusId = int.Parse(helpXelement.Element("BusLineRunNum").Value), BusNumLine = 2, AreaAtLand = Area.South, NumberFirstStation = 1123, NumberLastStation = 1135, IsDeleted = false });
            //RunBusLine(int.Parse(helpXelement.Element("BusLineRunNum").Value));
            //busLines.Add(new BusLine() { BusId = int.Parse(helpXelement.Element("BusLineRunNum").Value), BusNumLine = 3, AreaAtLand = Area.South, NumberFirstStation = 1123, NumberLastStation = 1135, IsDeleted = false });
            //RunBusLine(int.Parse(helpXelement.Element("BusLineRunNum").Value));
            //busLines.Add(new BusLine() { BusId = int.Parse(helpXelement.Element("BusLineRunNum").Value), BusNumLine = 418, AreaAtLand = Area.General, NumberFirstStation = 1123, NumberLastStation = 1122, IsDeleted = false });
            //RunBusLine(int.Parse(helpXelement.Element("BusLineRunNum").Value));
            //busLines.Add(new BusLine() { BusId = int.Parse(helpXelement.Element("BusLineRunNum").Value), BusNumLine = 415, AreaAtLand = Area.General, NumberFirstStation = 1111, NumberLastStation = 1123, IsDeleted = false });
            //RunBusLine(int.Parse(helpXelement.Element("BusLineRunNum").Value));

            //busLines.Add(new BusLine() { BusId = int.Parse(helpXelement.Element("BusLineRunNum").Value), BusNumLine = 8, AreaAtLand = Area.North, NumberFirstStation = 1137, NumberLastStation = 1147, IsDeleted = false });
            //RunBusLine(int.Parse(helpXelement.Element("BusLineRunNum").Value));
            //busLines.Add(new BusLine() { BusId = int.Parse(helpXelement.Element("BusLineRunNum").Value), BusNumLine = 13, AreaAtLand = Area.North, NumberFirstStation = 1147, NumberLastStation = 1138, IsDeleted = false });
            //RunBusLine(int.Parse(helpXelement.Element("BusLineRunNum").Value));
            //busLines.Add(new BusLine() { BusId = int.Parse(helpXelement.Element("BusLineRunNum").Value), BusNumLine = 5, AreaAtLand = Area.Center, NumberFirstStation = 1161, NumberLastStation = 1153, IsDeleted = false });
            //RunBusLine(int.Parse(helpXelement.Element("BusLineRunNum").Value));
            //busLines.Add(new BusLine() { BusId = int.Parse(helpXelement.Element("BusLineRunNum").Value), BusNumLine = 836, AreaAtLand = Area.General, NumberFirstStation = 1159, NumberLastStation = 1138, IsDeleted = false });
            //RunBusLine(int.Parse(helpXelement.Element("BusLineRunNum").Value));
            //busLines.Add(new BusLine() { BusId = int.Parse(helpXelement.Element("BusLineRunNum").Value), BusNumLine = 836, AreaAtLand = Area.General, NumberFirstStation = 1138, NumberLastStation = 1159, IsDeleted = false });
            //RunBusLine(int.Parse(helpXelement.Element("BusLineRunNum").Value));
            //XMLTools.SaveListToXMLSerializer(busLines, busLinesPath);


            List<BusLine> ListBusLines = XMLTools.LoadListFromXMLSerializer<BusLine>(busLinesPath);

            IEnumerable<BusLine> TempBusLine = from BusLine item in ListBusLines
                                               where item.IsDeleted == false
                                               select item;
            if (TempBusLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים קווי אוטובוס פעילים במערכת");
            return TempBusLine;
        }
        public IEnumerable<BusLine> GetAllBusLinesCollection()
        {
            List<BusLine> ListBusLines = XMLTools.LoadListFromXMLSerializer<BusLine>(busLinesPath);

            IEnumerable<BusLine> TempBusLine = from BusLine item in ListBusLines
                                               select item;
            if (TempBusLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים קווי אוטובוס במערכת");
            return TempBusLine;
        }
        public IEnumerable<BusLine> GetBusLineCollectionBy(Predicate<BusLine> condition)
        {
            List<BusLine> ListBusLines = XMLTools.LoadListFromXMLSerializer<BusLine>(busLinesPath);

            IEnumerable<BusLine> TempBusLine = from BusLine item in ListBusLines
                                               where condition(item) && item.IsDeleted == false
                                               select item;
            if (TempBusLine.Count() == 0)
                throw new DalEmptyCollectionExeption(" לא קיימים קווי אוטובוס במערכת שעונים לתנאי המבוקש");
            return TempBusLine;
        }
        public void UpdateBusLine(BusLine busLine)
        {
            List<BusLine> ListBusLines = XMLTools.LoadListFromXMLSerializer<BusLine>(busLinesPath);

            BusLine TempBusLine = ListBusLines.Find(x => x.BusId == busLine.BusId);
            if (TempBusLine == null)
                throw new KeyNotFoundException(" קו אוטובוס מספר" + busLine.BusId + "לא קיים במערכת ");
            if (TempBusLine.IsDeleted)
                throw new KeyNotFoundException(" אוטובוס" + TempBusLine.BusId + "לא פעיל ");
            ListBusLines.Remove(TempBusLine);
            ListBusLines.Add(busLine);
            XMLTools.SaveListToXMLSerializer(ListBusLines, busLinesPath);

        }
        public void DeleteBusLine(int busId)
        {
            List<BusLine> ListBusLines = XMLTools.LoadListFromXMLSerializer<BusLine>(busLinesPath);

            BusLine tempBusLine = ListBusLines.Find(x => x.BusId == busId);
            if (tempBusLine == null)
                throw new KeyNotFoundException(" קו אוטובוס מספר" + busId + "כבר לא קיים במערכת ");
            tempBusLine.IsDeleted = true;
            XMLTools.SaveListToXMLSerializer(ListBusLines, busLinesPath);
        }
        #endregion

        #region CRUD for bus station
        public void AddBusStation(BusStation busStation)
        {
            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationsPath);

            XElement helpXelement = XElement.Load(@"configurationXml.xml");
            busStation.StationCode = int.Parse(helpXelement.Element("BusStationRunNum").Value);

            int kidum = int.Parse(helpXelement.Element("BusStationRunNum").Value);
            kidum+=7;
            helpXelement.Element("BusStationRunNum").Value = kidum.ToString();
            helpXelement.Save(@"configurationXml.xml");

            //צריך את הבדיקה הזו?
            //if (ListBusStation.Any(x => x.StationCode == busStation.StationCode))
              //  throw new DalAlreayExistExeption(" תחנה מספר" + busStation.StationCode + "קיימת כבר במערכת ");
            ListBusStation.Add(busStation);
            XMLTools.SaveListToXMLSerializer(ListBusStation, busStationsPath);

        }
        public BusStation GetBusStation(int stationCode)
        {
            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationsPath);
            BusStation tempBusStation = ListBusStation.Find(x => x.StationCode == stationCode);
            if (tempBusStation == null)
                throw new KeyNotFoundException(" תחנה מספר" + stationCode + "לא קיימת במערכת ");
            if (tempBusStation.IsDeleted == true)
                throw new KeyNotFoundException(" תחנה מספר" + stationCode + "לא פעילה ");
            return tempBusStation;
        }
        public IEnumerable<BusStation> GetBusStationCollection()
        {
            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationsPath);
            IEnumerable<BusStation> TempBusStation = from BusStation item in ListBusStation
                                                     where item.IsDeleted == false
                                                     select item;
            if (TempBusStation.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות אוטובוס פעילות במערכת");
            return TempBusStation;
        }
        public IEnumerable<BusStation> GetAllBusStationsCollection()
        {
            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationsPath);
            IEnumerable<BusStation> TempBusStation = from BusStation item in ListBusStation
                                                     select item;
            if (TempBusStation.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות אוטובוס במערכת");
            return TempBusStation;
        }

        public IEnumerable<BusStation> GetBusStationCollectionBy(Predicate<BusStation> condition)
        {
            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationsPath);
            IEnumerable<BusStation> TempBusStation = from BusStation item in ListBusStation
                                                     where condition(item) && item.IsDeleted == false
                                                     select item;
            if (TempBusStation.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות אוטובוס במערכת");
            return TempBusStation;
        }

        public void UpdateBusStation(BusStation busStation)
        {
            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationsPath);
            BusStation TempBusStation = ListBusStation.Find(x => x.StationCode == busStation.StationCode);
            if (TempBusStation == null)
                throw new KeyNotFoundException(" תחנה מספר" + busStation.StationCode + "לא קיימת במערכת ");
            if (TempBusStation.IsDeleted)
                throw new KeyNotFoundException(" תחנה" + busStation.StationCode + "לא פעילה ");
            ListBusStation.Remove(ListBusStation.Find(x => x.StationCode == busStation.StationCode));
            ListBusStation.Add(busStation);
            XMLTools.SaveListToXMLSerializer(ListBusStation, busStationsPath);

        }
        public void DeleteBusStation(int busStationCode)
        {
            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationsPath);
            BusStation busStation = ListBusStation.Find(x => x.StationCode == busStationCode);
            if (busStation == null)
                throw new KeyNotFoundException(" תחנה מספר" + busStationCode + "כבר לא קיימת במערכת ");
            busStation.IsDeleted = true;
            XMLTools.SaveListToXMLSerializer(ListBusStation, busStationsPath);

        }
        #endregion

        #region CRUD for following stations
        public void AddFollowingStations(FollowingStations followingStations)
        {
            List<FollowingStations> ListFollowingStations = XMLTools.LoadListFromXMLSerializer<FollowingStations>(followingStationsPath);
            if (ListFollowingStations.Any(x => x.StationCode1 == followingStations.StationCode1 && x.StationCode2 == followingStations.StationCode2))
                return;//It does not matter to the user if there are a couple of such stations but we do not need to add
            ListFollowingStations.Add(followingStations);
            XMLTools.SaveListToXMLSerializer(ListFollowingStations, followingStationsPath);

        }
        public FollowingStations GetFollowingStation(int stationCode1, int stationCode2)
        {
            List<FollowingStations> ListFollowingStations = XMLTools.LoadListFromXMLSerializer<FollowingStations>(followingStationsPath);
            FollowingStations followingStationsTemp = ListFollowingStations.Find(x => x.StationCode1 == stationCode1 && x.StationCode2 == stationCode2);
            if (followingStationsTemp == null)
                throw new DalAlreayExistFollowingStationsExeption(" תחנות עוקבות אלו " + stationCode1 + " , " + stationCode2 + "לא קיימות במערכת ");
            return followingStationsTemp;
        }
        public IEnumerable<FollowingStations> GetFollowingStationsCollection()
        {
        //   List<FollowingStations> followingStations = new List<FollowingStations>();

        //followingStations.Add(new FollowingStations { StationCode1 = 1111, StationCode2 = 1112, DistanceBetweenStations = (float)0.95, TimeTravelBetweenStations = (float)0.95 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1112, StationCode2 = 1113, DistanceBetweenStations = (float)0.29, TimeTravelBetweenStations = (float)0.29 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1113, StationCode2 = 1114, DistanceBetweenStations = (float)0.52, TimeTravelBetweenStations = (float)0.52 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1114, StationCode2 = 1115, DistanceBetweenStations = (float)1.43, TimeTravelBetweenStations = (float)1.43 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1115, StationCode2 = 1116, DistanceBetweenStations = (float)0.11, TimeTravelBetweenStations = (float)0.11 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1116, StationCode2 = 1117, DistanceBetweenStations = (float)0.36, TimeTravelBetweenStations = (float)0.36 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1117, StationCode2 = 1118, DistanceBetweenStations = (float)0.62, TimeTravelBetweenStations = (float)0.62 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1118, StationCode2 = 1119, DistanceBetweenStations = (float)0.1, TimeTravelBetweenStations = (float)0.1 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1119, StationCode2 = 1120, DistanceBetweenStations = (float)0.18, TimeTravelBetweenStations = (float)0.18 });

        //    followingStations.Add(new FollowingStations { StationCode1 = 1123, StationCode2 = 1124, DistanceBetweenStations = (float)1.62, TimeTravelBetweenStations = (float)1.62 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1124, StationCode2 = 1125, DistanceBetweenStations = (float)0.58, TimeTravelBetweenStations = (float)0.58 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1125, StationCode2 = 1126, DistanceBetweenStations = (float)0.51, TimeTravelBetweenStations = (float)0.51 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1126, StationCode2 = 1127, DistanceBetweenStations = (float)0.57, TimeTravelBetweenStations = (float)0.57 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1127, StationCode2 = 1128, DistanceBetweenStations = (float)0.45, TimeTravelBetweenStations = (float)0.45 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1128, StationCode2 = 1129, DistanceBetweenStations = (float)0.6, TimeTravelBetweenStations = (float)0.6 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1129, StationCode2 = 1131, DistanceBetweenStations = (float)0.59, TimeTravelBetweenStations = (float)0.59 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1131, StationCode2 = 1133, DistanceBetweenStations = (float)1.93, TimeTravelBetweenStations = (float)1.93 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1133, StationCode2 = 1135, DistanceBetweenStations = (float)0.38, TimeTravelBetweenStations = (float)0.38 });

        //    followingStations.Add(new FollowingStations { StationCode1 = 1125, StationCode2 = 1126, DistanceBetweenStations = (float)0.51, TimeTravelBetweenStations = (float)0.51 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1126, StationCode2 = 1128, DistanceBetweenStations = (float)1.01, TimeTravelBetweenStations = (float)1.01 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1128, StationCode2 = 1130, DistanceBetweenStations = (float)0.85, TimeTravelBetweenStations = (float)0.85 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1130, StationCode2 = 1132, DistanceBetweenStations = (float)1.07, TimeTravelBetweenStations = (float)1.07 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1132, StationCode2 = 1133, DistanceBetweenStations = (float)2.07, TimeTravelBetweenStations = (float)2.07 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1133, StationCode2 = 1134, DistanceBetweenStations = (float)0.17, TimeTravelBetweenStations = (float)0.17 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1134, StationCode2 = 1135, DistanceBetweenStations = (float)0.21, TimeTravelBetweenStations = (float)0.21 });



        //    followingStations.Add(new FollowingStations { StationCode1 = 1126, StationCode2 = 1117, DistanceBetweenStations = (float)111.91, TimeTravelBetweenStations = (float)111.91 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1120, StationCode2 = 1121, DistanceBetweenStations = (float)0.41, TimeTravelBetweenStations = (float)0.41 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1121, StationCode2 = 1122, DistanceBetweenStations = (float)0.38, TimeTravelBetweenStations = (float)0.38 });



        //    followingStations.Add(new FollowingStations { StationCode1 = 1114, StationCode2 = 1125, DistanceBetweenStations = (float)112.15, TimeTravelBetweenStations = (float)112.15 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1125, StationCode2 = 1130, DistanceBetweenStations = (float)1.40, TimeTravelBetweenStations = (float)1.40 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1130, StationCode2 = 1135, DistanceBetweenStations = (float)1.61, TimeTravelBetweenStations = (float)1.61 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1135, StationCode2 = 1132, DistanceBetweenStations = (float)1.96, TimeTravelBetweenStations = (float)1.96 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1132, StationCode2 = 1124, DistanceBetweenStations = (float)3.27, TimeTravelBetweenStations = (float)3.27 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1124, StationCode2 = 1123, DistanceBetweenStations = (float)0.57, TimeTravelBetweenStations = (float)0.57 });


        //    followingStations.Add(new FollowingStations { StationCode1 = 1137, StationCode2 = 1136, DistanceBetweenStations = (float)0.69, TimeTravelBetweenStations = (float)0.69 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1136, StationCode2 = 1139, DistanceBetweenStations = (float)0.75, TimeTravelBetweenStations = (float)0.75 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1139, StationCode2 = 1140, DistanceBetweenStations = (float)0.41, TimeTravelBetweenStations = (float)0.41 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1140, StationCode2 = 1141, DistanceBetweenStations = (float)1.13, TimeTravelBetweenStations = (float)1.13 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1141, StationCode2 = 1142, DistanceBetweenStations = (float)0.84, TimeTravelBetweenStations = (float)0.84 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1142, StationCode2 = 1143, DistanceBetweenStations = (float)0.72, TimeTravelBetweenStations = (float)0.72 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1143, StationCode2 = 1144, DistanceBetweenStations = (float)1.66, TimeTravelBetweenStations = (float)1.66 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1144, StationCode2 = 1145, DistanceBetweenStations = (float)1.62, TimeTravelBetweenStations = (float)1.62 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1145, StationCode2 = 1146, DistanceBetweenStations = (float)1.81, TimeTravelBetweenStations = (float)1.81 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1146, StationCode2 = 1147, DistanceBetweenStations = (float)0.38, TimeTravelBetweenStations = (float)0.38 });


        //    followingStations.Add(new FollowingStations { StationCode1 = 1147, StationCode2 = 1148, DistanceBetweenStations = (float)1.18, TimeTravelBetweenStations = (float)1.18 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1148, StationCode2 = 1149, DistanceBetweenStations = (float)0.74, TimeTravelBetweenStations = (float)0.74 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1149, StationCode2 = 1145, DistanceBetweenStations = (float)2.01, TimeTravelBetweenStations = (float)2.01 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1145, StationCode2 = 1144, DistanceBetweenStations = (float)2.37, TimeTravelBetweenStations = (float)2.37 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1144, StationCode2 = 1142, DistanceBetweenStations = (float)2.2, TimeTravelBetweenStations = (float)2.2 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1142, StationCode2 = 1150, DistanceBetweenStations = (float)2.93, TimeTravelBetweenStations = (float)2.93 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1150, StationCode2 = 1136, DistanceBetweenStations = (float)3.67, TimeTravelBetweenStations = (float)3.67 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1136, StationCode2 = 1137, DistanceBetweenStations = (float)0.69, TimeTravelBetweenStations = (float)0.69 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1137, StationCode2 = 1138, DistanceBetweenStations = (float)1.12, TimeTravelBetweenStations = (float)1.12 });

        //    followingStations.Add(new FollowingStations { StationCode1 = 1161, StationCode2 = 1160, DistanceBetweenStations = (float)2.03, TimeTravelBetweenStations = (float)2.03 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1160, StationCode2 = 1151, DistanceBetweenStations = (float)1.03, TimeTravelBetweenStations = (float)1.03 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1151, StationCode2 = 1152, DistanceBetweenStations = (float)1.23, TimeTravelBetweenStations = (float)1.23 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1152, StationCode2 = 1158, DistanceBetweenStations = (float)2.24, TimeTravelBetweenStations = (float)2.24 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1158, StationCode2 = 1157, DistanceBetweenStations = (float)1.03, TimeTravelBetweenStations = (float)1.03 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1157, StationCode2 = 1155, DistanceBetweenStations = (float)0.7, TimeTravelBetweenStations = (float)0.7 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1155, StationCode2 = 1156, DistanceBetweenStations = (float)0.67, TimeTravelBetweenStations = (float)0.67 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1156, StationCode2 = 1154, DistanceBetweenStations = (float)1.5, TimeTravelBetweenStations = (float)1.5 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1154, StationCode2 = 1153, DistanceBetweenStations = (float)1.06, TimeTravelBetweenStations = (float)1.06 });


        //    followingStations.Add(new FollowingStations { StationCode1 = 1159, StationCode2 = 1160, DistanceBetweenStations = (float)0.43, TimeTravelBetweenStations = (float)0.43 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1160, StationCode2 = 1151, DistanceBetweenStations = (float)1.03, TimeTravelBetweenStations = (float)1.03 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1151, StationCode2 = 1161, DistanceBetweenStations = (float)0.96, TimeTravelBetweenStations = (float)0.96 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1161, StationCode2 = 1142, DistanceBetweenStations = (float)130.48, TimeTravelBetweenStations = (float)130.48 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1142, StationCode2 = 1144, DistanceBetweenStations = (float)1.47, TimeTravelBetweenStations = (float)1.47 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1144, StationCode2 = 1141, DistanceBetweenStations = (float)1.85, TimeTravelBetweenStations = (float)1.85 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1141, StationCode2 = 1140, DistanceBetweenStations = (float)0.84, TimeTravelBetweenStations = (float)0.84 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1140, StationCode2 = 1136, DistanceBetweenStations = (float)0.68, TimeTravelBetweenStations = (float)0.68 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1136, StationCode2 = 1138, DistanceBetweenStations = (float)1.64, TimeTravelBetweenStations = (float)1.64 });

        //    followingStations.Add(new FollowingStations { StationCode1 = 1138, StationCode2 = 1136, DistanceBetweenStations = (float)1.78, TimeTravelBetweenStations = (float)1.78 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1136, StationCode2 = 1140, DistanceBetweenStations = (float)0.73, TimeTravelBetweenStations = (float)0.73 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1141, StationCode2 = 1144, DistanceBetweenStations = (float)1.61, TimeTravelBetweenStations = (float)1.61 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1144, StationCode2 = 1142, DistanceBetweenStations = (float)2.20, TimeTravelBetweenStations = (float)2.20 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1142, StationCode2 = 1161, DistanceBetweenStations = (float)129.82, TimeTravelBetweenStations = (float)129.82 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1161, StationCode2 = 1151, DistanceBetweenStations = (float)1.62, TimeTravelBetweenStations = (float)1.62 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1151, StationCode2 = 1160, DistanceBetweenStations = (float)1.30, TimeTravelBetweenStations = (float)1.30 });
        //    followingStations.Add(new FollowingStations { StationCode1 = 1160, StationCode2 = 1159, DistanceBetweenStations = (float)0.62, TimeTravelBetweenStations = (float)0.62 });
        //    XMLTools.SaveListToXMLSerializer(followingStations, followingStationsPath);





            List<FollowingStations> ListFollowingStations = XMLTools.LoadListFromXMLSerializer<FollowingStations>(followingStationsPath);
            IEnumerable<FollowingStations> TempFollowingStations = from FollowingStations item in ListFollowingStations
                                                                   select item;
            if (TempFollowingStations.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות עוקבות במערכת");
            return TempFollowingStations;
        }
        public IEnumerable<FollowingStations> GetFollowingStationsCollectionBy(Predicate<FollowingStations> condition)
        {
            List<FollowingStations> ListFollowingStations = XMLTools.LoadListFromXMLSerializer<FollowingStations>(followingStationsPath);
            IEnumerable<FollowingStations> TempFollowingStations = from FollowingStations item in ListFollowingStations
                                                                   where condition(item)
                                                                   select item;
            if (TempFollowingStations.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות עוקבות במערכת שעונות לתנאי המבוקש");
            return TempFollowingStations;
        }
        public void UpdateFollowingStations(FollowingStations followingStations)
        {
            List<FollowingStations> ListFollowingStations = XMLTools.LoadListFromXMLSerializer<FollowingStations>(followingStationsPath);
            FollowingStations followingStations1 = ListFollowingStations.Find(x => x.StationCode1 == followingStations.StationCode1 && x.StationCode2 == followingStations.StationCode2);
            if (followingStations1 == null)
                throw new KeyNotFoundException(" תחנות עוקבות אלו " + followingStations.StationCode1 + " , " + followingStations.StationCode2 + "לא קיימות במערכת ");
            ListFollowingStations.Remove(followingStations1);
            ListFollowingStations.Add(followingStations);

            XMLTools.SaveListToXMLSerializer(ListFollowingStations, followingStationsPath);

        }
        public void DeleteFollowingStations(FollowingStations followingStations)
        {
            List<FollowingStations> ListFollowingStations = XMLTools.LoadListFromXMLSerializer<FollowingStations>(followingStationsPath);
            FollowingStations tempFollowingStations = ListFollowingStations.Find(x => x.StationCode1 == followingStations.StationCode1 && x.StationCode2 == followingStations.StationCode2);
            if (tempFollowingStations == null)
                throw new KeyNotFoundException(" תחנות עוקבות אלו" + followingStations.StationCode1 + " , " + followingStations.StationCode2 + "כבר לא קיימות במערכת ");
            ListFollowingStations.Remove(tempFollowingStations);
            XMLTools.SaveListToXMLSerializer(ListFollowingStations, followingStationsPath);

        }
        #endregion

        #region CRUD for station at line 
        public void AddStationInLine(stationInLine stationInLine)
        {
            List<stationInLine> ListStationInLine = XMLTools.LoadListFromXMLSerializer<stationInLine>(stationsInLinePath);
            if (ListStationInLine.Any(x => (x.LineId == stationInLine.LineId) && (x.StationCode == stationInLine.StationCode)))
                throw new DalAlreayExistExeption(" תחנה זו של קו" + stationInLine.LineId + "קיימת כבר במערכת ");
            ListStationInLine.Add(stationInLine);
            XMLTools.SaveListToXMLSerializer(ListStationInLine, stationsInLinePath);

        }
        public stationInLine GetStationInLine(int lineId, int stationCode)
        {
            List<stationInLine> ListStationInLine = XMLTools.LoadListFromXMLSerializer<stationInLine>(stationsInLinePath);
            stationInLine tempStationInLine = ListStationInLine.Find(x => (x.LineId == lineId) && (x.StationCode == stationCode));
            if (tempStationInLine == null)
                throw new KeyNotFoundException(" תחנת קו" + lineId + "לא קיימת במערכת ");
            if (tempStationInLine.IsDeleted == true)
                throw new KeyNotFoundException(" תחנה זו של קו" + lineId + "לא פעילה ");
            return tempStationInLine;
        }
        public IEnumerable<stationInLine> GetStationInLineCollection()
        {
            List<stationInLine> ListStationInLine = XMLTools.LoadListFromXMLSerializer<stationInLine>(stationsInLinePath);
            IEnumerable<stationInLine> TempstationInLine = from stationInLine item in ListStationInLine
                                                           where item.IsDeleted == false
                                                           select item;
            if (TempstationInLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות קו פעילות במערכת");
            return TempstationInLine;
        }
        public IEnumerable<stationInLine> GetAllStationsInLineCollection()
        {
            List<stationInLine> ListStationInLine = XMLTools.LoadListFromXMLSerializer<stationInLine>(stationsInLinePath);
            IEnumerable<stationInLine> TempstationInLine = from stationInLine item in ListStationInLine
                                                           select item;
            if (TempstationInLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות קו במערכת");
            return TempstationInLine;
        }

        public IEnumerable<stationInLine> GetStationInLineCollectionBy(Predicate<stationInLine> condition)
        {
            List<stationInLine> ListStationInLine = XMLTools.LoadListFromXMLSerializer<stationInLine>(stationsInLinePath);
            IEnumerable<stationInLine> TempStationInLine = from stationInLine item in ListStationInLine
                                                           where condition(item) && item.IsDeleted == false
                                                           select item;
            if (TempStationInLine.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימות תחנות קו פעילות במערכת העונות לתנאי המבוקש");
            return TempStationInLine;
        }
        public void UpdateStationInLine(stationInLine stationInLine)
        {
            List<stationInLine> ListStationInLine = XMLTools.LoadListFromXMLSerializer<stationInLine>(stationsInLinePath);
            stationInLine TempstationInLine = ListStationInLine.Find(x => (x.LineId == stationInLine.LineId) && (x.StationCode == stationInLine.StationCode));
            if (TempstationInLine == null)
                throw new KeyNotFoundException(" תחנת קו" + stationInLine.LineId + "לא קיימת במערכת ");
            if (TempstationInLine.IsDeleted)
                throw new KeyNotFoundException(" תחנת קו" + TempstationInLine.LineId + "לא פעילה ");
            ListStationInLine.Remove(TempstationInLine);
            ListStationInLine.Add(stationInLine);
            XMLTools.SaveListToXMLSerializer(ListStationInLine, stationsInLinePath);

        }
        public void DeleteStationInLine(stationInLine stationInLine)
        {
            List<stationInLine> ListStationInLine = XMLTools.LoadListFromXMLSerializer<stationInLine>(stationsInLinePath);
            stationInLine stationInLine1 = ListStationInLine.Find(x => x.LineId == stationInLine.LineId && x.StationCode == stationInLine.StationCode);
            if (stationInLine1 == null)
                throw new KeyNotFoundException(" תחנת קו" + stationInLine.LineId + "כבר לא קיימת במערכת ");
            stationInLine1.IsDeleted = true;
            XMLTools.SaveListToXMLSerializer(ListStationInLine, stationsInLinePath);

        }
        #endregion

        #region CRUD for User
        public void AddUser(User user)
        {
            List<User> ListUsers = XMLTools.LoadListFromXMLSerializer<User>(usersPath);
            if (ListUsers.Any(x => x.UserName == user.UserName))
                throw new DalAlreayExistExeption(" שם המשתמש" + user.UserName + "כבר קיים במערכת ");
            ListUsers.Add(user);
            XMLTools.SaveListToXMLSerializer(ListUsers, usersPath);
        }
        public User GetUser(string userName, string password)
        {
            List<User> ListUsers = XMLTools.LoadListFromXMLSerializer<User>(usersPath);
            User user = ListUsers.Find(x => x.UserName == userName && x.Password == password);
            if (user == null)
                throw new KeyNotFoundException(" המשתמש" + userName + "לא קיים במערכת ");
            return user;
        }
        public IEnumerable<User> GetUsersCollection()
        {
            List<User> ListUsers = XMLTools.LoadListFromXMLSerializer<User>(usersPath);
            IEnumerable<User> TempUser = from User item in ListUsers
                                         select item;
            if (TempUser.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים משתמשים במערכת");
            return TempUser;
        }
        public IEnumerable<User> GetUserCollectionBy(Predicate<User> condition)
        {
            List<User> ListUsers = XMLTools.LoadListFromXMLSerializer<User>(usersPath);
            IEnumerable<User> TempUser = from User item in ListUsers
                                         where condition(item)
                                         select item;
            if (TempUser.Count() == 0)
                throw new DalEmptyCollectionExeption("לא קיימים משתמשים במערכת");
            return TempUser;
        }
        public void UpdateUser(User user)
        {
            List<User> ListUsers = XMLTools.LoadListFromXMLSerializer<User>(usersPath);
            User user1 = ListUsers.Find(x => x.UserName == user.UserName);
            if (user1 == null)
                throw new KeyNotFoundException(" משתמש" + user.UserName + "לא קיים במערכת ");
            ListUsers.Remove(user1);
            ListUsers.Add(user);
            XMLTools.SaveListToXMLSerializer(ListUsers, usersPath);

        }
        public void DeleteUser(string userName, string password)
        {
            List<User> ListUsers = XMLTools.LoadListFromXMLSerializer<User>(usersPath);
            User TempUser = ListUsers.Find(x => x.UserName == userName && x.Password == password);
            if (TempUser == null)
                throw new KeyNotFoundException(" המשתמש" + userName + "כבר לא קיים במערכת ");
            if (!ListUsers.Remove(TempUser))
                throw new CanNotRemoveException("לא מצליח להסיר את המשתמש");
            XMLTools.SaveListToXMLSerializer(ListUsers, usersPath);

        }
        #endregion

        #region LineTrip
        //Checks that the lineTrip2 is not in lineTrip1 time frame
        //public bool isAtTime(LineTrip lineTrip1, LineTrip lineTrip2)
        //{
        //    if ((lineTrip1.StartAt > lineTrip2.EndAt && lineTrip1.EndAt < lineTrip2.EndAt) ||
        //        (lineTrip1.StartAt < lineTrip2.StartAt && lineTrip1.EndAt < lineTrip2.StartAt)
        //        return true;
        //    return false;

        //}
        public LineTrip GetLineTripBy(Predicate<LineTrip> predicate)
        {
            XElement lineTripElement = XMLTools.LoadListFromXMLElement(LineTripsPath);
            return (from item in lineTripElement.Elements()
                    let lineTrip = new LineTrip()
                    {
                        LineId = Int32.Parse(item.Element("LineId").Value),
                        NumLine = Int32.Parse(item.Element("NumLine").Value),
                        StartAt = TimeSpan.Parse(item.Element("StartAt").Value),
                        EndAt = TimeSpan.Parse(item.Element("EndAt").Value),
                        Frequency = Int32.Parse(item.Element("Frequency").Value),
                    }
                    where predicate(lineTrip)
                    select lineTrip).FirstOrDefault();
        }
        public void AddLineTrip(LineTrip lineTrip)
        {
            XElement lineTripElement = XMLTools.LoadListFromXMLElement(LineTripsPath);
            //XElement lineTrip1 = (from item in lineTripElement.Elements()
            //                     where int.Parse((item.Element("LineId").Value) == lineTrip.LineId)&&isAtTime(item,lineTrip)


            XElement lineTripXEl = new XElement("LineTrip",
                new XElement("LineId", lineTrip.LineId),
                new XElement("NumLine", lineTrip.NumLine),
                new XElement("StartAt", lineTrip.StartAt),
                new XElement("EndAt", lineTrip.EndAt),
                new XElement("Frequency", lineTrip.Frequency));
            lineTripElement.Add(lineTripXEl);
            XMLTools.SaveListToXMLElement(lineTripElement, LineTripsPath);
        }
        #endregion

    }
}
