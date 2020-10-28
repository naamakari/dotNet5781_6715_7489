using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_6715_7489
{

    class Bus
    {
        private string id;
        public string Id
        {
            get { return id; }
            private set { id = value; }
        }
        public DateTime StartDate;
        public DateTime LastTreatDate;
        private double kilometrazh;
        public double Kilometrazh
        {
            get { return kilometrazh; }
            private set { kilometrazh = value; }
        }
        public double stateOfFuel;
        public double kmSinceLastTreat;
        public Bus(string idNumber, DateTime firstDate, DateTime TreatDate, double kmSinceTreat, double fuel = 0.0, double km = 0.0)
        {
            Id = idNumber;
            StartDate = firstDate;
            LastTreatDate = TreatDate;
            Kilometrazh = km;
            stateOfFuel = fuel;
            kmSinceLastTreat = kmSinceTreat;
        }
        public void checkingBusFit(int numberOfKm)
        {
            TimeSpan diff = DateTime.Now - LastTreatDate;
            if (stateOfFuel + numberOfKm <= 1200)//can take the driving from the fuel aspect
                if (diff.TotalDays < 365 && kmSinceLastTreat + numberOfKm <= 20000)//can take the driving from the treat aspect
                {
                    Kilometrazh += numberOfKm;
                    stateOfFuel += numberOfKm;
                    kmSinceLastTreat += numberOfKm;
                }

                else Console.WriteLine("The bus can not take the driving, take it to a treat!!");
            else Console.WriteLine("The bus can not take the driving, take it to refuel!");
        }
        public void refuel()
        {
            stateOfFuel = 0.0;
        }
        public void treat()
        {
            LastTreatDate = DateTime.Now;
            kmSinceLastTreat = 0.0;
        }
        static int index=0;//counter for printing the bus method
        public void printBus()
        {
            index++;
            Console.Write("Bus #{0} :",index);
            Console.WriteLine(Id+"-> "+ LastTreatDate);
        }
    }
    class Program
    {

        static public DateTime getDateFromUser()
        {
            //input the date and check the correctness of the input
            int tempYear, tempMonth, tempDay;
            DateTime date;
            do
            {
                Console.Write("Year: ");
                tempYear = int.Parse(Console.ReadLine());
            } while (tempYear < 1990 || tempYear > 2020);
            do
            {
                Console.Write("Month: ");
                tempMonth = int.Parse(Console.ReadLine());
            } while (tempMonth < 1 || tempMonth > 12);
            do
            {
                Console.Write("Day: ");
                tempDay = int.Parse(Console.ReadLine());
            } while (tempDay < 1 || tempDay > 31);
            date = new DateTime(tempYear, tempMonth, tempDay);
            return date;

        }
        static public Bus returnBusFromList(List<Bus> listOfBuses, string licenseNumber)
        {
            foreach (Bus item in listOfBuses)
                if (item.Id == licenseNumber)
                    return item;
            return null;
        }
        static public Random rand = new Random(DateTime.Now.Millisecond);
        enum Options { Exit, AddBus, ChooseBus, RefuelOrCare, StateOfTheBuses }
        static void Main(string[] args)
        {
            Console.WriteLine("Buses System");
            Console.WriteLine("Choose one of the following:");
            Console.WriteLine("Enter 1 to add bus to the system");
            Console.WriteLine("Enter 2 to choose bus to driving");
            Console.WriteLine("Enter 3 to refuel the bus or take care of the bus");
            Console.WriteLine("Enter 4 to present all the driving information");
            Console.WriteLine("Enter 0 to exit from the system");

            int choise;
            string licenseNumber;
            DateTime StarDate;
            DateTime treaDate;
            double stateFuel;
            double kilometer;
            double kmSinceTreat;
            Bus bus;

            List<Bus> listOfBuses = new List<Bus>();
            // string ch;
            do
            {

                //ch = Console.ReadLine();
                int.TryParse(Console.ReadLine(), out choise);
                switch (choise)
                {

                    case 1:
                        Console.WriteLine("Enter the date of commencement of activity");
                        StarDate = getDateFromUser();

                        Console.WriteLine("Enter the date of last treat of the bus: ");
                        treaDate = getDateFromUser();

                        //input the license number and checks the correctness of the input
                        do
                        {
                            Console.WriteLine("Enter the license number: ");
                            licenseNumber = Console.ReadLine();
                        }
                        while ((StarDate.Day >= 2018 && licenseNumber.Length != 8) ||
                            (StarDate.Day < 2018 && licenseNumber.Length != 7));


                        Console.WriteLine("Enter the number of miles since the last refueling: ");
                        double.TryParse(Console.ReadLine(), out stateFuel);

                        Console.WriteLine("Enter the mileage of the bus: ");
                        double.TryParse(Console.ReadLine(), out kilometer);

                        Console.WriteLine("Enter the miles the bus drived since the last treat: ");
                        double.TryParse(Console.ReadLine(), out kmSinceTreat);


                        bus = new Bus(licenseNumber, StarDate, treaDate, kmSinceTreat, stateFuel, kilometer);
                        listOfBuses.Add(bus);
                        break;
                    case 2:
                        do
                        {
                            Console.WriteLine("Enter the license number: ");
                            licenseNumber = Console.ReadLine();
                        }
                        while (licenseNumber.Length != 8 && licenseNumber.Length != 7);
                        int numberOfKm = rand.Next(20001);

                        bus = returnBusFromList(listOfBuses, licenseNumber);
                        if (bus == null)
                        {
                            Console.WriteLine("The bus isn't exist at the system");
                            break;
                        }
                        else
                            bus.checkingBusFit(numberOfKm);
                        break;
                    case 3:
                        do
                        {
                            Console.WriteLine("Enter the license number: ");
                            licenseNumber = Console.ReadLine();
                        }
                        while (licenseNumber.Length != 8 && licenseNumber.Length != 7);

                        bus = returnBusFromList(listOfBuses, licenseNumber);

                        if (bus == null)
                        {
                            Console.WriteLine("The bus isn't exist at the system");
                            break;
                        }

                        Console.WriteLine("Enter r for refuel and t for treat: ");
                        char treatOrRefuel;
                        char.TryParse(Console.ReadLine(), out treatOrRefuel);
                        if (treatOrRefuel == 'r')
                            bus.refuel();
                        else if (treatOrRefuel == 't')
                            bus.treat();
                        else
                        {
                            Console.WriteLine("The character is invalid!");
                            break;
                        }
                        break;
                    case 4:foreach(Bus item in listOfBuses)
                        {
                            item.printBus();
                        }
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("ERROR");
                        break;


                }

            } while (choise != 0);

        }
    }
}
