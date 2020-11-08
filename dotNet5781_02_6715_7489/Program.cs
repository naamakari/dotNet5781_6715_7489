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
        static public void AddLine(CollectionOfLines lineSystem, List<LineBusStation> allStation)
        {
            int startCode, destCode;
            LineBusStation startStation, destStation;
            //data reception for creating a new line
            Console.WriteLine("enter a start station code and a destination station code");
            int.TryParse(Console.ReadLine(), out startCode);
            int.TryParse(Console.ReadLine(), out destCode);
            //finds the required stations
            startStation = allStation.Find(x => x.Station.StationCode == startCode);
            destStation = allStation.Find(x => x.Station.StationCode == destCode);

            LineOfBus bus = new LineOfBus(startStation, destStation, (Area)rand.Next(0, 5));
            lineSystem.Lines.Add(bus);
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
        static public void printPossiblePathes(CollectionOfLines allLines, int start, int destination)
        {
            List<LineOfBus> startStation, destinationStation, returnList;
            returnList = new List<LineOfBus>();
            //function that return list of lines that pass at the station
            startStation = allLines.LineAcordingStation(start);
            destinationStation = allLines.LineAcordingStation(destination);
            foreach (LineOfBus item1 in startStation)
                foreach (LineOfBus item2 in destinationStation)
                    //checks if the numbers of the lines are the same
                    if (item1.NumLine == item2.NumLine)
                            returnList.Add(item1);
            returnList.Sort();
            Console.WriteLine("Possible routes for travel: ");
            foreach (LineOfBus item in returnList)
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

            int choise, numLine, codeSt, start, destination;
            char charChoise;
            LineOfBus deBus;
            LineBusStation deStation;


            List<LineBusStation> allStation = new List<LineBusStation>();
            CollectionOfLines allLines = new CollectionOfLines();
            string address = "a";
            for (int i = 0; i < 40; i++, address += "h")
                allStation.Add(new LineBusStation(address));
            for (int i = 0; i < 10; i++)
                allLines[i] = new LineOfBus(allStation[rand.Next(0, 40)], allStation[rand.Next(0, 40)], (Area)rand.Next(0, 5));
            foreach (LineOfBus item in allLines)
                Console.WriteLine(item);

            for (int i = 0; i < 5; i++)
                allLines[0].AddRemoveStation(allStation[i], 'a', i + 1);
            for (int i = 1; i < 6; i++)
                allLines[1].AddRemoveStation(allStation[i + 3], 'a', i);
            for (int i = 1; i < 6; i++)
                allLines[2].AddRemoveStation(allStation[i + 8], 'a', i);
            for (int i = 1; i < 6; i++)
                allLines[3].AddRemoveStation(allStation[i + 12], 'a', i);
            for (int i = 1; i < 6; i++)
                allLines[4].AddRemoveStation(allStation[i + 17], 'a', i);
            for (int i = 1; i < 6; i++)
                allLines[5].AddRemoveStation(allStation[i + 22], 'a', i);
            for (int i = 1; i < 6; i++)
                allLines[6].AddRemoveStation(allStation[i + 26], 'a', i);
            for (int i = 1; i < 6; i++)
                allLines[7].AddRemoveStation(allStation[i + 30], 'a', i);
            for (int i = 1; i < 5; i++)
                allLines[8].AddRemoveStation(allStation[i + 34], 'a', i);
            //allLines[8].AddRemoveStation(allStation[36], 'a', 1);
            //allLines[8].AddRemoveStation(allStation[37], 'a', 2);
            //allLines[8].AddRemoveStation(allStation[38], 'a', 3);
            //allLines[8].AddRemoveStation(allStation[39], 'a', 4);
            ////  allLines[8].AddRemoveStation(allStation[40], 'a', 5);



            allLines[9].AddRemoveStation(allStation[0], 'a', 1);
            allLines[9].AddRemoveStation(allStation[4], 'a', 2);
            allLines[9].AddRemoveStation(allStation[7], 'a', 3);
            allLines[9].AddRemoveStation(allStation[9], 'a', 4);
            allLines[9].AddRemoveStation(allStation[13], 'a', 5);
            allLines[9].AddRemoveStation(allStation[18], 'a', 6);
            allLines[9].AddRemoveStation(allStation[23], 'a', 7);
            allLines[9].AddRemoveStation(allStation[27], 'a', 8);
            foreach (LineOfBus item in allLines)
                Console.WriteLine(item);


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
                                AddLine(allLines, allStation);
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
                            Console.WriteLine("enter 'l' for remove line or 's' for remove station");
                            char.TryParse(Console.ReadLine(), out charChoise);
                            if (charChoise == 'l')
                            {
                                Console.WriteLine("enter the line number that you want to delete");
                                int.TryParse(Console.ReadLine(), out numLine);
                                deBus = allLines.Lines.Find(x => x.NumLine == numLine);
                                allLines.Lines.Remove(deBus);
                            }
                            else if (charChoise == 's')
                            {
                                Console.WriteLine("enter the station code that you want delete");
                                int.TryParse(Console.ReadLine(), out codeSt);
                                deStation = allStation.Find(x => x.Station.StationCode == codeSt);
                                allStation.Remove(deStation);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter 's' to see all the lines that pass in specific statiom");
                            Console.WriteLine("Enter 'p' to see possible path between 2 stations");
                            char.TryParse(Console.ReadLine(), out charChoise);
                            if (charChoise == 's')
                            {
                                Console.WriteLine("enter the code of the ststion that you want");
                                int.TryParse(Console.ReadLine(), out codeSt);
                                allLines.LineAcordingStation(codeSt);
                            }
                            else if (charChoise == 'p')
                            {
                                //data reception for creating a new line
                                Console.WriteLine("enter a start station code and a destination station code");
                                int.TryParse(Console.ReadLine(), out start);
                                int.TryParse(Console.ReadLine(), out destination);

                                printPossiblePathes(allLines, start, destination);
                            }
                            else
                                throw new ArgumentException("invalid choice");
                            break;
                        case 4:
                            Console.WriteLine("Enter 'l' to print all the lines of the system");
                            Console.WriteLine("Enter 's' to see all the station");
                            char.TryParse(Console.ReadLine(), out charChoise);
                            if (charChoise == 'l')
                            {
                                foreach (LineOfBus item in allLines)
                                    Console.WriteLine(item);
                            }
                            else if (charChoise == 's')
                            {
                                foreach (LineBusStation item in allStation)
                                    Console.WriteLine(item);
                            }
                            else
                                throw new ArgumentException("invalid choice");
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
