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
            //1111
            busStations.Add(new BusStation() { StationCode =Configuration.GetBusStationRunNum(), Longitude = (float)32.170699, Latitude = (float)34.82964, Address = "הנדיב 2 הרצליה", StationName = "הנדיב/ז'בוטינסקי" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.16843, Latitude = (float)34.83031, Address = "פינסקר 2 הרצליה", StationName = "פינסקר/ז'בוטינסקי" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.16780, Latitude = (float)34.83265, Address = "צבי מנדלבליט 2 הרצליה", StationName = "צבי מנדלבליט/שמואל הנגיד" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.16448, Latitude = (float)34.83541, Address = "ויצמן 2 הרצליה", StationName = "בית ספר ויצמן/ויצמן" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.16440, Latitude = (float)34.84276, Address = "בן גוריון 10 הרצליה", StationName = "בן גוריון/העצמאות" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.16480, Latitude = (float)34.84333, Address = "העצמאות 2 הרצליה", StationName = "העצמאות/בן גוריון" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.16694, Latitude = (float)34.84254, Address = "בן גוריון 30 הרצליה", StationName = "קניון לב העיר" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.17035, Latitude = (float)34.84037, Address = "טשרניחובקסי 1 הרצליה", StationName = "טשרניחובסקי" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.17111, Latitude = (float)34.83991, Address = "בני בנימין 2 הרצליה", StationName = "בני בנימין/סמילנסקי" });
            //1120
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.17250, Latitude = (float)34.84085, Address = "בני בנימין 11 הרצליה", StationName = "בני בנימין/גיסין" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.17445, Latitude = (float)34.83959, Address = "כנםי נשרים 4 הרצליה", StationName = "כנפי נשרים/נתן אלתרמן" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.17382, Latitude = (float)34.83684, Address = "דור שמעוני 4 הרצליה", StationName = "דוד שמעוני/יהודה אלקלעי" });
            
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24265, Latitude = (float)34.79775, Address = "יהושע חנקין 2 באר שבע", StationName = "ת.מרכזית/עירוניים לדרום" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24171, Latitude = (float)34.79647, Address = "שדרות דוד חכם 80 באר שבע", StationName = "שגרות דוד חכם/תחנה מרכזית" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24502, Latitude = (float)34.79589, Address = "יצחק רגר 10 באר שבע", StationName = "דואר/יצחק רגר" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24428, Latitude = (float)34.79591, Address = "יצחק בן צבי 2 באר שבע", StationName = "קניון הנגב/יצחק בן צבי" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24690, Latitude = (float)34.79789, Address = "הנרייטה סולד 8 באר שבע", StationName = "הנרייטה סולד/מדרחוב התקווה" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24753, Latitude = (float)34.80236, Address = "הנרייטה סולד 28 באר שבע", StationName = "קופת חולים ג/הנרייטה סולד" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25147, Latitude = (float)34.80166, Address = "דרך השלום 100", StationName = "תיכון מקיף א/דרך השלום" });
            //1130
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25294, Latitude = (float)34.80366, Address = "דרך השלום 34", StationName = "דרך השלום/יד ושם" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25203, Latitude = (float)34.80689, Address = "דרך השלום 2 באר שבע", StationName = "דרך השלום/ארלוזורוב" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25185, Latitude = (float)34.80913, Address = "ז'בוטינסקי 10 באר שבע", StationName = "שדרות דוד בן גוריון/דרך השלום" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.5731, Latitude = (float)34.81207, Address = "שדרות דוד בן גוריון 100 באר שבע", StationName = "המשוררים/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25776, Latitude = (float)34.81337, Address = "יהושע הצורף 2 באר שבע", StationName = "יהושע הצורף/יהודה הנחתום" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25682, Latitude = (float)34.81534, Address = "יהושע הצורף 15", StationName = "יהושע הצורף" });
            

            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.25, Latitude = (float)10.25, Address = "העומר 2 נוף הגליל", StationName = "העומר/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.26, Latitude = (float)10.24, Address = "העוגב 2 עפולה", StationName = "העוגב/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.27, Latitude = (float)10.23, Address = "המלאך 2 שילה", StationName = "המלאך/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.28, Latitude = (float)10.22, Address = "חב''ד 2 פתח תקווה", StationName = "חב''ד/הרצל" });
            //1140
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
            //1150
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
            //1160
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.49, Latitude = (float)10.1, Address = "קינג ג'ורג' 2 רעננה", StationName = "קינג ג'ורג'/יפו" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)10.50, Latitude = (float)10.0, Address = "פייר קניג 2 נהריה", StationName = "פייר קניג/הרצל" });
            #endregion
        }
        static void initBusLine()
        {
            #region initilized the lines of bus
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 1, AreaAtLand = Area.Center, NumberFirstStation = 1111, NumberLastStation = 1120, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 2, AreaAtLand = Area.South, NumberFirstStation = 1123, NumberLastStation = 1135, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 3, AreaAtLand = Area.South, NumberFirstStation = 1123, NumberLastStation = 1135, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 418, AreaAtLand = Area.General, NumberFirstStation = 1123, NumberLastStation = 1120, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 415, AreaAtLand = Area.General, NumberFirstStation = 1111, NumberLastStation = 1123, IsDeleted = false });

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
           
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1123, IndexStationAtLine = 1, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1124, IndexStationAtLine = 2, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1125, IndexStationAtLine = 3, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1126, IndexStationAtLine = 4, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1127, IndexStationAtLine = 5, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1128, IndexStationAtLine = 6, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1129, IndexStationAtLine = 7, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1131, IndexStationAtLine = 8, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1133, IndexStationAtLine = 9, IsDeleted = false });
            stationsInLine2.Add(new stationInLine() { LineId = 1112, StationCode = 1135, IndexStationAtLine = 10, IsDeleted = false });

            stationsInLine3.Add(new stationInLine() { LineId = 1113, StationCode = 1123, IndexStationAtLine = 1, IsDeleted = false });
            stationsInLine3.Add(new stationInLine() { LineId = 1113, StationCode = 1124, IndexStationAtLine = 2, IsDeleted = false });
            stationsInLine3.Add(new stationInLine() { LineId = 1113, StationCode = 1125, IndexStationAtLine = 3, IsDeleted = false });
            stationsInLine3.Add(new stationInLine() { LineId = 1113, StationCode = 1126, IndexStationAtLine = 4, IsDeleted = false });
            stationsInLine3.Add(new stationInLine() { LineId = 1113, StationCode = 1128, IndexStationAtLine = 5, IsDeleted = false });
            stationsInLine3.Add(new stationInLine() { LineId = 1113, StationCode = 1130, IndexStationAtLine = 6, IsDeleted = false });
            stationsInLine3.Add(new stationInLine() { LineId = 1113, StationCode = 1132, IndexStationAtLine = 7, IsDeleted = false });
            stationsInLine3.Add(new stationInLine() { LineId = 1113, StationCode = 1133, IndexStationAtLine = 8, IsDeleted = false });
            stationsInLine3.Add(new stationInLine() { LineId = 1113, StationCode = 1134, IndexStationAtLine = 9, IsDeleted = false });
            stationsInLine3.Add(new stationInLine() { LineId = 1113, StationCode = 1135, IndexStationAtLine = 10, IsDeleted = false });

            stationsInLine4.Add(new stationInLine() { LineId = 1114, StationCode = 1123, IndexStationAtLine = 1, IsDeleted = false });
            stationsInLine4.Add(new stationInLine() { LineId = 1114, StationCode = 1124, IndexStationAtLine = 2, IsDeleted = false });
            stationsInLine4.Add(new stationInLine() { LineId = 1114, StationCode = 1125, IndexStationAtLine = 3, IsDeleted = false });
            stationsInLine4.Add(new stationInLine() { LineId = 1114, StationCode = 1126, IndexStationAtLine = 4, IsDeleted = false });
            stationsInLine4.Add(new stationInLine() { LineId = 1114, StationCode = 1117, IndexStationAtLine = 5, IsDeleted = false });
            stationsInLine4.Add(new stationInLine() { LineId = 1114, StationCode = 1118, IndexStationAtLine = 6, IsDeleted = false });
            stationsInLine4.Add(new stationInLine() { LineId = 1114, StationCode = 1119, IndexStationAtLine = 7, IsDeleted = false });
            stationsInLine4.Add(new stationInLine() { LineId = 1114, StationCode = 1120, IndexStationAtLine = 8, IsDeleted = false });
            stationsInLine4.Add(new stationInLine() { LineId = 1114, StationCode = 1121, IndexStationAtLine = 9, IsDeleted = false });
            stationsInLine4.Add(new stationInLine() { LineId = 1114, StationCode = 1120, IndexStationAtLine = 10, IsDeleted = false });

            stationsInLine5.Add(new stationInLine() { LineId = 1115, StationCode = 1111, IndexStationAtLine = 1, IsDeleted = false });
            stationsInLine5.Add(new stationInLine() { LineId = 1115, StationCode = 1112, IndexStationAtLine = 2, IsDeleted = false });
            stationsInLine5.Add(new stationInLine() { LineId = 1115, StationCode = 1113, IndexStationAtLine = 3, IsDeleted = false });
            stationsInLine5.Add(new stationInLine() { LineId = 1115, StationCode = 1114, IndexStationAtLine = 4, IsDeleted = false });
            stationsInLine5.Add(new stationInLine() { LineId = 1115, StationCode = 1125, IndexStationAtLine = 5, IsDeleted = false });
            stationsInLine5.Add(new stationInLine() { LineId = 1115, StationCode = 1130, IndexStationAtLine = 6, IsDeleted = false });
            stationsInLine5.Add(new stationInLine() { LineId = 1115, StationCode = 1135, IndexStationAtLine = 7, IsDeleted = false });
            stationsInLine5.Add(new stationInLine() { LineId = 1115, StationCode = 1132, IndexStationAtLine = 8, IsDeleted = false });
            stationsInLine5.Add(new stationInLine() { LineId = 1115, StationCode = 1124, IndexStationAtLine = 9, IsDeleted = false });
            stationsInLine5.Add(new stationInLine() { LineId = 1115, StationCode = 1123, IndexStationAtLine = 10, IsDeleted = false });

            #endregion
        }
    }
}
