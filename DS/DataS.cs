﻿using System;
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
        public static List<stationInLine> stationsInLine = new List<stationInLine>();
        public static List<FollowingStations> followingStations = new List<FollowingStations>();
        public static List<User> users = new List<User>();
        public static List<LineTrip> lineTrips = new List<LineTrip>();

        static DataS()
        {
            initBuses();
            initBusStation();
            initBusLine();
            initStationsInLine();
            initFollowingStation();
            initUser();
            initLineTrip();
        }
        static void initBuses()
        {
            #region initilized the buses
            buses.Add(new Bus()
            {
                LicenseNumber = "1111111",
                StartDate = new DateTime(2017, 1, 1),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 4, 1)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "2222222",
                StartDate = new DateTime(2017, 1, 2),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 1, 1)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "33333333",
                StartDate = new DateTime(2017, 3, 1),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 1, 1)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111112",
                StartDate = new DateTime(2017, 1, 4),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 3, 1)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111113",
                StartDate = new DateTime(2017, 1, 5),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 1, 5)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111145",
                StartDate = new DateTime(2017, 6, 1),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 6, 1)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111167",
                StartDate = new DateTime(2017, 1, 7),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 7, 1)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111189",
                StartDate = new DateTime(2017, 1, 8),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 1, 8)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1101111",
                StartDate = new DateTime(2017, 9, 1),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 1, 7)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111312",
                StartDate = new DateTime(2017, 10, 1),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 10, 1)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111415",
                StartDate = new DateTime(2017, 1, 1),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 11, 1)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111617",
                StartDate = new DateTime(2017, 1, 2),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 12, 1)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111819",
                StartDate = new DateTime(2017, 10, 1),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 4, 1)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111120",
                StartDate = new DateTime(2017, 1, 2),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 11, 4)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111121",
                StartDate = new DateTime(2017, 1, 4),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 12, 4)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111122",
                StartDate = new DateTime(2017, 3, 1),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 4, 10)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111123",
                StartDate = new DateTime(2017, 7, 14),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 4, 13)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111124",
                StartDate = new DateTime(2017, 1, 15),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 4, 14)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111125",
                StartDate = new DateTime(2017, 1, 16),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 4, 15)
            });
            buses.Add(new Bus()
            {
                LicenseNumber = "1111126",
                StartDate = new DateTime(2017, 1, 2),
                Kilometraz = 8000,
                KmSinceRefeul = 500,
                BusState = BusStatus.ready,
                IsDeleted = false,
                KmSinceLastTreat = 2000,
                DateSinceLastTreat = new DateTime(2020, 4, 16)
            });
            #endregion
        }
        static void initBusStation()
        {
            #region initilized the station of bus
            //1111
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.170699, Latitude = (float)34.82964, Address = "הנדיב 2 הרצליה", StationName = "הנדיב/ז'בוטינסקי" });//1111
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)32.16843, Latitude = (float)34.83031, Address = "פינסקר 2 הרצליה", StationName = "פינסקר/ז'בוטינסקי" });//1112
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
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24171, Latitude = (float)34.79647, Address = "שדרות דוד חכם 80 באר שבע", StationName = "שדרות דוד חכם/תחנה מרכזית" });
            //1125                                                                                          1125
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24502, Latitude = (float)34.79589, Address = "יצחק רגר 10 באר שבע", StationName = "דואר/יצחק רגר" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24428, Latitude = (float)34.79591, Address = "יצחק בן צבי 2 באר שבע", StationName = "קניון הנגב/יצחק בן צבי" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24690, Latitude = (float)34.79789, Address = "הנרייטה סולד 8 באר שבע", StationName = "הנרייטה סולד/מדרחוב התקווה" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24753, Latitude = (float)34.80236, Address = "הנרייטה סולד 28 באר שבע", StationName = "קופת חולים ג/הנרייטה סולד" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25147, Latitude = (float)34.80166, Address = "דרך השלום 100 באר שבע", StationName = "תיכון מקיף א/דרך השלום" });
            //1130                                                                                                             1130
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25294, Latitude = (float)34.80366, Address = "דרך השלום 34 באר שבע", StationName = "דרך השלום/יד ושם" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25203, Latitude = (float)34.80689, Address = "דרך השלום 2 באר שבע", StationName = "דרך השלום/ארלוזורוב" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.24908, Latitude = (float)34.80917, Address = "ז'בוטינסקי 10 באר שבע", StationName = "בי''ס דגניה/ז'בוטינסקי" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25752, Latitude = (float)34.81208, Address = "שדרות דוד בן גוריון 100 באר שבע", StationName = "שדרות דוד בן גוריון/דרך השלום" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25776, Latitude = (float)34.81337, Address = "יהושע הצורף 2 באר שבע", StationName = "יהושע הצורף/יהודה הנחתום" });
            busStations.Add(new BusStation() { StationCode = Configuration.GetBusStationRunNum(), Longitude = (float)31.25682, Latitude = (float)34.81534, Address = "יהושע הצורף 15 באר שבע", StationName = "יהושע הצורף" });

            ///1136                                                                                                              1136
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
            //1150                                                                                                                 1150   
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
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 418, AreaAtLand = Area.General, NumberFirstStation = 1123, NumberLastStation = 1122, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 415, AreaAtLand = Area.General, NumberFirstStation = 1111, NumberLastStation = 1123, IsDeleted = false });

            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 8, AreaAtLand = Area.North, NumberFirstStation = 1137, NumberLastStation = 1147, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 13, AreaAtLand = Area.North, NumberFirstStation = 1147, NumberLastStation = 1138, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 5, AreaAtLand = Area.Center, NumberFirstStation = 1161, NumberLastStation = 1153, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 836, AreaAtLand = Area.General, NumberFirstStation = 1159, NumberLastStation = 1138, IsDeleted = false });
            busLines.Add(new BusLine() { BusId = Configuration.GetBusLineRunNum(), BusNumLine = 836, AreaAtLand = Area.General, NumberFirstStation = 1138, NumberLastStation = 1159, IsDeleted = false });

            #endregion
        }
        static void initStationsInLine()
        {
            #region initilized the station in line
            stationsInLine.Add(new stationInLine() { LineId = 1111, StationCode = 1111, IndexStationAtLine = 1, IsDeleted = false, IsFirstStation = true, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1111, StationCode = 1112, IndexStationAtLine = 2, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1111, StationCode = 1113, IndexStationAtLine = 3, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1111, StationCode = 1114, IndexStationAtLine = 4, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1111, StationCode = 1115, IndexStationAtLine = 5, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1111, StationCode = 1116, IndexStationAtLine = 6, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1111, StationCode = 1117, IndexStationAtLine = 7, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1111, StationCode = 1118, IndexStationAtLine = 8, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1111, StationCode = 1119, IndexStationAtLine = 9, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1111, StationCode = 1120, IndexStationAtLine = 10, IsDeleted = false, IsFirstStation = false, IsLastStation = true });

            stationsInLine.Add(new stationInLine() { LineId = 1112, StationCode = 1123, IndexStationAtLine = 1, IsDeleted = false, IsFirstStation = true, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1112, StationCode = 1124, IndexStationAtLine = 2, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1112, StationCode = 1125, IndexStationAtLine = 3, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1112, StationCode = 1126, IndexStationAtLine = 4, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1112, StationCode = 1127, IndexStationAtLine = 5, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1112, StationCode = 1128, IndexStationAtLine = 6, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1112, StationCode = 1129, IndexStationAtLine = 7, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1112, StationCode = 1131, IndexStationAtLine = 8, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1112, StationCode = 1133, IndexStationAtLine = 9, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1112, StationCode = 1135, IndexStationAtLine = 10, IsDeleted = false, IsFirstStation = false, IsLastStation = true });

            stationsInLine.Add(new stationInLine() { LineId = 1113, StationCode = 1123, IndexStationAtLine = 1, IsDeleted = false, IsFirstStation = true, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1113, StationCode = 1124, IndexStationAtLine = 2, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1113, StationCode = 1125, IndexStationAtLine = 3, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1113, StationCode = 1126, IndexStationAtLine = 4, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1113, StationCode = 1128, IndexStationAtLine = 5, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1113, StationCode = 1130, IndexStationAtLine = 6, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1113, StationCode = 1132, IndexStationAtLine = 7, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1113, StationCode = 1133, IndexStationAtLine = 8, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1113, StationCode = 1134, IndexStationAtLine = 9, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1113, StationCode = 1135, IndexStationAtLine = 10, IsDeleted = false, IsFirstStation = false, IsLastStation = true });

            stationsInLine.Add(new stationInLine() { LineId = 1114, StationCode = 1123, IndexStationAtLine = 1, IsDeleted = false, IsFirstStation = true, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1114, StationCode = 1124, IndexStationAtLine = 2, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1114, StationCode = 1125, IndexStationAtLine = 3, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1114, StationCode = 1126, IndexStationAtLine = 4, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1114, StationCode = 1117, IndexStationAtLine = 5, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1114, StationCode = 1118, IndexStationAtLine = 6, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1114, StationCode = 1119, IndexStationAtLine = 7, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1114, StationCode = 1120, IndexStationAtLine = 8, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1114, StationCode = 1121, IndexStationAtLine = 9, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1114, StationCode = 1122, IndexStationAtLine = 10, IsDeleted = false, IsFirstStation = false, IsLastStation = true });

            stationsInLine.Add(new stationInLine() { LineId = 1115, StationCode = 1111, IndexStationAtLine = 1, IsDeleted = false, IsFirstStation = true, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1115, StationCode = 1112, IndexStationAtLine = 2, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1115, StationCode = 1113, IndexStationAtLine = 3, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1115, StationCode = 1114, IndexStationAtLine = 4, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1115, StationCode = 1125, IndexStationAtLine = 5, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1115, StationCode = 1130, IndexStationAtLine = 6, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1115, StationCode = 1135, IndexStationAtLine = 7, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1115, StationCode = 1132, IndexStationAtLine = 8, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1115, StationCode = 1124, IndexStationAtLine = 9, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1115, StationCode = 1123, IndexStationAtLine = 10, IsDeleted = false, IsFirstStation = false, IsLastStation = true });

            stationsInLine.Add(new stationInLine() { LineId = 1116, StationCode = 1137, IndexStationAtLine = 1, IsDeleted = false, IsFirstStation = true, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1116, StationCode = 1136, IndexStationAtLine = 2, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1116, StationCode = 1139, IndexStationAtLine = 3, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1116, StationCode = 1140, IndexStationAtLine = 4, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1116, StationCode = 1141, IndexStationAtLine = 5, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1116, StationCode = 1142, IndexStationAtLine = 6, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1116, StationCode = 1143, IndexStationAtLine = 7, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1116, StationCode = 1144, IndexStationAtLine = 8, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1116, StationCode = 1145, IndexStationAtLine = 9, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1116, StationCode = 1146, IndexStationAtLine = 10, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1116, StationCode = 1147, IndexStationAtLine = 11, IsDeleted = false, IsFirstStation = false, IsLastStation = true });


            stationsInLine.Add(new stationInLine() { LineId = 1117, StationCode = 1147, IndexStationAtLine = 1, IsDeleted = false, IsFirstStation = true, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1117, StationCode = 1148, IndexStationAtLine = 2, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1117, StationCode = 1149, IndexStationAtLine = 3, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1117, StationCode = 1145, IndexStationAtLine = 4, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1117, StationCode = 1144, IndexStationAtLine = 5, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1117, StationCode = 1142, IndexStationAtLine = 6, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1117, StationCode = 1150, IndexStationAtLine = 7, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1117, StationCode = 1136, IndexStationAtLine = 8, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1117, StationCode = 1137, IndexStationAtLine = 9, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1117, StationCode = 1138, IndexStationAtLine = 10, IsDeleted = false, IsFirstStation = false, IsLastStation = true });

            stationsInLine.Add(new stationInLine() { LineId = 1118, StationCode = 1161, IndexStationAtLine = 1, IsDeleted = false, IsFirstStation = true, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1118, StationCode = 1160, IndexStationAtLine = 2, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1118, StationCode = 1151, IndexStationAtLine = 3, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1118, StationCode = 1152, IndexStationAtLine = 4, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1118, StationCode = 1158, IndexStationAtLine = 5, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1118, StationCode = 1157, IndexStationAtLine = 6, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1118, StationCode = 1155, IndexStationAtLine = 7, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1118, StationCode = 1156, IndexStationAtLine = 8, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1118, StationCode = 1154, IndexStationAtLine = 9, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1118, StationCode = 1153, IndexStationAtLine = 10, IsDeleted = false, IsFirstStation = false, IsLastStation = true });

            stationsInLine.Add(new stationInLine() { LineId = 1119, StationCode = 1159, IndexStationAtLine = 1, IsDeleted = false, IsFirstStation = true, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1119, StationCode = 1160, IndexStationAtLine = 2, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1119, StationCode = 1151, IndexStationAtLine = 3, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1119, StationCode = 1161, IndexStationAtLine = 4, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1119, StationCode = 1142, IndexStationAtLine = 5, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1119, StationCode = 1144, IndexStationAtLine = 6, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1119, StationCode = 1141, IndexStationAtLine = 7, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1119, StationCode = 1140, IndexStationAtLine = 8, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1119, StationCode = 1136, IndexStationAtLine = 9, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1119, StationCode = 1138, IndexStationAtLine = 10, IsDeleted = false, IsFirstStation = false, IsLastStation = true });

            stationsInLine.Add(new stationInLine() { LineId = 1120, StationCode = 1138, IndexStationAtLine = 1, IsDeleted = false, IsFirstStation = true, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1120, StationCode = 1136, IndexStationAtLine = 2, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1120, StationCode = 1140, IndexStationAtLine = 3, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1120, StationCode = 1141, IndexStationAtLine = 4, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1120, StationCode = 1144, IndexStationAtLine = 5, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1120, StationCode = 1142, IndexStationAtLine = 6, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1120, StationCode = 1161, IndexStationAtLine = 7, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1120, StationCode = 1151, IndexStationAtLine = 8, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1120, StationCode = 1160, IndexStationAtLine = 9, IsDeleted = false, IsFirstStation = false, IsLastStation = false });
            stationsInLine.Add(new stationInLine() { LineId = 1120, StationCode = 1159, IndexStationAtLine = 10, IsDeleted = false, IsFirstStation = false, IsLastStation = true });
            #endregion
        }
        static void initFollowingStation()
        {
            #region initilized following station
            followingStations.Add(new FollowingStations { StationCode1 = 1111, StationCode2 = 1112, DistanceBetweenStations = (float)0.95, TimeTravelBetweenStations = (float)0.95 });
            followingStations.Add(new FollowingStations { StationCode1 = 1112, StationCode2 = 1113, DistanceBetweenStations = (float)0.29, TimeTravelBetweenStations = (float)0.29 });
            followingStations.Add(new FollowingStations { StationCode1 = 1113, StationCode2 = 1114, DistanceBetweenStations = (float)0.52, TimeTravelBetweenStations = (float)0.52 });
            followingStations.Add(new FollowingStations { StationCode1 = 1114, StationCode2 = 1115, DistanceBetweenStations = (float)1.43, TimeTravelBetweenStations = (float)1.43 });
            followingStations.Add(new FollowingStations { StationCode1 = 1115, StationCode2 = 1116, DistanceBetweenStations = (float)0.11, TimeTravelBetweenStations = (float)0.11 });
            followingStations.Add(new FollowingStations { StationCode1 = 1116, StationCode2 = 1117, DistanceBetweenStations = (float)0.36, TimeTravelBetweenStations = (float)0.36 });
            followingStations.Add(new FollowingStations { StationCode1 = 1117, StationCode2 = 1118, DistanceBetweenStations = (float)0.62, TimeTravelBetweenStations = (float)0.62 });
            followingStations.Add(new FollowingStations { StationCode1 = 1118, StationCode2 = 1119, DistanceBetweenStations = (float)0.1, TimeTravelBetweenStations = (float)0.1 });
            followingStations.Add(new FollowingStations { StationCode1 = 1119, StationCode2 = 1120, DistanceBetweenStations = (float)0.18, TimeTravelBetweenStations = (float)0.18 });

            followingStations.Add(new FollowingStations { StationCode1 = 1123, StationCode2 = 1124, DistanceBetweenStations = (float)1.62, TimeTravelBetweenStations = (float)1.62 });
            followingStations.Add(new FollowingStations { StationCode1 = 1124, StationCode2 = 1125, DistanceBetweenStations = (float)0.58, TimeTravelBetweenStations = (float)0.58 });
            followingStations.Add(new FollowingStations { StationCode1 = 1125, StationCode2 = 1126, DistanceBetweenStations = (float)0.51, TimeTravelBetweenStations = (float)0.51 });
            followingStations.Add(new FollowingStations { StationCode1 = 1126, StationCode2 = 1127, DistanceBetweenStations = (float)0.57, TimeTravelBetweenStations = (float)0.57 });
            followingStations.Add(new FollowingStations { StationCode1 = 1127, StationCode2 = 1128, DistanceBetweenStations = (float)0.45, TimeTravelBetweenStations = (float)0.45 });
            followingStations.Add(new FollowingStations { StationCode1 = 1128, StationCode2 = 1129, DistanceBetweenStations = (float)0.6, TimeTravelBetweenStations = (float)0.6 });
            followingStations.Add(new FollowingStations { StationCode1 = 1129, StationCode2 = 1131, DistanceBetweenStations = (float)0.59, TimeTravelBetweenStations = (float)0.59 });
            followingStations.Add(new FollowingStations { StationCode1 = 1131, StationCode2 = 1133, DistanceBetweenStations = (float)1.93, TimeTravelBetweenStations = (float)1.93 });
            followingStations.Add(new FollowingStations { StationCode1 = 1133, StationCode2 = 1135, DistanceBetweenStations = (float)0.38, TimeTravelBetweenStations = (float)0.38 });

            followingStations.Add(new FollowingStations { StationCode1 = 1125, StationCode2 = 1126, DistanceBetweenStations = (float)0.51, TimeTravelBetweenStations = (float)0.51 });
            followingStations.Add(new FollowingStations { StationCode1 = 1126, StationCode2 = 1128, DistanceBetweenStations = (float)1.01, TimeTravelBetweenStations = (float)1.01 });
            followingStations.Add(new FollowingStations { StationCode1 = 1128, StationCode2 = 1130, DistanceBetweenStations = (float)0.85, TimeTravelBetweenStations = (float)0.85 });
            followingStations.Add(new FollowingStations { StationCode1 = 1130, StationCode2 = 1132, DistanceBetweenStations = (float)1.07, TimeTravelBetweenStations = (float)1.07 });
            followingStations.Add(new FollowingStations { StationCode1 = 1132, StationCode2 = 1133, DistanceBetweenStations = (float)2.07, TimeTravelBetweenStations = (float)2.07 });
            followingStations.Add(new FollowingStations { StationCode1 = 1133, StationCode2 = 1134, DistanceBetweenStations = (float)0.17, TimeTravelBetweenStations = (float)0.17 });
            followingStations.Add(new FollowingStations { StationCode1 = 1134, StationCode2 = 1135, DistanceBetweenStations = (float)0.21, TimeTravelBetweenStations = (float)0.21 });



            followingStations.Add(new FollowingStations { StationCode1 = 1126, StationCode2 = 1117, DistanceBetweenStations = (float)111.91, TimeTravelBetweenStations = (float)111.91 });
            followingStations.Add(new FollowingStations { StationCode1 = 1120, StationCode2 = 1121, DistanceBetweenStations = (float)0.41, TimeTravelBetweenStations = (float)0.41 });
            followingStations.Add(new FollowingStations { StationCode1 = 1121, StationCode2 = 1122, DistanceBetweenStations = (float)0.38, TimeTravelBetweenStations = (float)0.38 });



            followingStations.Add(new FollowingStations { StationCode1 = 1114, StationCode2 = 1125, DistanceBetweenStations = (float)112.15, TimeTravelBetweenStations = (float)112.15 });
            followingStations.Add(new FollowingStations { StationCode1 = 1125, StationCode2 = 1130, DistanceBetweenStations = (float)1.40, TimeTravelBetweenStations = (float)1.40 });
            followingStations.Add(new FollowingStations { StationCode1 = 1130, StationCode2 = 1135, DistanceBetweenStations = (float)1.61, TimeTravelBetweenStations = (float)1.61 });
            followingStations.Add(new FollowingStations { StationCode1 = 1135, StationCode2 = 1132, DistanceBetweenStations = (float)1.96, TimeTravelBetweenStations = (float)1.96 });
            followingStations.Add(new FollowingStations { StationCode1 = 1132, StationCode2 = 1124, DistanceBetweenStations = (float)3.27, TimeTravelBetweenStations = (float)3.27 });
            followingStations.Add(new FollowingStations { StationCode1 = 1124, StationCode2 = 1123, DistanceBetweenStations = (float)0.57, TimeTravelBetweenStations = (float)0.57 });


            followingStations.Add(new FollowingStations { StationCode1 = 1137, StationCode2 = 1136, DistanceBetweenStations = (float)0.69, TimeTravelBetweenStations = (float)0.69 });
            followingStations.Add(new FollowingStations { StationCode1 = 1136, StationCode2 = 1139, DistanceBetweenStations = (float)0.75, TimeTravelBetweenStations = (float)0.75 });
            followingStations.Add(new FollowingStations { StationCode1 = 1139, StationCode2 = 1140, DistanceBetweenStations = (float)0.41, TimeTravelBetweenStations = (float)0.41 });
            followingStations.Add(new FollowingStations { StationCode1 = 1140, StationCode2 = 1141, DistanceBetweenStations = (float)1.13, TimeTravelBetweenStations = (float)1.13 });
            followingStations.Add(new FollowingStations { StationCode1 = 1141, StationCode2 = 1142, DistanceBetweenStations = (float)0.84, TimeTravelBetweenStations = (float)0.84 });
            followingStations.Add(new FollowingStations { StationCode1 = 1142, StationCode2 = 1143, DistanceBetweenStations = (float)0.72, TimeTravelBetweenStations = (float)0.72 });
            followingStations.Add(new FollowingStations { StationCode1 = 1143, StationCode2 = 1144, DistanceBetweenStations = (float)1.66, TimeTravelBetweenStations = (float)1.66 });
            followingStations.Add(new FollowingStations { StationCode1 = 1144, StationCode2 = 1145, DistanceBetweenStations = (float)1.62, TimeTravelBetweenStations = (float)1.62 });
            followingStations.Add(new FollowingStations { StationCode1 = 1145, StationCode2 = 1146, DistanceBetweenStations = (float)1.81, TimeTravelBetweenStations = (float)1.81 });
            followingStations.Add(new FollowingStations { StationCode1 = 1146, StationCode2 = 1147, DistanceBetweenStations = (float)0.38, TimeTravelBetweenStations = (float)0.38 });


            followingStations.Add(new FollowingStations { StationCode1 = 1147, StationCode2 = 1148, DistanceBetweenStations = (float)1.18, TimeTravelBetweenStations = (float)1.18 });
            followingStations.Add(new FollowingStations { StationCode1 = 1148, StationCode2 = 1149, DistanceBetweenStations = (float)0.74, TimeTravelBetweenStations = (float)0.74 });
            followingStations.Add(new FollowingStations { StationCode1 = 1149, StationCode2 = 1145, DistanceBetweenStations = (float)2.01, TimeTravelBetweenStations = (float)2.01 });
            followingStations.Add(new FollowingStations { StationCode1 = 1145, StationCode2 = 1144, DistanceBetweenStations = (float)2.37, TimeTravelBetweenStations = (float)2.37 });
            followingStations.Add(new FollowingStations { StationCode1 = 1144, StationCode2 = 1142, DistanceBetweenStations = (float)2.2, TimeTravelBetweenStations = (float)2.2 });
            followingStations.Add(new FollowingStations { StationCode1 = 1142, StationCode2 = 1150, DistanceBetweenStations = (float)2.93, TimeTravelBetweenStations = (float)2.93 });
            followingStations.Add(new FollowingStations { StationCode1 = 1150, StationCode2 = 1136, DistanceBetweenStations = (float)3.67, TimeTravelBetweenStations = (float)3.67 });
            followingStations.Add(new FollowingStations { StationCode1 = 1136, StationCode2 = 1137, DistanceBetweenStations = (float)0.69, TimeTravelBetweenStations = (float)0.69 });
            followingStations.Add(new FollowingStations { StationCode1 = 1137, StationCode2 = 1138, DistanceBetweenStations = (float)1.12, TimeTravelBetweenStations = (float)1.12 });

            followingStations.Add(new FollowingStations { StationCode1 = 1161, StationCode2 = 1160, DistanceBetweenStations = (float)2.03, TimeTravelBetweenStations = (float)2.03 });
            followingStations.Add(new FollowingStations { StationCode1 = 1160, StationCode2 = 1151, DistanceBetweenStations = (float)1.03, TimeTravelBetweenStations = (float)1.03 });
            followingStations.Add(new FollowingStations { StationCode1 = 1151, StationCode2 = 1152, DistanceBetweenStations = (float)1.23, TimeTravelBetweenStations = (float)1.23 });
            followingStations.Add(new FollowingStations { StationCode1 = 1152, StationCode2 = 1158, DistanceBetweenStations = (float)2.24, TimeTravelBetweenStations = (float)2.24 });
            followingStations.Add(new FollowingStations { StationCode1 = 1158, StationCode2 = 1157, DistanceBetweenStations = (float)1.03, TimeTravelBetweenStations = (float)1.03 });
            followingStations.Add(new FollowingStations { StationCode1 = 1157, StationCode2 = 1155, DistanceBetweenStations = (float)0.7, TimeTravelBetweenStations = (float)0.7 });
            followingStations.Add(new FollowingStations { StationCode1 = 1155, StationCode2 = 1156, DistanceBetweenStations = (float)0.67, TimeTravelBetweenStations = (float)0.67 });
            followingStations.Add(new FollowingStations { StationCode1 = 1156, StationCode2 = 1154, DistanceBetweenStations = (float)1.5, TimeTravelBetweenStations = (float)1.5 });
            followingStations.Add(new FollowingStations { StationCode1 = 1154, StationCode2 = 1153, DistanceBetweenStations = (float)1.06, TimeTravelBetweenStations = (float)1.06 });


            followingStations.Add(new FollowingStations { StationCode1 = 1159, StationCode2 = 1160, DistanceBetweenStations = (float)0.43, TimeTravelBetweenStations = (float)0.43 });
            followingStations.Add(new FollowingStations { StationCode1 = 1160, StationCode2 = 1151, DistanceBetweenStations = (float)1.03, TimeTravelBetweenStations = (float)1.03 });
            followingStations.Add(new FollowingStations { StationCode1 = 1151, StationCode2 = 1161, DistanceBetweenStations = (float)0.96, TimeTravelBetweenStations = (float)0.96 });
            followingStations.Add(new FollowingStations { StationCode1 = 1161, StationCode2 = 1142, DistanceBetweenStations = (float)130.48, TimeTravelBetweenStations = (float)130.48 });
            followingStations.Add(new FollowingStations { StationCode1 = 1142, StationCode2 = 1144, DistanceBetweenStations = (float)1.47, TimeTravelBetweenStations = (float)1.47 });
            followingStations.Add(new FollowingStations { StationCode1 = 1144, StationCode2 = 1141, DistanceBetweenStations = (float)1.85, TimeTravelBetweenStations = (float)1.85 });
            followingStations.Add(new FollowingStations { StationCode1 = 1141, StationCode2 = 1140, DistanceBetweenStations = (float)0.84, TimeTravelBetweenStations = (float)0.84 });
            followingStations.Add(new FollowingStations { StationCode1 = 1140, StationCode2 = 1136, DistanceBetweenStations = (float)0.68, TimeTravelBetweenStations = (float)0.68 });
            followingStations.Add(new FollowingStations { StationCode1 = 1136, StationCode2 = 1138, DistanceBetweenStations = (float)1.64, TimeTravelBetweenStations = (float)1.64 });

            followingStations.Add(new FollowingStations { StationCode1 = 1138, StationCode2 = 1136, DistanceBetweenStations = (float)1.78, TimeTravelBetweenStations = (float)1.78 });
            followingStations.Add(new FollowingStations { StationCode1 = 1136, StationCode2 = 1140, DistanceBetweenStations = (float)0.73, TimeTravelBetweenStations = (float)0.73 });
            followingStations.Add(new FollowingStations { StationCode1 = 1141, StationCode2 = 1144, DistanceBetweenStations = (float)1.61, TimeTravelBetweenStations = (float)1.61 });
            followingStations.Add(new FollowingStations { StationCode1 = 1144, StationCode2 = 1142, DistanceBetweenStations = (float)2.20, TimeTravelBetweenStations = (float)2.20 });
            followingStations.Add(new FollowingStations { StationCode1 = 1142, StationCode2 = 1161, DistanceBetweenStations = (float)129.82, TimeTravelBetweenStations = (float)129.82 });
            followingStations.Add(new FollowingStations { StationCode1 = 1161, StationCode2 = 1151, DistanceBetweenStations = (float)1.62, TimeTravelBetweenStations = (float)1.62 });
            followingStations.Add(new FollowingStations { StationCode1 = 1151, StationCode2 = 1160, DistanceBetweenStations = (float)1.30, TimeTravelBetweenStations = (float)1.30 });
            followingStations.Add(new FollowingStations { StationCode1 = 1160, StationCode2 = 1159, DistanceBetweenStations = (float)0.62, TimeTravelBetweenStations = (float)0.62 });
            #endregion
        }

        static void initUser()
        {
            #region
            users.Add(new User { UserName = "RenanaC", Password = "RenanaC123", ManagePermission = true });
            users.Add(new User { UserName = "NaamaK", Password = "Naama206", ManagePermission = false });
            users.Add(new User { UserName = "naama", Password = "123", ManagePermission = true });
            users.Add(new User { UserName = "naamaa", Password = "123", ManagePermission = false });

            #endregion
        }
        static void initLineTrip()
        {
            #region initilized line trip
            lineTrips.Add(new LineTrip
            {
                LineId = 1111,
                NumLine = 1,
                StartAt = new TimeSpan(11, 00, 00),
                EndAt = new TimeSpan(16, 00, 00),
                Frequency = 15
            });
            lineTrips.Add(new LineTrip
            {
                LineId = 1111,
                NumLine = 1,
                StartAt = new TimeSpan(16, 00, 00),

                EndAt = new TimeSpan(20, 00, 00),
                Frequency = 20
            });
            lineTrips.Add(new LineTrip
            {
                LineId = 1114,
                NumLine = 418,
                StartAt = new TimeSpan(16, 00, 00),

                EndAt = new TimeSpan(20, 00, 00),
                Frequency = 15
            });
            lineTrips.Add(new LineTrip
            {
                LineId = 1114,
                NumLine = 418,
                StartAt = new TimeSpan(20, 00, 00),

                EndAt = new TimeSpan(23, 00, 00),
                Frequency = 20
            }); lineTrips.Add(new LineTrip
            {
                LineId = 1111,
                NumLine = 1,
                StartAt = new TimeSpan(20, 00, 00),

                EndAt = new TimeSpan(23, 00, 00),
                Frequency = 15
            });
            #endregion
        }


    }
}
