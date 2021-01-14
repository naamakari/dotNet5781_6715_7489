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
            busStationDetailes.Visibility = Visibility.Hidden;
            busStationBLDataGrid.IsEnabled = false;
            updateGrid.DataContext = busStationBLDataGrid.SelectedItem as BusStationBL;
            updateGrid.Visibility = Visibility.Visible;
            BusStationBL busStationBL = busStationBLDataGrid.SelectedItem as BusStationBL;
            if (busStationBL != null)
                collectionBusLinesListView1.ItemsSource = busStationBL.CollectionBusLines;

        }

        private void DeleteBusStation_Click(object sender, RoutedEventArgs e)
        {
            BusStationBL busStation = busStationBLDataGrid.SelectedItem as BusStationBL;
            stations.Remove(busStation);
            bl.DeleteBusStation(busStation.StationCode);
            busStationDetailes.DataContext = null;
            collectionBusLinesListView.ItemsSource = null;
        }

        private void addBusStation_Click(object sender, RoutedEventArgs e)
        {
            backToNenu.Visibility = Visibility.Hidden;
            cancle1.Visibility = Visibility.Visible;
            busStationDetailes.Visibility = Visibility.Hidden;
            updateGrid.Visibility = Visibility.Hidden;
            addBusStationGrid.Visibility = Visibility.Visible;
            addStation.IsEnabled = false;
        }

        private void backToNenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void searchStationTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IEnumerable<BusStationBL> busStationCollection = stations.Where(x => x.StationCode.ToString().Contains(searchStationTextBox.Text) || x.StationName.Contains(searchStationTextBox.Text)
           || x.Address.Contains(searchStationTextBox.Text));//|| x.AreaAtLand.ToString().Contains(searchStationTextBox.Text));
            busStationBLDataGrid.ItemsSource = busStationCollection;
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
            //Check whether the location is within the country
            if (latitudeTextBox.Text != "")
            {
                if (float.Parse(latitudeTextBox.Text) < 34.2 || float.Parse(latitudeTextBox.Text) > 35.5)
                    latInvalid.Visibility = Visibility.Visible;
                else
                    latInvalid.Visibility = Visibility.Hidden;
            }
            enable();
        }

        private void longitudeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Check whether the location is within the country
            if (longitudeTextBox.Text != "")
            {
                if (float.Parse(longitudeTextBox.Text) < 29.4 || float.Parse(longitudeTextBox.Text) > 33.3)
                    longInvalid.Visibility = Visibility.Visible;
                else
                    longInvalid.Visibility = Visibility.Hidden;
            }
            enable();
        }
        private void enable()
        {
            if (stationNameTextBox.Text != "" && addressTextBox.Text != "" && latitudeTextBox.Text != "" &&
                longitudeTextBox.Text != "")
                if(longInvalid.Visibility==Visibility.Hidden&&latInvalid.Visibility==Visibility.Hidden)
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
                collectionBusLinesListView.ItemsSource = null;
                backToNenu.Visibility = Visibility.Visible;
                cancle1.Visibility = Visibility.Hidden;
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

        private void toCancle_Click(object sender, RoutedEventArgs e)
        {
            updateGrid.DataContext = null;
            updateGrid.Visibility = Visibility.Hidden;
            busStationDetailes.Visibility = Visibility.Visible;
            busStationBLDataGrid.IsEnabled = true;
        }

        private void toUpdate_Click(object sender, RoutedEventArgs e)
        {

            BusStation busStation = updateGrid.DataContext as BusStation;
            BusStationBL busStationBL;
            try
               {
                bl.UpdateBusStation(busStation);
                updateGrid.DataContext = null;
                collectionBusLinesListView1.DataContext = null;
                updateGrid.Visibility = Visibility.Hidden;
                busStationBL = bl.GetBusStationBL(busStation.StationCode);
                busStationDetailes.DataContext= busStationBL;
                if (busStationBL != null)
                    collectionBusLinesListView.ItemsSource = busStationBL.CollectionBusLines;
                busStationDetailes.Visibility = Visibility.Visible;
                busStationBLDataGrid.IsEnabled = true;
                stations.Add(busStationBL);
                MessageBox.Show("התחנה עודכנה בהצלחה", "", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch(KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void deleteFromNewListButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fxElt = sender as FrameworkElement;//casting for bus station
                BusLine busLine = fxElt.DataContext as BusLine;
                BusStationBL busStation = busStationBLDataGrid.SelectedItem as BusStationBL;
                stations.Remove(busStation);
                StationInLine stationInLine = bl.getStationInLine(busLine.BusId, busStation.StationCode);
                bl.DeleteStationInLine(stationInLine);
                BusStationBL busStationBL = bl.GetBusStationBL(busStation.StationCode);
                if (busStationBL != null)
                    collectionBusLinesListView1.ItemsSource = busStationBL.CollectionBusLines;

            }
            catch(KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void longitudeTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Check whether the location is within the country
            toUpdate.IsEnabled = false;
            if (longitudeTextBox1.Text != "")
            {
                if (float.Parse(longitudeTextBox1.Text) < 29.4 || float.Parse(longitudeTextBox1.Text) > 33.3)
                    longInvalid1.Visibility = Visibility.Visible;
                else
                {
                    longInvalid1.Visibility = Visibility.Hidden;
                    toUpdate.IsEnabled = true;
                }
            }
        }

        private void latitudeTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Check whether the location is within the country
            toUpdate.IsEnabled = false;
            if (latitudeTextBox1.Text != "")
            {
                if (float.Parse(latitudeTextBox1.Text) < 34.2 || float.Parse(latitudeTextBox1.Text) > 35.5)
                    latInvalid1.Visibility = Visibility.Visible;
                else
                {
                    latInvalid1.Visibility = Visibility.Hidden;
                    toUpdate.IsEnabled = true;
                }
            }
        }

        private void cancle1_Click(object sender, RoutedEventArgs e)
        {
            busStationDetailes.DataContext = null;
            collectionBusLinesListView.ItemsSource = null;
            backToNenu.Visibility = Visibility.Visible;
            cancle1.Visibility = Visibility.Hidden;
            busStationDetailes.Visibility = Visibility.Visible;
            addBusStationGrid.Visibility = Visibility.Hidden;
            addStation.IsEnabled = true;
        }
    }
}
