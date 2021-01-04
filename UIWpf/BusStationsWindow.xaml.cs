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
        private bool nonNumeriable = false;
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
            BusStationBL busStation = busStationBLDataGrid.SelectedItem as BusStationBL;
            stations.Remove(busStation);
            busStationDetailes.DataContext = null;
            collectionBusLinesListView.ItemsSource = null;
        }

        private void addBusStation_Click(object sender, RoutedEventArgs e)
        {
            busStationDetailes.Visibility = Visibility.Hidden;
            addBusStationGrid.Visibility = Visibility.Visible;
            addStation.IsEnabled = false;
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
            
            DeleteStation.IsEnabled = true;
            UpdateStation.IsEnabled = true;
            BusStationBL busStation = busStationBLDataGrid.SelectedItem as BusStationBL;
            busStationDetailes.DataContext = busStation;
            if (busStation != null)
                collectionBusLinesListView.ItemsSource = busStation.CollectionBusLines;
            
        }

        private void latitudeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumeriable = false;

            //if the key is not a number from the up keyboard
            if (e.Key < Key.D0 || e.Key > Key.D9)
                //if the key is not a number from the side keyboard
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                    if (e.Key != Key.Decimal)
                        nonNumeriable = true;

            if (nonNumeriable == true)
            {
                e.Handled = true;

            }
        }

        private void stationNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            enable();
        }

        private void addressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            enable();
        }

        private void latitudeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            enable();
        }

        private void longitudeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            enable();
        }
        private void enable()
        {
            if (stationNameTextBox.Text != "" && addressTextBox.Text != "" && latitudeTextBox.Text != "" &&
                longitudeTextBox.Text != "")
                toAdd.IsEnabled = true;
        }

        private void toAdd_Click(object sender, RoutedEventArgs e)
        {
            BusStationBL busStation = new BusStationBL()
            {
                StationName = stationNameTextBox.Text,
                Address = addressTextBox.Text,
                Latitude = float.Parse(latitudeTextBox.Text),
                Longitude = float.Parse(longitudeTextBox.Text),
            };
            busStation.Location= busStation.Latitude + "°N " + busStation.Longitude + "°E";
            try 
            {
                bl.AddBusStation(busStation);
                foreach (BusStationBL item in bl.GetAllStations())
                    stations.Add(item);
                busStationDetailes.DataContext = null;
                busStationDetailes.Visibility = Visibility.Visible;
                addBusStationGrid.Visibility = Visibility.Hidden;
                MessageBox.Show("התחנה נוספה בהצלחה", "", MessageBoxButton.OK, MessageBoxImage.Information);
                addStation.IsEnabled = true;

            }
               
            catch (BO.DalAlreayExistExeption ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
            
            }
    }
}
