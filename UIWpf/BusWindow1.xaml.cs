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
using BL;
using BO;
using APIBL;
using System.Collections.ObjectModel;

namespace UIWpf
{
    /// <summary>
    /// Interaction logic for BusWindow1.xaml
    /// </summary>
    public partial class BusWindow1 : Window
    {
        ObservableCollection<Bus> buses=new ObservableCollection<Bus>();
        IBL bl;
        public BusWindow1(IBL _Bl)
        {
            InitializeComponent();
            bl = _Bl;
            busStateComboBox.ItemsSource = Enum.GetValues(typeof(BusStatus));
            try
            {
                foreach (var item in bl.GetAllBuses())
                    buses.Add(item);
                busListView.ItemsSource = buses;
            }
            catch(BO.DalEmptyCollectionExeption ex)
            {
                MessageBox.Show(ex.Message,"הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        private void busListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var fxElt = sender as FrameworkElement;//casting for bus
            //BusDeatailsGrid.DataContext = fxElt.DataContext as Bus;
            BusDeatailsGrid.DataContext = busListView.SelectedItem as Bus;
        }

        private void refule_Click(object sender, RoutedEventArgs e)
        {
            Bus bus= busListView.SelectedItem as Bus;
            bl.SendToRefuel(bus);
            BusDeatailsGrid.DataContext = bl.GetBus(bus.LicenseNumber);
        }

        private void treat_Click(object sender, RoutedEventArgs e)
        {
            Bus bus = busListView.SelectedItem as Bus;
            bl.SendToTreat(bus);
            BusDeatailsGrid.DataContext = bl.GetBus(bus.LicenseNumber);
           
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Bus bus = busListView.SelectedItem as Bus;
            buses.Remove(bus);
            //bl.DeleteBus(bus.LicenseNumber);
            BusDeatailsGrid.DataContext = null;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            BusDeatailsGrid.Visibility = Visibility.Hidden;
            addGrid.Visibility = Visibility.Visible;

        }
    }
}
