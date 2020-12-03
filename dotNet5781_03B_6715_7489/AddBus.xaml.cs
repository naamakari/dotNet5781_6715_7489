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
    /// Interaction logic for AddBus.xaml
    /// </summary>
    public partial class AddBus : Window
    {
        public AddBus()
        {
            InitializeComponent();
        }

        private bool nonNumeriable = false;
        //The following functions check the integrity of the input
        private void tbLiNum_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumeriable = false;
           
            //if the key is not a number from the up keyboard
            if (e.Key < Key.D0 || e.Key > Key.D9)
                //if the key is not a number from the side keyboard
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                    nonNumeriable = true;

            if ( nonNumeriable == true)
            {
                e.Handled = true;
                
            }
        }

        private void tbTreat_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumeriable = false;
            //if the key is not a number from the up keyboard
            if (e.Key < Key.D0 || e.Key > Key.D9)
                //if the key is not a number from the side keyboard
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                    if (e.Key != Key.Decimal)
                        nonNumeriable = true;

            if (nonNumeriable == true)
            {
                e.Handled = true;
            }
        }

        private void tbRef_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumeriable = false;
            //if the key is not a number from the up keyboard
            if (e.Key < Key.D0 || e.Key > Key.D9)
                //if the key is not a number from the side keyboard
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                    if (e.Key != Key.Decimal)
                        nonNumeriable = true;

            if (nonNumeriable == true)
            {
                e.Handled = true;
            }
        }

        private void tbKm_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumeriable = false;
            //if the key is not a number from the up keyboard
            if (e.Key < Key.D0 || e.Key > Key.D9)
                //if the key is not a number from the side keyboard
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                    if (e.Key != Key.Decimal)
                        nonNumeriable = true;

            if (nonNumeriable == true)
            {
                e.Handled = true;
                
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //The following functions check the input integrity logically
        private void tbKm_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbTreat.Text != "")
            {
                if (double.Parse(tbTreat.Text) > double.Parse(tbKm.Text))//if the filometers from the treat high from the kilometraz
                    Km1Eror.Visibility = Visibility.Visible;
                else
                    Km1Eror.Visibility = Visibility.Hidden;
            }

            if (tbRef.Text != "")
            {
                if (double.Parse(tbRef.Text) > double.Parse(tbKm.Text))//if the filometers from the reful high from the kilometraz
                    Km2Eror.Visibility = Visibility.Visible;
                else
                    Km2Eror.Visibility = Visibility.Hidden;
            }

            this.errors();
        }

        private void tbLiNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (dateSt.SelectedDate != null)
            {
                DateTime starDate = (DateTime)dateSt.SelectedDate;
                //Checks the correctness of the vehicle number according to the year of manufacture
                if ((starDate.Year >= 2018 && tbLiNum.Text.Length != 8) || (starDate.Year < 2018 && tbLiNum.Text.Length != 7))
                    NumEror.Visibility = Visibility.Visible;
                else
                    NumEror.Visibility = Visibility.Hidden;
            }
            if (tbLiNum.Text.Length >= 7)
            {
                if (busStatic.buses.Any(x => x.Id == tbLiNum.Text))
                    NumEror1.Visibility = Visibility.Visible;
                else
                    NumEror1.Visibility = Visibility.Hidden;

            }

            this.errors();
        }

        private void tbTreat_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbKm.Text != "")
            {
                if (double.Parse(tbTreat.Text) > double.Parse(tbKm.Text))//if the filometers from the treat high from the kilometraz
                    Km1Eror.Visibility = Visibility.Visible;
                else
                    Km1Eror.Visibility = Visibility.Hidden;
            }
            this.errors();
        }

        private void tbRef_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbKm.Text != "")
            {
                if (double.Parse(tbRef.Text) > double.Parse(tbKm.Text))//if the filometers from the reful high from the kilometraz
                    Km2Eror.Visibility = Visibility.Visible;
                else
                    Km2Eror.Visibility = Visibility.Hidden;
            }
            this.errors();
        }

        private void dateSt_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tbLiNum.Text != "")
            {
                DateTime starDate = (DateTime)dateSt.SelectedDate;
                //Checks the correctness of the vehicle number according to the year of manufacture
                if ((starDate.Year >= 2018 && tbLiNum.Text.Length != 8) || (starDate.Year < 2018 && tbLiNum.Text.Length != 7))
                    NumEror.Visibility = Visibility.Visible;
                else
                    NumEror.Visibility = Visibility.Hidden;
            }

            //cheaks if the date is reasonable
            TimeSpan diffDate = DateTime.Now - (DateTime)dateSt.SelectedDate;
            if (diffDate.TotalDays < 0)
            {
                dateInvalid1.Visibility = Visibility.Visible;
                add.IsEnabled = false;
            }
            else
            {
                dateInvalid1.Visibility = Visibility.Hidden;

            }

            if (dateTreat.SelectedDate != null)
            {
                TimeSpan diffDate1 = (DateTime)dateTreat.SelectedDate - (DateTime)dateSt.SelectedDate;
                if (diffDate1.TotalDays < 0)//If the date of the treatment is earlier than the date of commencement of the operation of the bus
                    DateEror.Visibility = Visibility.Visible;
                else
                    DateEror.Visibility = Visibility.Hidden;
            }
            this.errors();

        }

        private void dateTreat_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //cheaks if the date is reasonable
            TimeSpan diffDate = DateTime.Now - (DateTime)dateTreat.SelectedDate;
            if (diffDate.TotalDays < 0)
            {
                dateInvalid2.Visibility = Visibility.Visible;
                add.IsEnabled = false;

            }
            else
                dateInvalid2.Visibility = Visibility.Hidden;

            if (dateSt.SelectedDate != null)
            {
                TimeSpan diffDate1 = (DateTime)dateTreat.SelectedDate - (DateTime)dateSt.SelectedDate;
                if (diffDate1.TotalDays < 0)//If the date of the treatment is earlier than the date of commencement of the operation of the bus
                    DateEror.Visibility = Visibility.Visible;
                else
                    DateEror.Visibility = Visibility.Hidden;
            }
            this.errors();

        }

        private void errors()
        {
            //The function verifies if all the fields are filled in and if the content is 
            //correct and there are no discrepancies between the fields
            if (tbTreat.Text != "" && tbRef.Text != "" && tbLiNum.Text != "" && tbKm.Text != ""
               && dateTreat.SelectedDate != null && dateSt.SelectedDate != null)
                if (NumEror.Visibility == Visibility.Hidden && DateEror.Visibility == Visibility.Hidden
             && Km1Eror.Visibility == Visibility.Hidden && Km2Eror.Visibility == Visibility.Hidden
             && dateInvalid2.Visibility == Visibility.Hidden && dateInvalid1.Visibility == Visibility.Hidden)
                    add.IsEnabled = true;
                else
                    add.IsEnabled = false;
        }



        private void add_Click(object sender, RoutedEventArgs e)
        {
            //Adding the information from the window to a new bus and inserting it into the list
            string id = tbLiNum.Text;
            DateTime firstDate = (DateTime)dateSt.SelectedDate;
            DateTime TreatDate = (DateTime)dateTreat.SelectedDate;
            double kmSinceTreat = double.Parse(tbTreat.Text);
            double fuel = double.Parse(tbRef.Text);
            double km = double.Parse(tbKm.Text);
            Bus newBus = new Bus(id, firstDate, TreatDate, kmSinceTreat, fuel, km);
            busStatic.buses.Add(newBus);

            this.Close();
        }


    }
}
