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
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using dotNet5781_01_6715_7489;

namespace dotNet5781_03B_6715_7489
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        BackgroundWorker refuelWorker;


        public MainWindow()
        {
            InitializeComponent();

            BusListView.ItemsSource = busStatic.buses;
          
        }

        Bus currentBus { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddBus newAddWin = new AddBus();
            newAddWin.ShowDialog();
        }

        private void detailButton_Click(object sender, RoutedEventArgs e)//event of sending bus to driving
        {

            var fxElt = sender as FrameworkElement;
            Bus selectedBus = fxElt.DataContext as Bus;
            toDrive newWin = new toDrive();
            newWin.myBus = selectedBus;
            newWin.ShowDialog();
        }

        private void refuelButton_Click(object sender, RoutedEventArgs e)//event of sending bus to refuel
        {
            refuelWorker = new BackgroundWorker();
            refuelWorker.DoWork += RefuelWorker_DoWork;
            refuelWorker.RunWorkerCompleted += RefuelWorker_RunWorkerCompleted;
            var fxElt = sender as FrameworkElement;
            Bus selectedBus = fxElt.DataContext as Bus;
            currentBus = selectedBus;
            refuelWorker.RunWorkerAsync(selectedBus);
            selectedBus.stateOfFuel = 0.0;
            selectedBus.stateBus = state.inRefule;
            //לשלוח את האוטובוס לתדלוק מבחינת זמן
        }

        private void RefuelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          currentBus = (Bus)e.Result;
            currentBus.stateBus = state.ready;
            string numLine = currentBus.Id;
            MessageBox.Show(" אוטובוס מספר " + numLine + " תודלק בהצלחה", "סיום התדלוק");

        }

        private void RefuelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //currentBus =
           e.Result = (Bus)e.Argument; 
            Thread.Sleep(12000);
        }

        private void BusListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)//double click to display the details of the bus
        {
           
            var fxElt = sender as FrameworkElement;
            Bus selectedBus = fxElt.DataContext as Bus;
            disPlayDetails displayDetails = new disPlayDetails();
            displayDetails.myBus2 = (Bus)BusListView.SelectedItem;
            displayDetails.intilizied();
            displayDetails.ShowDialog();

          //if ( displayDetails.myBus2.stateBus==state.inRefule|| displayDetails.myBus2.stateBus == state.inTreat)
    
          //      IsEnabled= e.ButtonState
          //      fxElt.IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
