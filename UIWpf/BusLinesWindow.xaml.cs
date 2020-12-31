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
    /// Interaction logic for BusLinesWindow.xaml
    /// </summary>
    public partial class BusLinesWindow : Window
    {
        ObservableCollection<BusLineBL> busLineBLs = new ObservableCollection<BusLineBL>();
        ObservableCollection<BusStation> busStations = new ObservableCollection<BusStation>();
        IBL bl;
        public BusLinesWindow(IBL _Bl)
        {
            InitializeComponent();
            bl = _Bl;
            foreach (BusLineBL item in bl.GetAllLines())
                busLineBLs.Add(item);
            busLineBLListView.ItemsSource = busLineBLs;
        }

        private void addBusLine_Click(object sender, RoutedEventArgs e)
        {
            AddBusLine.IsEnabled = false;
            DetailsGrid.Visibility = Visibility.Hidden;
            AddBusLineGrid.Visibility = Visibility.Visible;
            areaAtLandComboBox.ItemsSource = Enum.GetValues(typeof(Area));
            AllStationListView.DataContext = bl.GetAllStations();
        }

        private void UpdateBusLine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBusLine_Click(object sender, RoutedEventArgs e)
        {
            BusLineBL busLineBL = busLineBLListView.SelectedItem as BusLineBL;
            busLineBLs.Remove(busLineBL);
            DetailsGrid.DataContext = null;
        }

        private void busLineBLListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeleteBusLine.IsEnabled = true;
            UpdateBusLine.IsEnabled = true;
            DetailsGrid.DataContext = busLineBLListView.SelectedItem as BusLineBL;
            AllStationListView.ItemsSource = bl.GetAllStations();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void busNumLineTextBox_KeyDown(object sender, KeyEventArgs e)
        {
           bool nonNumeriable = false;

            //if the key is not a number from the up keyboard
            if (e.Key < Key.D0 || e.Key > Key.D9)
                //if the key is not a number from the side keyboard
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                    nonNumeriable = true;

            if (nonNumeriable == true)
            {
                e.Handled = true;

            }
        }

        private void AllStationListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BusStation busStation = AllStationListView.SelectedItem as BusStation;
          if(!busStations.Any(x => x.StationCode == busStation.StationCode))
            busStations.Add(busStation);
            collectionOfStationListViewAdd.DataContext = busStations;
        }
    }
}
