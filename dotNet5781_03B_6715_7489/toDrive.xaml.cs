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
                        //שולח לטיפול
                        //לעדכן את הזמן, להוציא הודעה מתאימה ולעדכן את הסטטוס

                    }
                }
                else//the bus need refuel and can not take the driving
                {
                    //message box
                    MessageBox.Show("!!האוטובוס צריך תדלוק", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                    myBus.stateBus = state.inRefule;// change the status of the bus
                    //שולח לתדלוק
                    //לעדכן את הזמן, להוציא הודעה מתאימה ולעדכן את הסטטוס


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

        private void dis_MouseEnter(object sender, MouseEventArgs e)
        {
            dis.Text = "";

        }

        private void driving()
        {
            DriveWorker = new BackgroundWorker();
            DriveWorker.DoWork += DriveWorker_DoWork;
            DriveWorker.RunWorkerCompleted += DriveWorker_RunWorkerCompleted;//Event registration

            DriveWorker.RunWorkerAsync(myBus);//start the process
            myBus.upDateDetails(double.Parse(dis.Text));//update the details of the bus according the km
            myBus.stateBus = state.inDrive;//change the status of the bus


                                           //שולח לנסיעה
                                           //לעדכן את הזמן, להוציא הודעה מתאימה ולעדכן את הסטטוס
        }

        private void DriveWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            float kmForH= rand.Next(20, 50);
            int time =(int)(float.Parse(dis.Text)/kmForH);
            Thread.Sleep(time*60000);//drive is done accord the km and the bus speed 
            //לא משתהה מספיק לא יודעת למה
        }

        private void DriveWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //currentBus = (Bus)e.Result;//castong for bus 
            myBus.stateBus = state.ready;//use in Bus external for changed in the bus during the process 
            string numLine = myBus.Id;
            MessageBox.Show(" אוטובוס מספר " + numLine + " חזר מנסיעה", "סיום הנסיעה");
        }
    }
}
