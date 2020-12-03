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
        BackgroundWorker refuelWorker;

        public disPlayDetails()
        {
            InitializeComponent();

        }
        public Bus myBus2 { get; set; }
        ObservableCollection<Bus> oneOrganList;
       public void intilizied()
        {
           oneOrganList = new ObservableCollection<Bus>();
            // oneOrganList.Add(new Bus(myBus2.Id, myBus2.StartDate, myBus2.LastTreatDate, myBus2.Kilometrazh, myBus2.stateBus, myBus2.stateOfFuel, myBus2.kmSinceLastTreat));
            oneOrganList.Add(myBus2);//myBus2.Id, myBus2.StartDate, myBus2.LastTreatDate, myBus2.Kilometrazh, myBus2.stateBus, myBus2.stateOfFuel, myBus2.kmSinceLastTreat));

            Lv.ItemsSource = oneOrganList;
            feul.Value = 1200-myBus2.stateOfFuel;
            TimeSpan diffYear = DateTime.Now - myBus2.LastTreatDate;
            if (myBus2.kmSinceLastTreat >= 19900 || diffYear.TotalDays >=335)
                warnning.Visibility = Visibility.Visible;
        }

        private void RefuelBotton_Click(object sender, RoutedEventArgs e)
        {
            refuelWorker = new BackgroundWorker();
            refuelWorker.DoWork += RefuelWorker_DoWork;
            refuelWorker.RunWorkerCompleted += RefuelWorker_RunWorkerCompleted;
            var fxElt = sender as FrameworkElement;
            Bus selectedBus = fxElt.DataContext as Bus;
            
            this.Close();
            myBus2.stateBus = state.inRefule;
            myBus2.stateOfFuel = 0.0;
            feul.Value = 1200;
            selectedBus= myBus2;
            refuelWorker.RunWorkerAsync(selectedBus);

            //לשלוח את האוטובוס לתדלוק מבחינת זמן
        }

        private void RefuelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            myBus2 = (Bus)e.Result;
           myBus2.stateBus = state.ready;
            string numLine = myBus2.Id;
            MessageBox.Show(" אוטובוס מספר " + numLine + " תודלק בהצלחה", "סיום התדלוק");
        }

        private void RefuelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = (Bus)e.Argument;
            Thread.Sleep(12000);
        }

        private void TreatButton_Click(object sender, RoutedEventArgs e)
        {
            var fxElt = sender as FrameworkElement;
            Bus selectedBus = fxElt.DataContext as Bus;
            this.Close();
            selectedBus.kmSinceLastTreat = 0.0;
            myBus2.LastTreatDate = DateTime.Now;
            oneOrganList[0].LastTreatDate = DateTime.Now;
            selectedBus.stateBus = state.inTreat;
            if (selectedBus.stateOfFuel >= 1150)
            {//the time of the refuling include at the treat time
                selectedBus.stateOfFuel = 0.0;
                oneOrganList[0].stateOfFuel = 0.0;
                myBus2.stateOfFuel = 0.0;
                feul.Value = 1200;//update the progressbar to be full
            }
            //לשלוח את האוטובוס לטיפול מבחינת זמן
        }

        private void feul_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //feul.Value = myBus2.stateOfFuel;
        }
    }
}
