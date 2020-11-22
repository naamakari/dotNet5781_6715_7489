using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using dotNet5781_02_6715_7489;

namespace dotNet5781_03A_6715_7489
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        static public Random rand = new Random(DateTime.Now.Millisecond);

        CollectionOfLines collection_Lines;
        public MainWindow()
        {
            InitializeComponent();
            List<LineBusStation> allStation = new List<LineBusStation>();
            collection_Lines = new CollectionOfLines();
            string address = "a";
            for (int i = 0; i < 40; i++, address += "h")
                allStation.Add(new LineBusStation(address));
            for (int i = 0; i < 10; i++)
                collection_Lines[i] = new LineOfBus(allStation[rand.Next(0, 40)], allStation[rand.Next(0, 40)], (Area)rand.Next(0, 5));
            //foreach (LineOfBus item in allLines)
            //    Console.WriteLine(item);

            for (int i = 0; i < 5; i++)
                collection_Lines[0].AddRemoveStation(allStation[i], 'a', i + 1);
            for (int i = 1; i < 6; i++)
                collection_Lines[1].AddRemoveStation(allStation[i + 3], 'a', i);
            for (int i = 1; i < 6; i++)
                collection_Lines[2].AddRemoveStation(allStation[i + 8], 'a', i);
            for (int i = 1; i < 6; i++)
                collection_Lines[3].AddRemoveStation(allStation[i + 12], 'a', i);
            for (int i = 1; i < 6; i++)
                collection_Lines[4].AddRemoveStation(allStation[i + 17], 'a', i);
            for (int i = 1; i < 6; i++)
                collection_Lines[5].AddRemoveStation(allStation[i + 22], 'a', i);
            for (int i = 1; i < 6; i++)
                collection_Lines[6].AddRemoveStation(allStation[i + 26], 'a', i);
            for (int i = 1; i < 6; i++)
                collection_Lines[7].AddRemoveStation(allStation[i + 30], 'a', i);
            for (int i = 1; i <= 5; i++)
                collection_Lines[8].AddRemoveStation(allStation[i + 34], 'a', i);

            collection_Lines[9].AddRemoveStation(allStation[0], 'a', 1);
            collection_Lines[9].AddRemoveStation(allStation[4], 'a', 2);
            collection_Lines[9].AddRemoveStation(allStation[7], 'a', 3);
            collection_Lines[9].AddRemoveStation(allStation[9], 'a', 4);
            collection_Lines[9].AddRemoveStation(allStation[13], 'a', 5);
            collection_Lines[9].AddRemoveStation(allStation[18], 'a', 6);
            collection_Lines[9].AddRemoveStation(allStation[23], 'a', 7);
            collection_Lines[9].AddRemoveStation(allStation[27], 'a', 8);
            cbBusLines.ItemsSource = collection_Lines;
            cbBusLines.DisplayMemberPath = "NumLine";
            cbBusLines.SelectedIndex = 0;
           //ShowBusLine(index);
        }
        private void ShowBusLine(int ind)
        {
            currentDisplayBusLine = collection_Lines[ind-1];
            UpGrid.DataContext = currentDisplayBusLine;
            lbBusLineStation.DataContext = currentDisplayBusLine.Stations;
            tbArea.Text = currentDisplayBusLine.AreaAtLand.ToString();
        }
        private LineOfBus currentDisplayBusLine;

        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowBusLine((cbBusLines.SelectedValue as LineOfBus).NumLine);
        }

        private void lbBusLineStation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
