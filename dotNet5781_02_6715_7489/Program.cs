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
            lineSystem.
        }

        static public void AddStation(CollectionOfLines lineSystem, int numLine)
        {
            int index, numSt, numStBefore;
            LineBusStation newStation;
             index =lineSystem.Lines.FindIndex(x => x.NumLine == numLine);//find the line that we want to insert the new station

            //receiving details about the station you want to add
            Console.WriteLine("enter the code of the station that you want to add");
            int.TryParse(Console.ReadLine(),out numSt);
            Console.WriteLine("enter the code of the station after which you want to add," +
                " if you want to add a first station - enter 0");
            int.TryParse(Console.ReadLine(), out numStBefore);

            newStation = lineSystem.Lines[index].Search(numSt);

            lineSystem.Lines[index].AddRemoveStation(newStation,'a',numStBefore);
        }
     
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


            CollectionOfLines lineSystem = new CollectionOfLines();
            //לדעתי כדאי את כל 40 התחנות להכניס ישירות לרישמה הזו וכך נוכל להדפיס בסוף
            List<BusStation> allStation = new List<BusStation>();
            //לדוגמא
            allStation.Add(new BusStation());
            //אולי אפשר אפילו לעשות לולאת פור של 40 תחנות ובתוך הלולאה לכתוב את השורה הזאת
            
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
                                AddLine(lineSystem);
                            else if (charChoise == 's')
                            {
                                Console.WriteLine("enter the line number where you want to add a station);
                                int.TryParse(Console.ReadLine(), out numLine);
                                AddStation(lineSystem,numLine);
                            }
                            else
                                throw new ArgumentException("invalid choice");
                                break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 0:
                            break;
                        default:
                            throw new ArgumentException("invalid choice");
                    }
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();
                Console.WriteLine("Choose one of the following:");
            } while (choise != 0);


            Console.ReadKey();
        }
    }
}
