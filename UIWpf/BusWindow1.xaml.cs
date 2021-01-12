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
using BL;
using BO;
using APIBL;
using System.Collections.ObjectModel;
using System.Collections.ObjectModel;
using System.Threading;
using System.ComponentModel;

namespace UIWpf
{
    /// <summary>
    /// Interaction logic for BusWindow1.xaml
    /// </summary>
    public partial class BusWindow1 : Window
    {
        ObservableCollection<Bus> buses=new ObservableCollection<Bus>();
        IBL bl;
        BackgroundWorker refuelBackground;
        BackgroundWorker treatBackground;
        public BusWindow1(IBL _Bl)
        {
            InitializeComponent();
            bl = _Bl;
            busStateComboBox.ItemsSource = Enum.GetValues(typeof(BusStatus));
            try
            {
                foreach (var item in bl.GetAllBuses())
                    buses.Add(item);
                busListView.ItemsSource = buses;
            }
            catch(BO.DalEmptyCollectionExeption ex)
            {
                MessageBox.Show(ex.Message,"הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        private void busListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refule.IsEnabled = true;
            treat.IsEnabled = true;
            delete.IsEnabled = true;
            BusDeatailsGrid.DataContext = busListView.SelectedItem as Bus;
        }

        private void refule_Click(object sender, RoutedEventArgs e)
        {
            Bus bus= busListView.SelectedItem as Bus;
            Bus newBus;
            buses.Remove(bus);
            bus.LicenseNumber = bl.setLicenseNumberFrom(bus.LicenseNumber);
            refuelBackground = new BackgroundWorker();
            refuelBackground.DoWork += RefuelBackground_DoWork;
            refuelBackground.RunWorkerCompleted += RefuelBackground_RunWorkerCompleted;
            try
            {
                bl.SendToRefuel(bus);
                newBus= bl.GetBus(bus.LicenseNumber);
                refuelBackground.RunWorkerAsync(newBus.LicenseNumber);
                BusDeatailsGrid.DataContext = newBus;
               // bus.LicenseNumber = bl.setLicenseNumberTo(bus.LicenseNumber);
                busListView.SelectedItem = newBus;
                buses.Add(newBus);

            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void RefuelBackground_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = e.Argument;
            Thread.Sleep(1200);
        }
        private void RefuelBackground_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string lisence = (string)e.Result;
            MessageBox.Show(" אוטובוס מספר " + lisence + " תודלק בהצלחה", "סיום התדלוק", MessageBoxButton.OK, MessageBoxImage.Information);
           string ClearLicence = bl.setLicenseNumberFrom(lisence);
           Bus returnBus = bl.GetBus(ClearLicence);

            returnBus.LicenseNumber = ClearLicence;
            buses.Remove(returnBus);
            // returnBus.LicenseNumber = bl.setLicenseNumberFrom(returnBus.LicenseNumber);
            //returnBus.LicenseNumber = bl.setLicenseNumberFrom(returnBus.LicenseNumber);
           
            returnBus.LicenseNumber=ClearLicence;

            bl.ReturnFromRefuel(returnBus);
            Bus TheNewBus = bl.GetBus(returnBus.LicenseNumber);
            BusDeatailsGrid.DataContext = TheNewBus;
            buses.Add(TheNewBus);

        }



        private void treat_Click(object sender, RoutedEventArgs e)
        {
            Bus bus = busListView.SelectedItem as Bus;
            Bus newBus;
            buses.Remove(bus);
            bus.LicenseNumber = bl.setLicenseNumberFrom(bus.LicenseNumber);
            try
            {
                bl.SendToTreat(bus);
                newBus= bl.GetBus(bus.LicenseNumber);
                BusDeatailsGrid.DataContext = newBus;
                //bus.LicenseNumber = bl.setLicenseNumberTo(bus.LicenseNumber);
                busListView.SelectedItem = newBus;
                buses.Add(newBus);
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Bus bus = busListView.SelectedItem as Bus;
            bus.LicenseNumber = bl.setLicenseNumberFrom(bus.LicenseNumber);
            buses.Remove(bus);
            //bl.DeleteBus(bus.LicenseNumber);
            BusDeatailsGrid.DataContext = null;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            add.IsEnabled = false;
            exit.Visibility = Visibility.Hidden;
            cancle.Visibility = Visibility.Visible;
            BusDeatailsGrid.Visibility = Visibility.Hidden;
            addGrid.Visibility = Visibility.Visible;
            BusDeatailsGrid.DataContext = null;

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

            if (nonNumeriable == true)
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


        //The following functions check the input integrity logically
        private void tbKm_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (kmSinceLastTreatTextBox1.Text != "")
            {
                if (double.Parse(kmSinceLastTreatTextBox1.Text) > double.Parse(kilometrazTextBox1.Text))//if the filometers from the treat high from the kilometraz
                    Km1Eror.Visibility = Visibility.Visible;
                else
                    Km1Eror.Visibility = Visibility.Hidden;
            }

            if (kmSinceRefeulTextBox1.Text != "")
            {
                if (double.Parse(kmSinceRefeulTextBox1.Text) > double.Parse(kilometrazTextBox1.Text))//if the filometers from the reful high from the kilometraz
                    Km2Eror.Visibility = Visibility.Visible;
                else
                    Km2Eror.Visibility = Visibility.Hidden;
            }

            this.errors();
        }

        private void tbLiNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (startDateDatePicker.SelectedDate != null)
            {
                DateTime starDate = (DateTime)startDateDatePicker.SelectedDate;
                //Checks the correctness of the vehicle number according to the year of manufacture
                if ((starDate.Year >= 2018 && licenseNumberTextBox1.Text.Length != 8) || (starDate.Year < 2018 && licenseNumberTextBox1.Text.Length != 7))
                    NumEror.Visibility = Visibility.Visible;
                else
                    NumEror.Visibility = Visibility.Hidden;
            }
           

            this.errors();
        }

        private void tbTreat_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (kilometrazTextBox1.Text != "")
            {
                if (double.Parse(kmSinceLastTreatTextBox1.Text) > double.Parse(kilometrazTextBox1.Text))//if the filometers from the treat high from the kilometraz
                    Km1Eror.Visibility = Visibility.Visible;
                else
                    Km1Eror.Visibility = Visibility.Hidden;
            }
            this.errors();
        }

        private void tbRef_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (kilometrazTextBox1.Text != "")
            {
                if (double.Parse(kmSinceRefeulTextBox1.Text) > double.Parse(kilometrazTextBox1.Text))//if the filometers from the reful high from the kilometraz
                    Km2Eror.Visibility = Visibility.Visible;
                else
                    Km2Eror.Visibility = Visibility.Hidden;
            }
            this.errors();
        }

