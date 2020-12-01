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
using dotNet5781_01_6715_7489;

namespace dotNet5781_03B_6715_7489
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BusListView.ItemsSource = busStatic.buses;
            //cbListBuses.DisplayMemberPath = "Id";
           // BusListView.SelectedIndex = 0;


            //List<string> str = new List<string>();
            //str.Add("Bus1");
            //str.Add("Bus2");
            //str.Add("Bus3");
            //cbListBuses.ItemsSource = str;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddBus newAddWin = new AddBus();
            newAddWin.ShowDialog();
        }

        private void detailButton_Click(object sender, RoutedEventArgs e)
        {
            var fxElt = sender as FrameworkElement;
            Bus selectedBus = fxElt.DataContext as Bus;
            toDrive newWin = new toDrive();
            newWin.myBus = selectedBus;
            newWin.ShowDialog();
        }

        private void refuelButton_Click(object sender, RoutedEventArgs e)
        {
            var fxElt = sender as FrameworkElement;
            Bus selectedBus = fxElt.DataContext as Bus;
            selectedBus.stateOfFuel = 0.0;
            selectedBus.stateBus = state.inRefule;
            //לשלוח את האוטובוס לתדלוק מבחינת זמן
        }

        private void BusListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            disPlayDetails displayDetails = new disPlayDetails();
            displayDetails.myBus2 = (Bus)BusListView.SelectedItem;
            displayDetails.intilizied();
            displayDetails.ShowDialog();
        }

        private void DrivingBotton_GotMouseCapture(object sender, MouseEventArgs e)
        {
            MessageBox.Show("jhjbj", "hv");
        
                }
    }

}
