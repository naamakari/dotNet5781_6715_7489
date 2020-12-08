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
        public static void Bus_StatusChanged(object sender, EventArgs e)
        {
            if (!(e is StateChangedEventArgs))
                return;
            StateChangedEventArgs temp = (StateChangedEventArgs)e;


            Binding binding = new Binding("StateBus");
           // binding.Source = BusListView.SelectedItem;
          //  BusListView[5];//להגדיר אינדקסר?
           // BusListView.SetBinding(bud, binding);
            //ListViewItem item1 = lsexample.FindItemWithText(temp.myId);
            //BusListView.find
            // ObservableCollection <busStatic> nm  =BusListView.SelectedItems;
            //temp.myId;
            //BusListView.View;
            MessageBox.Show("בדיקה", "יצאתי לתדלק מהחלון הראשי");
            //שינוי הצבעים לפי הסטטוס
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
            currentBus = fxElt.DataContext as Bus;

            if (currentBus.StateBus != state.inTreat && currentBus.StateBus != state.inDrive && currentBus.StateBus != state.inRefule)
            {
                var drivingButton = sender as Button;
                //drivingButton.IsEnabled = false;
                //In order to exit the trip, a new window will open in which it is necessary to enter the distance traveled
                toDrive newWin = new toDrive();
                newWin.myBus = currentBus;//Sending the selected bus to the next window
                newWin.ShowDialog();
            }
            else if (currentBus.StateBus == state.inTreat)
                MessageBox.Show("האוטובוס לא יכול לצאת לנסיעה כי הוא בטיפול", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (currentBus.StateBus == state.inDrive)
                MessageBox.Show("האוטובוס לא יכול לצאת לנסיעה כי הוא כבר בנסיעה", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                MessageBox.Show("האוטובוס לא יכול לצאת לנסיעה כי הוא בתדלוק", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void refuelButton_Click(object sender, RoutedEventArgs e)//event of sending bus to refuel
        {
            

            refuelWorker = new BackgroundWorker();
            refuelWorker.DoWork += RefuelWorker_DoWork;
            refuelWorker.RunWorkerCompleted += RefuelWorker_RunWorkerCompleted;//Event registration
           
    
            var fxElt = sender as FrameworkElement;//casting for bus
            currentBus = fxElt.DataContext as Bus;
            var myButtonRe =sender as Button;
            if (currentBus.StateBus != state.inTreat && currentBus.StateBus != state.inDrive && currentBus.StateBus != state.inRefule)
            {
                myButtonRe.IsEnabled = false;

                // (Button)BusListView.SelectedItem.RefuelButton;


                new StatusChangedObserver(currentBus);//event registration 

                currentBus.StateBus = state.inRefule;//update the status 
                refuelWorker.RunWorkerAsync(myButtonRe);//start the process
            }
            else if (currentBus.StateBus == state.inTreat)
                MessageBox.Show("האוטובוס לא יכול ללכת לתדלוק כי הוא כבר בטיפול", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (currentBus.StateBus == state.inDrive)
                MessageBox.Show("האוטובוס לא יכול ללכת לתדלוק כי הוא בנסיעה", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                MessageBox.Show("האוטובוס לא יכול ללכת לתדלוק כי הוא כבר בתדלוק", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);


        }

        private void RefuelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            currentBus.StateBus = state.ready;//use in Bus external for changed in the bus during the process 
            string numLine = currentBus.Id;
            MessageBox.Show(" אוטובוס מספר " + numLine + " תודלק בהצלחה", "סיום התדלוק");
            currentBus.stateOfFuel = 0.0;//update the state of the fule
            Button myBottonRef =(Button) e.Result;
            myBottonRef.IsEnabled = true;

        }

        private void RefuelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = e.Argument;
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