        private void dateSt_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (licenseNumberTextBox1.Text != "")
            {
                DateTime starDate = (DateTime)startDateDatePicker.SelectedDate;
                //Checks the correctness of the vehicle number according to the year of manufacture
                if ((starDate.Year >= 2018 && licenseNumberTextBox1.Text.Length != 8) || (starDate.Year < 2018 && licenseNumberTextBox1.Text.Length != 7))
                    NumEror.Visibility = Visibility.Visible;
                else
                    NumEror.Visibility = Visibility.Hidden;
            }

            //cheaks if the date is reasonable
            TimeSpan diffDate = DateTime.Now - (DateTime)startDateDatePicker.SelectedDate;
            if (diffDate.TotalDays < 0)
            {
                dateInvalid1.Visibility = Visibility.Visible;
                add.IsEnabled = false;
            }
            else
            {
                dateInvalid1.Visibility = Visibility.Hidden;

            }

            if (dateSinceLastTreatDatePicker.SelectedDate != null)
            {
                TimeSpan diffDate1 = (DateTime)dateSinceLastTreatDatePicker.SelectedDate - (DateTime)startDateDatePicker.SelectedDate;
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
            TimeSpan diffDate = DateTime.Now - (DateTime)dateSinceLastTreatDatePicker.SelectedDate;
            if (diffDate.TotalDays < 0)
            {
                dateInvalid2.Visibility = Visibility.Visible;
                add.IsEnabled = false;

            }
            else
                dateInvalid2.Visibility = Visibility.Hidden;

            if (startDateDatePicker.SelectedDate != null)
            {
                TimeSpan diffDate1 = (DateTime)dateSinceLastTreatDatePicker.SelectedDate - (DateTime)startDateDatePicker.SelectedDate;
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
            if (kmSinceLastTreatTextBox1.Text != "" && kmSinceRefeulTextBox1.Text != "" && licenseNumberTextBox1.Text != "" && kilometrazTextBox1.Text != ""
               && dateSinceLastTreatDatePicker.SelectedDate != null && startDateDatePicker.SelectedDate != null&& busStateComboBox!=null)
                if (NumEror.Visibility == Visibility.Hidden && DateEror.Visibility == Visibility.Hidden
             && Km1Eror.Visibility == Visibility.Hidden && Km2Eror.Visibility == Visibility.Hidden
             && dateInvalid2.Visibility == Visibility.Hidden && dateInvalid1.Visibility == Visibility.Hidden)
                    toAdd.IsEnabled = true;
                else
                    toAdd.IsEnabled = false;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void toAdd_Click(object sender, RoutedEventArgs e)
        {
            Bus bus = new Bus()
            {
                LicenseNumber = licenseNumberTextBox1.Text,
                Kilometraz = float.Parse(kilometrazTextBox1.Text),
                KmSinceLastTreat=float.Parse(kmSinceLastTreatTextBox1.Text),
                KmSinceRefeul=float.Parse(kmSinceRefeulTextBox1.Text),
                DateSinceLastTreat=(DateTime)dateSinceLastTreatDatePicker.SelectedDate,
                StartDate=(DateTime)startDateDatePicker.SelectedDate,
                IsDeleted=false,
                BusState= (BO.BusStatus)busStateComboBox.SelectedItem,
            };
            try
            {
                bl.AddBus(bus);
                bus.LicenseNumber = bl.setLicenseNumberTo(bus.LicenseNumber);
                buses.Add(bus);
                BusDeatailsGrid.Visibility = Visibility.Visible;
                addGrid.Visibility = Visibility.Hidden;
                MessageBox.Show("אוטובוס מספר " + licenseNumberTextBox1.Text + " נוסף בהצלחה", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(BO.DalAlreayExistExeption ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        //The function returns a string of the license number without the'- '
      

        private void cancle_Click(object sender, RoutedEventArgs e)
        {
            add.IsEnabled = true;
            exit.Visibility = Visibility.Visible;
            cancle.Visibility = Visibility.Hidden;
            BusDeatailsGrid.Visibility = Visibility.Visible;
            addGrid.Visibility = Visibility.Hidden;
        }
    }
}
