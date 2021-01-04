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
        static int indexOfStation = 0;
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
            RealyAddBusLine.IsEnabled = false;
            addBusLine.IsEnabled = false;
            cancledAddBus.Visibility = Visibility.Visible;
            backToNenu.Visibility = Visibility.Hidden;
            DetailsGrid.Visibility = Visibility.Hidden;
            AddBusLineGrid.Visibility = Visibility.Visible;
            areaAtLandComboBox.ItemsSource = Enum.GetValues(typeof(Area));
            AllStationListView.DataContext = bl.GetAllStations();
        }

        private void UpdateBusLine_Click(object sender, RoutedEventArgs e)
        {
            DetailsGrid.Visibility = Visibility.Hidden;
            UpdateGrid.Visibility = Visibility.Visible;
            RealyUpdateBusLine.IsEnabled = false;
            UpdateGrid.DataContext = busLineBLListView.SelectedItem as BusLineBL;
            areaAtLandTextBoxUpdate.ItemsSource = Enum.GetValues(typeof(Area));
            BusLineBL busLineBL = busLineBLListView.SelectedItem as BusLineBL;
            if (busLineBL != null)
                collectionOfStationListViewUpdate.ItemsSource = bl.GetBusLineBL(busLineBL.BusId).CollectionOfStation;
        }

        private void DeleteBusLine_Click(object sender, RoutedEventArgs e)
        {
            BusLineBL busLineBL = busLineBLListView.SelectedItem as BusLineBL;
            busLineBLs.Remove(busLineBL);
            DetailsGrid.DataContext = null;
            collectionOfStationListView.ItemsSource = null;
        }

        private void busLineBLListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeleteBusLine.IsEnabled = true;
            UpdateBusLine.IsEnabled = true;
            DetailsGrid.DataContext = busLineBLListView.SelectedItem as BusLineBL;
            BusLineBL busLineBL = busLineBLListView.SelectedItem as BusLineBL;
            if (busLineBL != null)
                collectionOfStationListView.ItemsSource = bl.GetBusLineBL(busLineBL.BusId).CollectionOfStation;
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
            if (!busStations.Any(x => x.StationCode == busStation.StationCode))
            {
                busStations.Add(busStation);
                indexOfStation++;
            }
            collectionOfStationListViewAdd.DataContext = busStations;
            //חיבור של המספר של התחנה

        }


        private void deleteFromNewListButton_Click(object sender, RoutedEventArgs e)
        {

            var busLine = sender as FrameworkElement;//casting for bus
            BusStation busStation = busLine.DataContext as BusStation;
            busStations.Remove(busStation);
        }

        private void RealyAddBusLine_Click(object sender, RoutedEventArgs e)
        {

            // רשימה של ליסט וויו לאייאינאמראייבל 
            IEnumerable<BusStation> busStationsTemp = bl.GetAllStations();
            busStationsTemp.ToList().Clear();
            busStations.Clone(busStationsTemp);
            BusLineBL busLineBL = new BusLineBL
            {
                BusNumLine = int.Parse(busNumLineTextBox.Text),
                AreaAtLand = (BO.Area)areaAtLandComboBox.SelectedItem,
                CollectionOfStation = busStationsTemp,
                NumberFirstStation = busStations[0].StationCode,
                NumberLastStation = busStations[busStations.Count() - 1].StationCode,
                FirstStation = busStations[0],
                LastStation = busStations[busStations.Count() - 1]
            };
            bl.AddBusLine(busLineBL);


            //  busLineBLs.Add(busLineBL);


        }

        private void areaAtLandComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (busNumLineTextBox.Text != null && areaAtLandComboBox.SelectedItem != null && busStations.Count >= 2)
                RealyAddBusLine.IsEnabled = true;
        }

        private void busNumLineTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (busNumLineTextBox.Text != null && areaAtLandComboBox.SelectedItem != null && busStations.Count >= 2)
                RealyAddBusLine.IsEnabled = true;
        }

        private void collectionOfStationListViewAdd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (busNumLineTextBox.Text != null && areaAtLandComboBox.SelectedItem != null && busStations.Count >= 2)
                RealyAddBusLine.IsEnabled = true;
        }

        private void cancleAddBus_Click(object sender, RoutedEventArgs e)
        {
            addBusLine.IsEnabled = true;
            cancledAddBus.Visibility = Visibility.Hidden;
            backToNenu.Visibility = Visibility.Visible;
            DetailsGrid.Visibility = Visibility.Visible;
            AddBusLineGrid.Visibility = Visibility.Hidden;
            areaAtLandComboBox.Text = null;
            busNumLineTextBox.Text = null;
            busStations.Clear();
            collectionOfStationListViewAdd.DataContext = busStations;
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IEnumerable<BusLineBL> busLinesCollection = busLineBLs.Where(x => x.FirstStation.StationName.Contains(searchStationTextBox.Text)||x.LastStation.StationName.Contains(searchStationTextBox.Text)
            || x.BusNumLine.ToString().Contains(searchStationTextBox.Text)||x.AreaAtLand.ToString().Contains(searchStationTextBox.Text));
            busLineBLListView.ItemsSource = busLinesCollection;
        }
    }
}
