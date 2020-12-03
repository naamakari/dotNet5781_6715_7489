using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_6715_7489
{
    public enum state {ready, inDrive, inRefule, inTreat };
    public class Bus
    {
        private string id;
        public string Id//property
        { 
            get { return id; }
            private set { id = value; }
        }
        public DateTime StartDate { get; set; }
        public DateTime LastTreatDate { get; set; }
        private double kilometrazh;
        public double Kilometrazh//property
        {
            get { return kilometrazh; }
            private set { kilometrazh = value; }
        }
        public double stateOfFuel { get; set; }
        public double kmSinceLastTreat { get; set; }
        public state stateBus
        {
            get;
            set;
        }

        //constructor
        public Bus(string idNumber, DateTime firstDate, DateTime TreatDate, double kmSinceTreat, double fuel = 0.0, double km = 0.0)
        {
            Id = idNumber;
            StartDate = firstDate;
            LastTreatDate = TreatDate;
            Kilometrazh = km;
            stateOfFuel = fuel;
            kmSinceLastTreat = kmSinceTreat;
            stateBus = state.ready;
        }
        public Bus(string idNumber, DateTime firstDate, DateTime TreatDate, double kmSinceTreat, state sta, double fuel = 0.0, double km = 0.0)
        {
            Id = idNumber;
            StartDate = firstDate;
            LastTreatDate = TreatDate;
            Kilometrazh = km;
            stateOfFuel = fuel;
            kmSinceLastTreat = kmSinceTreat;
            stateBus = sta;
        }
        public void upDateDetails(double dist)
        {
            Kilometrazh += dist;
            stateOfFuel += dist;
            kmSinceLastTreat += dist;
        }
        //function that checks if the bus can take the current driving
        public void checkingBusFit(int numberOfKm)
        {
            TimeSpan diff = DateTime.Now - LastTreatDate;//the difference between the last treat day and today
            if (stateOfFuel + numberOfKm <= 1200)//can take the driving from the fuel aspect
                if (diff.TotalDays < 365 && kmSinceLastTreat + numberOfKm <= 20000)//can take the driving from the treat aspect
                {
                    Kilometrazh += numberOfKm;
                    stateOfFuel += numberOfKm;
                    kmSinceLastTreat += numberOfKm;
                    Console.WriteLine("The bus can take the driving, have a good day!");
                }

                else Console.WriteLine("The bus can not take the driving, take it to a treat!!");
            else Console.WriteLine("The bus can not take the driving, take it to refuel!");

        }

        //function that update the refuel
        public void refuel()
        {
            stateOfFuel = 0.0;
            Console.WriteLine("The bus refueled");
        }

        //function that update the date of the last treat and the km since the last treat
        public void treat()
        {
            LastTreatDate = DateTime.Now;
            kmSinceLastTreat = 0.0;
            Console.WriteLine("The bus was taken care");
        }

        //function that prints the number license of the bus and the km since the last treat
        public void printBus(int index)
        {
            Console.Write("Bus #{0}: ", index);
            if (id.Length == 8)
            {
                for (int i = 0; i < 3; i++)
                    Console.Write(id[i]);
                Console.Write("-");
                for (int i = 3; i < 5; i++)
                    Console.Write(id[i]);
                Console.Write("-");
                for (int i = 5; i < 8; i++)
                    Console.Write(id[i]);
            }
            else//if(id.length==7)
            {
                for (int i = 0; i < 2; i++)
                    Console.Write(id[i]);
                Console.Write("-");
                for (int i = 2; i < 5; i++)
                    Console.Write(id[i]);
                Console.Write("-");
                for (int i = 5; i < 7; i++)
                    Console.Write(id[i]);
            }


            Console.WriteLine("-> " + kmSinceLastTreat);
        }
    }
}

