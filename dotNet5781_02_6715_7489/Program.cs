using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6715_7489
{
    class Program
    {
        static public void AddLine(CollectionOfLines lineSystem)
        {

        }

        static public void AddStation(CollectionOfLines lineSystem, int numLine, List<LineBusStation> allStation)
        {
            int index, numSt, numStBefore;
            LineBusStation newStation;
            index = lineSystem.Lines.FindIndex(x => x.NumLine == numLine);//find the line that we want to insert the new station

            //receiving details about the station you want to add
            Console.WriteLine("enter the code of the station that you want to add");
            int.TryParse(Console.ReadLine(), out numSt);
            Console.WriteLine("enter the code of the station after which you want to add," +
                " if you want to add a first station - enter 0");
            int.TryParse(Console.ReadLine(), out numStBefore);
            newStation = allStation.Find(x => x.Station.StationCode == numSt);//return the specific statio
            lineSystem[index].AddRemoveStation(newStation, 'a', numStBefore);//add the station for the line
        }
        public void printPossiblePathes(CollectionOfLines allLines, int start, int destination)
        {
            List<LineOfBus> startStation, destinationStation,returnList;
            returnList = new List<LineOfBus>();
            //function that return list of lines that pass at the station
            startStation = allLines.LineAcordingStation(start);
            destinationStation = allLines.LineAcordingStation(destination);
            foreach (LineOfBus item1 in startStation)
                foreach (LineOfBus item2 in destinationStation)
                    //checks if the numbers of the lines are the same
                    if (item1.NumLine == item2.NumLine)
                        //checks if the lines are the same and not the opossite line
                        if (item1.FirstStation.CompareTo(item2.FirstStation) == 0)
                            returnList.Add(item1);
            returnList.Sort();
            Console.WriteLine("Possible routes for travel: ");
            foreach(LineOfBus item in returnList)
                Console.WriteLine(item);
                            }


        static public Random rand = new Random(DateTime.Now.Millisecond);
        static void Main(string[] args)
        {
            Console.WriteLine("Lines of System");
            Console.WriteLine("Choose one of the following:");
            Console.WriteLine("Enter 1 to add line of bus/station to line of bus");
            Console.WriteLine("Enter 2 to deleteline of bus/station to line of bus");
            Console.WriteLine("Enter 3 to look for lines that pass through a particular" +
                    " station or look for a route between 2 stations");
            Console.WriteLine("Enter 4 to print all the lines of buses or all the station");
            Console.WriteLine("Enter 0 to exit from the system");

            int choise;
            char charChoise;
            int numLine;


            List<LineBusStation> allStation = new List<LineBusStation>();
            CollectionOfLines allLines = new CollectionOfLines();
            string address = "a";
            for (int i = 0; i < 40; i++, address += "h")
                allStation.Add(new LineBusStation(address));
            for (int i = 0; i < 10; i++)
                allLines[i] = new LineOfBus(allStation[rand.Next(0, 40)], allStation[rand.Next(0, 40)],(Area)rand.Next(0, 5));
            foreach (LineBusStation item in allStation)
                Console.WriteLine(item.Station);




            {
                int.TryParse(Console.ReadLine(), out choise);
                try
                {
                    switch (choise)
                    {
                        case 1:
                            Console.WriteLine("enter 'l' for add line or 's' for add station");
                            char.TryParse(Console.ReadLine(), out charChoise);
                            if (charChoise == 'l')
                                AddLine(allLines);
                            else if (charChoise == 's')
                            {
                                Console.WriteLine("enter the line number where you want to add a station");
                                int.TryParse(Console.ReadLine(), out numLine);
                                AddStation(allLines, numLine, allStation);
                            }
                            else
                                throw new ArgumentException("invalid choice");
                            break;
                        case 2:
                            break;
                        case 3:printPossiblePathes(allLines,start, destination);
                          
                            break;
                        case 4:
                            break;
                        case 0:
                            break;
                        default:
                            throw new ArgumentException("invalid choice");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();
                Console.WriteLine("Choose one of the following:");
            } while (choise != 0) ;

            Console.ReadKey();
        }
    }
}
