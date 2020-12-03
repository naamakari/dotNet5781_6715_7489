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

            BusListView.ItemsSource = busStatic.buses;//Link the list of buses to the list displayed in the window

        }

        Bus currentBus { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //To add a bus, a window will open for inserting the bus
            AddBus newAddWin = new AddBus();
            newAddWin.ShowDialog();
        }

        private void detailButton_Click(object sender, RoutedEventArgs e)//event of sending bus to driving
        {
            //drive button

            var fxElt = sender as FrameworkElement;//casting for bus
            Bus selectedBus = fxElt.DataContext as Bus;
            //In order to exit the trip, a new window will open in which it is necessary to enter the distance traveled
            toDrive newWin = new toDrive();
            newWin.myBus = selectedBus;//Sending the selected bus to the next window
            newWin.ShowDialog();
        }

        private void refuelButton_Click(object sender, RoutedEventArgs e)//event of sending bus to refuel
        {
            refuelWorker = new BackgroundWorker();
            refuelWorker.DoWork += RefuelWorker_DoWork;
            refuelWorker.RunWorkerCompleted += RefuelWorker_RunWorkerCompleted;//Event registration
            
            var fxElt = sender as FrameworkElement;//casting for bus
            Bus selectedBus = fxElt.DataContext as Bus;
            
            //currentBus = selectedBus;
            refuelWorker.RunWorkerAsync(selectedBus);//start the process
            selectedBus.stateOfFuel = 0.0;//update the state of the fule
            selectedBus.stateBus = state.inRefule;//update the statos 
            
        }

        private void RefuelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            currentBus = (Bus)e.Result;//castong for bus 
            currentBus.stateBus = state.ready;//use in Bus external for changed in the bus during the process 
            string numLine = currentBus.Id;
            MessageBox.Show(" אוטובוס מספר " + numLine + " תודלק בהצלחה", "סיום התדלוק");

        }

        private void RefuelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
           e.Result = (Bus)e.Argument; //Sending to a function that takes place at the end of the process
            Thread.Sleep(12000);//Refueling is done for two hours on a simulation clock
        }

        private void BusListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)//double click to display the details of the bus
        {
            //Double-click displays the details of the bus
            var fxElt = sender as FrameworkElement;
            Bus selectedBus = fxElt.DataContext as Bus;
            //Send to the new window of details
            disPlayDetails displayDetails = new disPlayDetails();
            displayDetails.myBus2 = (Bus)BusListView.SelectedItem;//Sending the selected auto to the new window
            displayDetails.intilizied();//Initialize the details in the new window
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
