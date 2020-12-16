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
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.17035, Latitude = (float)34.84037, Address = "טשרניחובסקי 1 הרצליה", StationName = "טשרניחובסקי" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.17111, Latitude = (float)34.83991, Address = "בני בנימין 2 הרצליה", StationName = "בני בנימין/סמילנסקי" });
            //1120
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.17250, Latitude = (float)34.84085, Address = "בני בנימין 11 הרצליה", StationName = "בני בנימין/גיסין" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.17445, Latitude = (float)34.83959, Address = "כנפי נשרים 4 הרצליה", StationName = "כנפי נשרים/נתן אלתרמן" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.17382, Latitude = (float)34.83684, Address = "דור שמעוני 4 הרצליה", StationName = "דוד שמעוני/יהודה אלקלעי" });
            
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24265, Latitude = (float)34.79775, Address = "יהושע חנקין 2 באר שבע", StationName = "ת.מרכזית/עירוניים לדרום" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24171, Latitude = (float)34.79647, Address = "שדרות דוד חכם 80 באר שבע", StationName = "שגרות דוד חכם/תחנה מרכזית" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24502, Latitude = (float)34.79589, Address = "יצחק רגר 10 באר שבע", StationName = "דואר/יצחק רגר" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24428, Latitude = (float)34.79591, Address = "יצחק בן צבי 2 באר שבע", StationName = "קניון הנגב/יצחק בן צבי" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24690, Latitude = (float)34.79789, Address = "הנרייטה סולד 8 באר שבע", StationName = "הנרייטה סולד/מדרחוב התקווה" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24753, Latitude = (float)34.80236, Address = "הנרייטה סולד 28 באר שבע", StationName = "קופת חולים ג/הנרייטה סולד" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25147, Latitude = (float)34.80166, Address = "דרך השלום 100 באר שבע", StationName = "תיכון מקיף א/דרך השלום" });
            //1130
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25294, Latitude = (float)34.80366, Address = "דרך השלום 34 באר שבע", StationName = "דרך השלום/יד ושם" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25203, Latitude = (float)34.80689, Address = "דרך השלום 2 באר שבע", StationName = "דרך השלום/ארלוזורוב" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25185, Latitude = (float)34.80913, Address = "ז'בוטינסקי 10 באר שבע", StationName = "שדרות דוד בן גוריון/דרך השלום" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.5731, Latitude = (float)34.81207, Address = "שדרות דוד בן גוריון 100 באר שבע", StationName = "המשוררים/הרצל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25776, Latitude = (float)34.81337, Address = "יהושע הצורף 2 באר שבע", StationName = "יהושע הצורף/יהודה הנחתום" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25682, Latitude = (float)34.81534, Address = "יהושע הצורף 15 באר שבע", StationName = "יהושע הצורף" });
            
            ///1136
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.79467, Latitude = (float)35.52932, Address = "ברנר 3 טבריה", StationName = "ברנר/יהודה הנשיא" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.78921, Latitude = (float)35.53010, Address = "ברנר 17 טבריה", StationName = "ברנר/התנא נחום" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.78765, Latitude = (float)35.53683, Address = "הירדן 23 טבריה", StationName = "תחנה מרכזית טבריה" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.79837, Latitude = (float)35.53193, Address = "אחד העם 11 טבריה", StationName = "אחד העם/נחמני" });
            //1140
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.79877, Latitude = (float)35.52865, Address = "שמעון דהאן 5 טבריה", StationName = "ארליך/שמעון דהאן" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.79917, Latitude = (float)35.52300, Address = "וינגייט 2 טבריה", StationName = "וינגייט/לח''י" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.79758, Latitude = (float)35.52285, Address = "שדרות מנחם בגין 141 טבריה", StationName = "שדרות מנחם בגין/וינגייט" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.79509, Latitude = (float)35.52054, Address = "בר כוכבא 52 טבריה", StationName = "בר כוכבא/דוד המלך" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.79105, Latitude = (float)35.51652, Address = "שדרות מנחם בגין 301 טבריה", StationName = "שדרות מנחם בגין/ספיר" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.78296, Latitude = (float)35.52135, Address = "שדרות ספיר 102 טבריה עילית", StationName = "שדרות ספיר/רקפת" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.78278, Latitude = (float)35.51814, Address = "ירושלים 74 טבריה עילית", StationName = "ירושלים/שד. אלנטאון" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.78030, Latitude = (float)35.51916, Address = "הנשיא וייצמן 10 טבריה עילית", StationName = "מלון צמרת/וייצמן" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.77788, Latitude = (float)35.51029, Address = "יצחק בן צבי 82 טבריה", StationName = "יצחק בן צבי/הרצוג" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.77450, Latitude = (float)35.51264, Address = "לוי אשכול 20 טבריה", StationName = "לוי אשכול/משה שרת" });
            //1150
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.78218, Latitude = (float)35.52589, Address = "חרצית 1 טבריה", StationName = "חרצית/כליל החורש" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.075008, Latitude = (float)34.81992, Address = "שדרות ירושלים 105 רמת גן", StationName = "שד' ירושלים/דרך בן גוריון" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.072409, Latitude = (float)34.82301, Address = "עוזיאל 33 רמת גן", StationName = "ביה''ס חורב/עוזיאל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.063604, Latitude = (float)34.82343, Address = "הרא''ה 6 רמת גן", StationName = "הרא''ה/פנחס רוטנברג" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.07031, Latitude = (float)34.82799, Address = "דרך נגבה 14 רמת גן", StationName = "נגבה/הירדן" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.06336, Latitude = (float)34.82828, Address = "הירדן 212 רמת גן", StationName = "הירדן/פנחס" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.06024, Latitude = (float)34.83117, Address = "נווה יהושע 5 רמת גן", StationName = "נווה יהושע/סטופ" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.06596, Latitude = (float)34.83287, Address = "אריה בן אליעזר 62 רמת גן", StationName = "בן אליעזר/אצ''ל" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.06982, Latitude = (float)34.83767, Address = "אצ''ל 22 רמת גן", StationName = "אצ''ל/הרב לנדס" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.07299, Latitude = (float)34.83309, Address = "חזון אי''ש 55 בני ברק", StationName = "חזון אי''ש/מרום נווה" });
            //1160
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.07479, Latitude = (float)34.83081, Address = "שדרות ירושלים 14 רמת גן", StationName = "שדרות ירושלים/מולכו" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.08216, Latitude = (float)34.82066, Address = "דוד בן גוריון 98 רמת גן", StationName = "בן גוריון/החץ" });
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

            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 8, AreaAtLand = Area.North, NumberFirstStation = 1138, NumberLastStation = 1146, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 13, AreaAtLand = Area.North, NumberFirstStation = 1150, NumberLastStation = 1138, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 5, AreaAtLand = Area.Center, NumberFirstStation = 1151, NumberLastStation = 1161, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 836, AreaAtLand = Area.General, NumberFirstStation = 1159, NumberLastStation = 1138, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 837, AreaAtLand = Area.General, NumberFirstStation = 1138, NumberLastStation = 1159, IsDeleted = false });

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
