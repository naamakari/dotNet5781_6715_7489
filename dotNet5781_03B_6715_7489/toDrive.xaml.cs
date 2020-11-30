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
    /// Interaction logic for toDrive.xaml
    /// </summary>
    public partial class toDrive : Window
    {
        public toDrive()
        {
            InitializeComponent();
        }
        public Bus myBus { get; set; }
        private bool nonNumeriable = false;
        private void dis_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumeriable = false;
            //if the key is not a number from the up keyboard
            if (e.Key < Key.D0 || e.Key > Key.D9)
                //if the key is not a number from the side keyboard
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                    if (e.Key != Key.Decimal)
                        nonNumeriable = true;

            if (nonNumeriable == true)
                e.Handled = true;
            if (e.Key == Key.Enter)
            {
                TimeSpan diff = DateTime.Now - myBus.LastTreatDate;//the difference between the last treat day and today
                if (myBus.stateOfFuel + float.Parse(dis.Text) <= 1200)//can take the driving from the fuel aspect
                {
                    if (diff.TotalDays < 365 && myBus.kmSinceLastTreat + float.Parse(dis.Text) <= 20000)//can take the driving from the treat aspect
                    {
                        myBus.upDateDetails(double.Parse(dis.Text));
                        myBus.stateBus = state.inDrive;
                        //שולח לנסיעה
                        // Console.WriteLine("The bus can take the driving, have a good day!");
                    }

                    else
                    {
                        MessageBox.Show("!!האוטובוס צריך טיפול", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                        myBus.stateBus = state.inTreat;
                        //שולח לטיפול
                    }
                }
                else
                {
                    MessageBox.Show("!!האוטובוס צריך תדלוק", "הודעת שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                    myBus.stateBus = state.inRefule;
                    //שולח לתדלוק

                }
            }
        }
        private void cancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
