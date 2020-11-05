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

 
        static void Main(string[] args)
        {
            List<int> myList = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach(int item in myList)
                Console.WriteLine(item);
            int firstIndex, lastIndex;
            //מוצאים את האינדקס ברשימה לפני הקוד הראשון שניתן
            firstIndex = myList.FindIndex(x => x==2);
            //מוצאים את האינדקס ברשימה לפי הקוד השני שניתן
            lastIndex = myList.FindIndex(x => x==7);
            //אם אחד מקודי התחנה לא נמצאים
            
            //תוסיף לסכום את כל מרחקי הנסיעה של אחת מהתחנות
            for (int i = firstIndex; i <= lastIndex; i++)
                Console.WriteLine(myList[i]);
            Console.ReadKey();
        }
    }
}
