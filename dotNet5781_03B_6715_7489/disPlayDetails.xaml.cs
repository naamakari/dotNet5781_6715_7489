﻿using System;
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
        public static void Bus_StatusChanged1(object sender, EventArgs e)
        {
            if (!(e is StateChangedEventArgs))
                return;
           // MessageBox.Show("אחת אחת", " טיפוללל ");
            //שינוי הצבעים לפי הסטטוס
        }
        public static void Bus_StatusChanged(object sender, EventArgs e)
        {
            if (!(e is StateChangedEventArgs))
                return;
           // MessageBox.Show("אחת שתיים", " הפסקת תדלוק וסיגריה ");
            //שינוי הצבעים לפי הסטטוס
        }
        public Bus myBus2 { get; set; }//definaition of proparthy of bus we selected for the new window we open
        ObservableCollection<Bus> oneOrganList;//defination of list to insert for the listView of the details
       public void intilizied()
        {
           oneOrganList = new ObservableCollection<Bus>();//initialized of the list we definated alreay
            oneOrganList.Add(myBus2);//add the selected item to the list we creat

            Lv.ItemsSource = oneOrganList;//defination the source of the data for the window
            feul.Value = 1200-myBus2.stateOfFuel;//update the progressbar according the state of the fuel
            TimeSpan diffYear = DateTime.Now - myBus2.LastTreatDate;//the difference between today and the last treat day
            if (myBus2.kmSinceLastTreat >= 19900 || diffYear.TotalDays >=335)//check if the bus need treat soon
                warnning.Visibility = Visibility.Visible;
        }

        private void RefuelBotton_Click(object sender, RoutedEventArgs e)//Event of clicking a fuel button
        {
            if (myBus2.StateBus!=state.inTreat&&myBus2.StateBus!=state.inDrive&&myBus2.StateBus!=state.inRefule)
            {
                refuelWorker = new BackgroundWorker();//Production of a new process
                refuelWorker.DoWork += RefuelWorker_DoWork; //Event registration
                refuelWorker.RunWorkerCompleted += RefuelWorker_RunWorkerCompleted;//Event registration
                new StatusChangedObserver(myBus2, 'a');//event registration 
                
                this.Close();
                myBus2.StateBus = state.inRefule;//Updating the status of the bus to 'refueling'   
                refuelWorker.RunWorkerAsync();//start the process with the selected bus
            }
            else if(myBus2.StateBus==state.inTreat)
                MessageBox.Show("האוטובוס לא יכול ללכת לתדלוק כי הוא בטיפול", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            else if(myBus2.StateBus==state.inDrive)
                MessageBox.Show("האוטובוס לא יכול ללכת לתדלוק כי הוא בנסיעה", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                MessageBox.Show("האוטובוס לא יכול ללכת לתדלוק כי הוא כבר בתדלוק", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            //לשלוח את האוטובוס לתדלוק מבחינת זמן
        }

        private void RefuelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
            myBus2.StateBus = state.ready;//use in Bus external for changed in the bus during the process
            string numLine = myBus2.Id;
            MessageBox.Show(" אוטובוס מספר " + numLine + " תודלק בהצלחה", "סיום התדלוק");
            myBus2.stateOfFuel = 0.0;//Update on the fuel state of the bus
        }

        private void RefuelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(12000);//Refueling is done for two hours on a simulation clock
        }

        private void TreatButton_Click(object sender, RoutedEventArgs e)//Event of clicking a treat button
        {
            if (myBus2.StateBus != state.inTreat && myBus2.StateBus != state.inDrive && myBus2.StateBus != state.inRefule)
            {
                treatWorker = new BackgroundWorker();//creat a new proccess
                treatWorker.DoWork += TreatWorker_DoWork;//Event registration
                treatWorker.RunWorkerCompleted += TreatWorker_RunWorkerCompleted;//Event registration
                new StatusChangedObserver(myBus2, true);//event registration 

                this.Close();
                myBus2.StateBus = state.inTreat;//Updating the status of the bus to 'inTreat'

                if (myBus2.stateOfFuel >= 1150)//checks if the bus need also refueling
                {//the time of the refuling include at the treat time
                    myBus2.stateOfFuel = 0.0;//Update on the fuel state of the bus
                }
                treatWorker.RunWorkerAsync();
            }
            else if (myBus2.StateBus == state.inTreat)
                MessageBox.Show("האוטובוס לא יכול ללכת לטיפול כי הוא כבר בטיפול", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (myBus2.StateBus == state.inDrive)
                MessageBox.Show("האוטובוס לא יכול ללכת לטיפול כי הוא בנסיעה", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                MessageBox.Show("האוטובוס לא יכול ללכת לטיפול כי הוא בתדלוק", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);

            //לשלוח את האוטובוס לטיפול מבחינת זמן
        }
        private void TreatWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(144000);//Refueling is done for two hours on a simulation clock
        }

        private void TreatWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            myBus2.StateBus = state.ready;//use in Bus external for changed in the bus during the process
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
