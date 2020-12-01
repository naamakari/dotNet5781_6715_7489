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
using dotNet5781_01_6715_7489;


namespace dotNet5781_03B_6715_7489
{
    /// <summary>
    /// Interaction logic for disPlayDetails.xaml
    /// </summary>
    public partial class disPlayDetails : Window
    {
        public disPlayDetails()
        {
            InitializeComponent();
        }
        public Bus myBus2 { get; set; }
       public void intilizied()
        {
            List<Bus> oneOrganList = new List<Bus>();
            oneOrganList.Add(new Bus(myBus2.Id, myBus2.StartDate, myBus2.LastTreatDate, myBus2.Kilometrazh, myBus2.stateOfFuel, myBus2.kmSinceLastTreat));
            Lv.ItemsSource = oneOrganList;

        }

        private void RefuelBotton_Click(object sender, RoutedEventArgs e)
        {
            var fxElt = sender as FrameworkElement;
            Bus selectedBus = fxElt.DataContext as Bus;
            selectedBus.stateOfFuel = 0.0;
            selectedBus.stateBus = state.inRefule;
            //לשלוח את האוטובוס לתדלוק מבחינת זמן
        }

        private void TreatButton_Click(object sender, RoutedEventArgs e)
        {
            var fxElt = sender as FrameworkElement;
            Bus selectedBus = fxElt.DataContext as Bus;
            selectedBus.kmSinceLastTreat = 0.0;
            selectedBus.stateBus = state.inTreat;
            //לשלוח את האוטובוס לטיפול מבחינת זמן
        }
    }
}
