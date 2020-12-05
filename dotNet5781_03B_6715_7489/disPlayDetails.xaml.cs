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
using System.Threading;
using System.ComponentModel;

using dotNet5781_01_6715_7489;


namespace dotNet5781_03B_6715_7489
{
    /// <summary>
    /// Interaction logic for disPlayDetails.xaml
    /// </summary>
    public partial class disPlayDetails : Window
    {
        BackgroundWorker refuelWorker;//defination of backgroundworker for processes
        BackgroundWorker treatWorker;//defination of backgroundworker for processes
        public disPlayDetails()
        {
            InitializeComponent();

        }
        public Bus myBus2 { get; set; }//definaition of proparthy of bus we selected for the new window we open
        ObservableCollection<Bus> oneOrganList;//defination of list to insert for the listView of the details
       public void intilizied()
        {
           oneOrganList = new ObservableCollection<Bus>();//initialized of the list we definated alreay
            // oneOrganList.Add(new Bus(myBus2.Id, myBus2.StartDate, myBus2.LastTreatDate, myBus2.Kilometrazh, myBus2.stateBus, myBus2.stateOfFuel, myBus2.kmSinceLastTreat));
            oneOrganList.Add(myBus2);//add the selected item to the list we creat

            Lv.ItemsSource = oneOrganList;//defination the source of the data for the window
            feul.Value = 1200-myBus2.stateOfFuel;//update the progressbar according the state of the fuel
            TimeSpan diffYear = DateTime.Now - myBus2.LastTreatDate;//the difference between today and the last treat day
            if (myBus2.kmSinceLastTreat >= 19900 || diffYear.TotalDays >=335)//check if the bus need treat soon
                warnning.Visibility = Visibility.Visible;
        }

        private void RefuelBotton_Click(object sender, RoutedEventArgs e)//Event of clicking a fuel button
        {
            refuelWorker = new BackgroundWorker();//Production of a new process
            refuelWorker.DoWork += RefuelWorker_DoWork; //Event registration
            refuelWorker.RunWorkerCompleted += RefuelWorker_RunWorkerCompleted;//Event registration
            var fxElt = sender as FrameworkElement;//casting for bus
            Bus selectedBus = fxElt.DataContext as Bus;
            
            this.Close();
            myBus2.stateBus = state.inRefule;//Updating the status of the bus to 'refueling'
            myBus2.stateOfFuel = 0.0;//Update on the fuel state of the bus
            feul.Value = 1200;//Update the progress bar to be full
            selectedBus = myBus2;
            refuelWorker.RunWorkerAsync(selectedBus);//start the process with the selected bus

            //לשלוח את האוטובוס לתדלוק מבחינת זמן
        }

        private void RefuelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            myBus2 = (Bus)e.Result;//casting for bus 
            myBus2.stateBus = state.ready;//use in Bus external for changed in the bus during the process
            string numLine = myBus2.Id;
            MessageBox.Show(" אוטובוס מספר " + numLine + " תודלק בהצלחה", "סיום התדלוק");
        }

        private void RefuelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = (Bus)e.Argument;//Sending to a function that takes place at the end of the process
            Thread.Sleep(12000);//Refueling is done for two hours on a simulation clock
        }

        private void TreatButton_Click(object sender, RoutedEventArgs e)//Event of clicking a treat button
        {
            treatWorker = new BackgroundWorker();//creat a new proccess
            treatWorker.DoWork += TreatWorker_DoWork;//Event registration
            treatWorker.RunWorkerCompleted += TreatWorker_RunWorkerCompleted;//Event registration

            var fxElt = sender as FrameworkElement;//casting for bus 
            Bus selectedBus = fxElt.DataContext as Bus;
            this.Close();
           // selectedBus.kmSinceLastTreat = 0.0;//Update the km of the bus
           // myBus2.LastTreatDate = DateTime.Now;//Update the date of the km of the bus since treat
           // oneOrganList[0].LastTreatDate = DateTime.Now;
            selectedBus.stateBus = state.inTreat;//Updating the status of the bus to 'inTreat'
           
            if (selectedBus.stateOfFuel >= 1150)//checks if the bus need also refueling
            {//the time of the refuling include at the treat time
                selectedBus.stateOfFuel = 0.0;//Update on the fuel state of the bus
                oneOrganList[0].stateOfFuel = 0.0;//Update on the fuel state of the bus
                myBus2.stateOfFuel = 0.0;//Update on the fuel state of the bus
                feul.Value = 1200;//update the progressbar to be full
            }
            treatWorker.RunWorkerAsync(selectedBus);
            //לשלוח את האוטובוס לטיפול מבחינת זמן
        }
        private void TreatWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = (Bus)e.Argument;//Sending to a function that takes place at the end of the process
            Thread.Sleep(144000);//Refueling is done for two hours on a simulation clock
        }

        private void TreatWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            myBus2 = (Bus)e.Result;//casting for bus 
            myBus2.stateBus = state.ready;//use in Bus external for changed in the bus during the process
            string numLine = myBus2.Id;
            MessageBox.Show(" אוטובוס מספר " + numLine + " טופל בהצלחה", "סיום הטיפול");
            myBus2.kmSinceLastTreat = 0.0;//Update the km of the bus
            myBus2.LastTreatDate = DateTime.Now;//Update the date of the km of the bus since treat
        }

      

        private void feul_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //feul.Value = myBus2.stateOfFuel;
        }
    }
}
