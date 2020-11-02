using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_6715_7489
{

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

        //function that return specific bus from the list of the buses
        static public Bus returnBusFromList(List<Bus> listOfBuses, string licenseNumber)
        {
            foreach (Bus item in listOfBuses)//pass all over the list
                if (item.Id == licenseNumber)
                    return item;
            return null;
        }
        static public Random rand = new Random(DateTime.Now.Millisecond);
        static void Main(string[] args)
        {
            Console.WriteLine("Buses System");
            Console.WriteLine("Choose one of the following:");
            Console.WriteLine("Enter 1 to add bus to the system");
            Console.WriteLine("Enter 2 to choose bus to driving");
            Console.WriteLine("Enter 3 to refuel the bus or take care of the bus");
            Console.WriteLine("Enter 4 to present all the driving information");
            Console.WriteLine("Enter 0 to exit from the system");

            int choise, counter=0;
            string licenseNumber;
            DateTime StarDate;
            DateTime treaDate;
            double stateFuel;
            double kilometer;
            double kmSinceTreat;
            Bus bus;

            List<Bus> listOfBuses = new List<Bus>();
   
            do
            {
                int.TryParse(Console.ReadLine(), out choise);
                switch (choise)
                {

                    case 1://add bus to the system
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
                        while ((StarDate.Year >= 2018 && licenseNumber.Length != 8) ||
                            (StarDate.Year < 2018 && licenseNumber.Length != 7));

                        //input the kilometer and checks the correctness of the input
                        do
                        {
                            Console.WriteLine("Enter the mileage of the bus: ");
                            double.TryParse(Console.ReadLine(), out kilometer);
                        }
                        while (kilometer < 0);

                        //input the stateFuel and checks the correctness of the input
                        do
                        {
                            Console.WriteLine("Enter the number of miles since the last refueling: ");
                            double.TryParse(Console.ReadLine(), out stateFuel);
                        }
                        while (stateFuel < 0);

                        //input the kmSinceTreat and checks the correctness of the input
                        do
                        {
                            Console.WriteLine("Enter the miles the bus drived since the last treat: ");
                            double.TryParse(Console.ReadLine(), out kmSinceTreat);
                        }
                        while (kmSinceTreat < 0);

                        //sending to the constructor
                        bus = new Bus(licenseNumber, StarDate, treaDate, kmSinceTreat, stateFuel, kilometer);
                      //add the new bus to the list
                        listOfBuses.Add(bus);
                        break;
                    case 2://choose a bus to a driving
                        do
                        {
                            Console.WriteLine("Enter the license number: ");
                            licenseNumber = Console.ReadLine();
                        }
                        while (licenseNumber.Length != 8 && licenseNumber.Length != 7);
                        int numberOfKm = rand.Next(1201);//choose a random number

                        //check if the bus is exist at the system
                        bus = returnBusFromList(listOfBuses, licenseNumber);
                        if (bus == null)
                        {
                            Console.WriteLine("The bus isn't exist at the system");
                            break;
                        }
                        else
                            bus.checkingBusFit(numberOfKm);
                        break;
                    case 3://treat/refuel
                        do
                        {
                            Console.WriteLine("Enter the license number: ");
                            licenseNumber = Console.ReadLine();
                        }
                        while (licenseNumber.Length != 8 && licenseNumber.Length != 7);
                        //check if the bus is exist at the system
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
                    case 4://print all the buses at the system
                        counter = 0;
                        foreach(Bus item in listOfBuses)
                        {
                            counter++;
                            item.printBus(counter);
                        }
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("ERROR");
                        break;

                }
                Console.WriteLine();
                Console.WriteLine("Choose one of the following:");
            } while (choise != 0);
        }
       
    }
}
//Buses System
//Choose one of the following:
//Enter 1 to add bus to the system
//Enter 2 to choose bus to driving
//Enter 3 to refuel the bus or take care of the bus
//Enter 4 to present all the driving information
//Enter 0 to exit from the system
//1
//Enter the date of commencement of activity
//Year: 2000
//Month: 12
//Day: 3
//Enter the date of last treat of the bus:
//Year: 2020
//Month: 5
//Day: 3
//Enter the license number:
//0000001
//Enter the mileage of the bus:
//30000
//Enter the number of miles since the last refueling:
//0
//Enter the miles the bus drived since the last treat:
//15000

//Choose one of the following:
//1
//Enter the date of commencement of activity
//Year: 2019
//Month: 8
//Day: 14
//Enter the date of last treat of the bus:
//Year: 2020
//Month: 8
//Day: 1
//Enter the license number:
//00000002
//Enter the mileage of the bus:
//100000
//Enter the number of miles since the last refueling:
//1199
//Enter the miles the bus drived since the last treat:
//1000

//Choose one of the following:
//1
//Enter the date of commencement of activity
//Year: 1998
//Month: 12
//Day: 23
//Enter the date of last treat of the bus:
//Year: 2000
//Month: 10
//Day: 2
//Enter the license number:
//0000003
//Enter the mileage of the bus:
//150000
//Enter the number of miles since the last refueling:
//1000
//Enter the miles the bus drived since the last treat:
//10000

//Choose one of the following:
//1
//Enter the date of commencement of activity
//Year: 2005
//Month: 12
//Day: 23
//Enter the date of last treat of the bus:
//Year: 2020
//Month: 6
//Day: 1
//Enter the license number:
//0000004
//Enter the mileage of the bus:
//30000
//Enter the number of miles since the last refueling:
//5
//Enter the miles the bus drived since the last treat:
//20000

//Choose one of the following:
//4
//Bus #1: 00-000-01-> 15000
//Bus #2: 000-00-002-> 1000
//Bus #3: 00-000-03-> 10000
//Bus #4: 00-000-04-> 20000

//Choose one of the following:
//2
//Enter the license number:
//00000002
//The bus can not take the driving, take it to refuel!

//Choose one of the following:
//3
//Enter the license number:
//00000002
//Enter r for refuel and t for treat:
//r
//The bus refueled

//Choose one of the following:
//2
//Enter the license number:
//0000004
//The bus can not take the driving, take it to a treat!!

//Choose one of the following:
//3
//Enter the license number:
//0000004
//Enter r for refuel and t for treat:
//t
//The bus was taken care

//Choose one of the following:
//2
//Enter the license number:
//00000002
//The bus can take the driving, have a good day!

//Choose one of the following:
//2
//Enter the license number:
//0000004
//The bus can take the driving, have a good day!

//Choose one of the following:
//4
//Bus #1: 00-000-01-> 15000
//Bus #2: 000-00-002-> 1177
//Bus #3: 00-000-03-> 10000
//Bus #4: 00-000-04-> 106

//Choose one of the following:
//0
