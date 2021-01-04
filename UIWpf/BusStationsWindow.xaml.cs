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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using BL;
using BO;
using APIBL;
namespace UIWpf
{
    /// <summary>
    /// Interaction logic for BusStationsWindow.xaml
    /// </summary>
    public partial class BusStationsWindow : Window
    {
        IBL bl;
        ObservableCollection<BusStationBL> stations=new ObservableCollection<BusStationBL>();
        ObservableCollection<BusLine> busLines=new ObservableCollection<BusLine>();
        public BusStationsWindow(IBL _Bl)
        {
            InitializeComponent();
            bl = _Bl;
            foreach (BusStationBL item in bl.GetAllStations())
                stations.Add(item);
            busStationBLDataGrid.ItemsSource = stations;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UpdateBusLine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBusLine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addBusLine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void backToNenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void searchStationTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void busStationBLDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
