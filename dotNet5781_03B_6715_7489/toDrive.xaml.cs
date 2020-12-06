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
using System.Threading;
using System.ComponentModel;
using dotNet5781_01_6715_7489;

namespace dotNet5781_03B_6715_7489
{
    /// <summary>
    /// Interaction logic for toDrive.xaml
    /// </summary>
    public partial class toDrive : Window
    {

        public toDrive()
        {
            InitializeComponent();
        }
        BackgroundWorker DriveWorker;
        BackgroundWorker treatWorker;
        BackgroundWorker refuelWorker;
        public Bus myBus { get; set; }//definaition of proparthy of bus we selected for the new window we opened
        private bool nonNumeriable = false;
        static public Random rand = new Random(DateTime.Now.Millisecond);
        private void dis_KeyDown(object sender, KeyEventArgs e)//An event of inserting keys from the keyboard
        {
            nonNumeriable = false;
            //if the key is not a number from the up keyboard
            if (e.Key < Key.D0 || e.Key > Key.D9)
                //if the key is not a number from the side keyboard
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                    if (e.Key != Key.Decimal)//if the number is not point
                        nonNumeriable = true;

            if (nonNumeriable == true)//if the key is not a number or point
                e.Handled = true;//block the option to insert keys
            if (e.Key == Key.Enter)//if the key is 'enter'
            {
                this.Close();
                TimeSpan diff = DateTime.Now - myBus.LastTreatDate;//the difference between the last treat day and today
                if (myBus.stateOfFuel + float.Parse(dis.Text) <= 1200)//can take the driving from the fuel aspect
                {
                    if (diff.TotalDays < 365 && myBus.kmSinceLastTreat + float.Parse(dis.Text) <= 20000)//can take the driving from the treat aspect
                    {
                        this.driving();
                    }

                    else//the bus need treat and can not take the driving
                    {
                        //message box
                        MessageBox.Show("!!האוטובוס צריך טיפול", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                        myBus.stateBus = state.inTreat;//change the status of the bus
                        this.treat();//sending to treat

                    }
                }
                else//the bus need refuel and can not take the driving
                {
                    //message box
                    MessageBox.Show("!!האוטובוס צריך תדלוק", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                    myBus.stateBus = state.inRefule;// change the status of the bus
                    this.refuel();//sending to refuel


                }
            }
        }
        private void cancle_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void dis_MouseDown(object sender, MouseButtonEventArgs e)//double click on the text box
        {
            dis.Text = "";
        }

        //private void dis_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    dis.Text = "";

        //}

        private void driving()
        {
            DriveWorker = new BackgroundWorker();
            DriveWorker.DoWork += DriveWorker_DoWork;
            DriveWorker.RunWorkerCompleted += DriveWorker_RunWorkerCompleted;//Event registration
            float kmForH = rand.Next(20, 50);
            int time = (int)(float.Parse(dis.Text) / kmForH);
            DriveWorker.RunWorkerAsync(time);//start the process
            myBus.stateBus = state.inDrive;//change the status of the bus

        }

        private void DriveWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            Thread.Sleep((int)(e.Argument)*6000);//drive is done accord the km and the bus speed 
        }

        private void DriveWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            myBus.stateBus = state.ready;//use in Bus external for changed in the bus during the process 
            string numLine = myBus.Id;
            MessageBox.Show(" אוטובוס מספר " + numLine + " חזר מנסיעה", "סיום הנסיעה");
            myBus.upDateDetails(double.Parse(dis.Text));//update the details of the bus according the km

        }
        private void treat()
        {
            treatWorker = new BackgroundWorker();//creat a new proccess
            treatWorker.DoWork += TreatWorker_DoWork;//Event registration
            treatWorker.RunWorkerCompleted += TreatWorker_RunWorkerCompleted; ;//Event registration

            myBus.stateBus = state.inTreat;//Updating the status of the bus to 'inTreat'

            if (myBus.stateOfFuel >= 1150)//checks if the bus need also refueling
            {//the time of the refuling include at the treat time
                myBus.stateOfFuel = 0.0;//Update on the fuel state of the bus
            }
            treatWorker.RunWorkerAsync();
        }
        private void TreatWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(144000);//Refueling is done for two hours on a simulation clock
        }

        private void TreatWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            myBus.stateBus = state.ready;//use in Bus external for changed in the bus during the process
            string numLine = myBus.Id;
            MessageBox.Show(" אוטובוס מספר " + numLine + " טופל בהצלחה", "סיום הטיפול");
            myBus.kmSinceLastTreat = 0.0;//Update the km of the bus
            myBus.LastTreatDate = DateTime.Now;//Update the date of the km of the bus since treat
        }
private void refuel()
        {
            refuelWorker = new BackgroundWorker();//Production of a new process
            refuelWorker.DoWork += RefuelWorker_DoWork; //Event registration
            refuelWorker.RunWorkerCompleted += RefuelWorker_RunWorkerCompleted; ;//Event registration
           
            myBus.stateBus = state.inRefule;//Updating the status of the bus to 'refueling'
           
            refuelWorker.RunWorkerAsync();//start the process with the selected bus
        }
        private void RefuelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(12000);//Refueling is done for two hours on a simulation clock
        }

        private void RefuelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            myBus.stateBus = state.ready;//use in Bus external for changed in the bus during the process
            string numLine = myBus.Id;
            MessageBox.Show(" אוטובוס מספר " + numLine + " תודלק בהצלחה", "סיום התדלוק");
            myBus.stateOfFuel = 0.0;//Update on the fuel state of the bus
        }

       
    }
}
