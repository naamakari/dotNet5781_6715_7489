using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_00_6715_7489
{
    partial class Program
    {
        static void Main(string[] args)
        {
            welcome6715();
            welcome7489();
            Console.ReadKey();

        }
        static partial void welcome7489();
        private static void welcome6715()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", name);
        }
    }
}
