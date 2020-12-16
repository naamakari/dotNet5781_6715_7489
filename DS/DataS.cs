using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DS
{
    public static class DataS
    {
        public static List<Bus> buses = new List<Bus>();
        public static List<BusStation> busStations = new List<BusStation>();
        public static List<BusLine> busLines = new List<BusLine>();
        public static List<stationInLine> stationsInLine1 = new List<stationInLine>();
        public static List<stationInLine> stationsInLine2 = new List<stationInLine>();
        public static List<stationInLine> stationsInLine3 = new List<stationInLine>();
        public static List<stationInLine> stationsInLine4 = new List<stationInLine>();
        public static List<stationInLine> stationsInLine5 = new List<stationInLine>();
        public static List<stationInLine> stationsInLine6 = new List<stationInLine>();
        public static List<stationInLine> stationsInLine7 = new List<stationInLine>();
        public static List<stationInLine> stationsInLine8 = new List<stationInLine>();
        public static List<stationInLine> stationsInLine9 = new List<stationInLine>();
        public static List<stationInLine> stationsInLine10 = new List<stationInLine>();

        static DataS()
        {
             initBuses();
            initBusStation();
            initBusLine();
            initStationsInLine();
        }
        static void initBuses()
        {
            #region initilized the buses
            buses.Add(new Bus()
            {
                LicenseNumber = "1111111",
                StartDate = new DateTime(1, 1, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(1, 4, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "2222222",
                StartDate = new DateTime(1, 2, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(1, 1, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "33333333",
                StartDate = new DateTime(1, 3, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(1, 2, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111112",
                StartDate = new DateTime(1, 4, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(1, 3, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111113",
                StartDate = new DateTime(1, 5, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(1, 5, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111145",
                StartDate = new DateTime(1, 6, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(1, 6, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111167",
                StartDate = new DateTime(1, 7, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(1, 7, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111189",
                StartDate = new DateTime(1, 8, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(1, 8, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1101111",
                StartDate = new DateTime(1, 9, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(1, 9, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111312",
                StartDate = new DateTime(1, 10, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(1, 10, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111415",
                StartDate = new DateTime(1, 11, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(1, 11, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111617",
                StartDate = new DateTime(1, 12, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(1, 12, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111819",
                StartDate = new DateTime(10, 1, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(10, 4, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111120",
                StartDate = new DateTime(11, 1, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(11, 4, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111121",
                StartDate = new DateTime(12, 1, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(12, 4, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111122",
                StartDate = new DateTime(13, 1, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(21, 4, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111123",
                StartDate = new DateTime(14, 1, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(13, 4, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111124",
                StartDate = new DateTime(15, 1, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(14, 4, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111125",
                StartDate = new DateTime(16, 1, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(15, 4, 2020)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111126",
                StartDate = new DateTime(17, 1, 2017),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(16, 4, 2020)
            });
            #endregion
        }
        static void initBusStation()
        {
            #region initilized the station of bus
            busStations.Add(new BusStation() { StationCode =Configuration.GetBusStationRunNum(), Longitude = (float)10.0, Latitude = (float)10.50, Address = "הגעתון 2 נהריה", StationName = "הגעתון" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.1, Latitude = (float)10.49, Address = "הבנאי 2 ירושלים", StationName = "הבנאי" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.2, Latitude = (float)10.48, Address = "המייסדים 5 נתניה", StationName = "המייסדים/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.3, Latitude = (float)10.47, Address = "רקפת 2 בת ים", StationName = "רקפת/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.4, Latitude = (float)10.46, Address = "דוכיפת 2 אשדוד", StationName = "דוכיפת/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.5, Latitude = (float)10.45, Address = "ערוגות 2 אשקלון", StationName = "ערוגות/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.6, Latitude = (float)10.44, Address = "קידרון 2 גדרה", StationName = "קידרון/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.7, Latitude = (float)10.43, Address = "חבר 2 חדרה", StationName = "חבר/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.8, Latitude = (float)10.42, Address = "עפרוני 2 נתיבות", StationName = "עפרוני/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.9, Latitude = (float)10.41, Address = "המכבים 2 באר שבע", StationName = "המכבים/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.10, Latitude = (float)10.40, Address = "שבט בנימין 2 גבעת אולגה", StationName = "שבט בנימין/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.11, Latitude = (float)10.39, Address = "הלולב 2 הוד השרון", StationName = "הלולב/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.12, Latitude = (float)10.38, Address = "האתרוג 2 טבריה", StationName = "האתרוג/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.13, Latitude = (float)10.37, Address = "מבוא הדס 2 הרצליה", StationName = "מבוא הדס/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.14, Latitude = (float)10.36, Address = "הערבה 2 זיכרון יעקב", StationName = "הערבה/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.15, Latitude = (float)10.35, Address = "יקינתון 2 חיפה", StationName = "יקינתון/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.16, Latitude = (float)10.34, Address = "שאול המלך 2 ירוחם", StationName = "שאול המלך/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.17, Latitude = (float)10.33, Address = "דוד המלך 2 לוד", StationName = "דוד המלך/ממילא" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.18, Latitude = (float)10.32, Address = "החרצית 2 רמלה", StationName = "הרצל/החרצית" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.19, Latitude = (float)10.31, Address = "קרית יערים 2 רחובות", StationName = "הרצל/קרית יערים" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.20, Latitude = (float)10.30, Address = "היהודים 2 תל אביב", StationName = "היהודים/השוערים" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.21, Latitude = (float)10.29, Address = "תפארת ישראל 2 כפר סבא", StationName = "תפארת ישראל/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.22, Latitude = (float)10.28, Address = "המשוררים 2 מבשרת ציון", StationName = "המשוררים/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.23, Latitude = (float)10.27, Address = "השוערים 2 מעלות", StationName = "השוערים/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.24, Latitude = (float)10.26, Address = "מבוא השיקמה 2 צפת", StationName = "מבוא השיקמה/בן גוריון" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.25, Latitude = (float)10.25, Address = "העומר 2 נוף הגליל", StationName = "העומר/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.26, Latitude = (float)10.24, Address = "העוגב 2 עפולה", StationName = "העוגב/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.27, Latitude = (float)10.23, Address = "המלאך 2 שילה", StationName = "המלאך/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.28, Latitude = (float)10.22, Address = "חב''ד 2 פתח תקווה", StationName = "חב''ד/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.29, Latitude = (float)10.21, Address = "המצילתיים 2 רמת גן", StationName = "המצילתיים/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.30, Latitude = (float)10.20, Address = "הכותל 2 מודיעין", StationName = "הכותל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.31, Latitude = (float)10.19, Address = "בית הדפוס 2 שוהם", StationName = "בית הדפוס/בית השנהב" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.32, Latitude = (float)10.18, Address = "חיים ויטאל 2 קרית ספר", StationName = "חיים ויטאל/נג'ארה" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.33, Latitude = (float)10.17, Address = "כנפי נשרים 2 ערד", StationName = "כנפי נשרים/בית הדפוס" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.34, Latitude = (float)10.16, Address = "קרית משה 2 דימונה", StationName = "קרית משה" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.35, Latitude = (float)10.15, Address = "דניאל סירקיס 2 מצפה רמון", StationName = "דניאל סירקיס/קרית משה" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.36, Latitude = (float)10.14, Address = "משה מרזוק 2 מטולה", StationName = "משה מרזוק/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.37, Latitude = (float)10.13, Address = "דרך נמיר 2 אילת", StationName = "דרך נמיר/בן גוריון" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.38, Latitude = (float)10.12, Address = "הרצל 2 קרית שמונה", StationName = "בן גוריון/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.39, Latitude = (float)10.11, Address = "אלחדיף 2 קרית מלאכי", StationName = "אלחדיף/קונטיננטל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.40, Latitude = (float)10.10, Address = "חנה סנש 2 קרית גת", StationName = "חנה סנש/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.41, Latitude = (float)10.9, Address = "יצחק רגר 2 קרית חיים", StationName = "יצחק רגר/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.42, Latitude = (float)10.8, Address = "ירושלים 2 קרית ים", StationName = "ירושלים/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.43, Latitude = (float)10.7, Address = "חי טייב 2 קרית שמואל", StationName = "חי טייב/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.44, Latitude = (float)10.6, Address = "שאולזון 2 קרית ביאליק", StationName = "שאולזון/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.45, Latitude = (float)10.5, Address = "הקבלן 2 חולון", StationName = "הקבלן/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.46, Latitude = (float)10.4, Address = "ירמיהו 2 גבעתיים", StationName = "ירמיהו/מנחת יצחק" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.47, Latitude = (float)10.3, Address = "המ''ג 2 בית שמש", StationName = "המ''ג/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.48, Latitude = (float)10.2, Address = "יפו 2 גבעת שמואל", StationName = "יפו/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.49, Latitude = (float)10.1, Address = "קינג ג'ורג' 2 רעננה", StationName = "קינג ג'ורג'/יפו" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.50, Latitude = (float)10.0, Address = "פייר קניג 2 נהריה", StationName = "פייר קניג/הרצל" });
            #endregion
        }
        static void initBusLine()
        {
            #region initilized the lines of bus
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 1, AreaAtLand = Area.General, NumberFirstStation = 1123, NumberLastStation = 1154, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 2, AreaAtLand = Area.General, NumberFirstStation = 1113, NumberLastStation = 1153, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 3, AreaAtLand = Area.General, NumberFirstStation = 1124, NumberLastStation = 1152, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 4, AreaAtLand = Area.General, NumberFirstStation = 1125, NumberLastStation = 1151, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 5, AreaAtLand = Area.General, NumberFirstStation = 1126, NumberLastStation = 1150, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 6, AreaAtLand = Area.General, NumberFirstStation = 1127, NumberLastStation = 1149, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 7, AreaAtLand = Area.General, NumberFirstStation = 1128, NumberLastStation = 1148, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 8, AreaAtLand = Area.General, NumberFirstStation = 1129, NumberLastStation = 1147, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 9, AreaAtLand = Area.General, NumberFirstStation = 1130, NumberLastStation = 1146, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 10, AreaAtLand = Area.General, NumberFirstStation = 1131, NumberLastStation = 1145, IsDeleted = false });

            #endregion
        }
        static void initStationsInLine()
        {
            #region initilized the station in line
            stationsInLine1.Add(new stationInLine() { LineId = 1111, StationCode = 1111, IndexStationAtLine = 1, IsDeleted = false });
            stationsInLine1.Add(new stationInLine() { LineId = 1111, StationCode = 1112, IndexStationAtLine = 2, IsDeleted = false });
            stationsInLine1.Add(new stationInLine() { LineId = 1111, StationCode = 1113, IndexStationAtLine = 3, IsDeleted = false });
            stationsInLine1.Add(new stationInLine() { LineId = 1111, StationCode = 1114, IndexStationAtLine = 4, IsDeleted = false });
            stationsInLine1.Add(new stationInLine() { LineId = 1111, StationCode = 1115, IndexStationAtLine = 5, IsDeleted = false });
            stationsInLine1.Add(new stationInLine() { LineId = 1111, StationCode = 1116, IndexStationAtLine = 6, IsDeleted = false });
            stationsInLine1.Add(new stationInLine() { LineId = 1111, StationCode = 1117, IndexStationAtLine = 7, IsDeleted = false });
            stationsInLine1.Add(new stationInLine() { LineId = 1111, StationCode = 1118, IndexStationAtLine = 8, IsDeleted = false });
            stationsInLine1.Add(new stationInLine() { LineId = 1111, StationCode = 1119, IndexStationAtLine = 9, IsDeleted = false });
            stationsInLine1.Add(new stationInLine() { LineId = 1111, StationCode = 1120, IndexStationAtLine = 10, IsDeleted = false });
           
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1121, IndexStationAtLine = 1, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1122, IndexStationAtLine = 2, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1123, IndexStationAtLine = 3, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1124, IndexStationAtLine = 4, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1125, IndexStationAtLine = 5, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1126, IndexStationAtLine = 6, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1127, IndexStationAtLine = 7, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1128, IndexStationAtLine = 8, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1129, IndexStationAtLine = 9, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1130, IndexStationAtLine = 10, IsDeleted = false });

            stationsInLine3.Add(new stationInLine() { LineId = 1113, StationCode = 1131, IndexStationAtLine = 1, IsDeleted = false });

            #endregion
        }
    }
}
