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
        static int counter = 0;
        private bool nonNumeriable=false;
        private void tbLiNum_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumeriable = false;
            counter++;
            //if the key is not a number from the up keyboard
            if (e.Key < Key.D0 || e.Key > Key.D9)
                //if the key is not a number from the side keyboard
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                        nonNumeriable = true;

            if (counter == 8 || nonNumeriable == true)
            {
                e.Handled = true;
                counter = 0;
            }
        }
        private void tbTreat_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumeriable = false;
            counter++;
            //if the key is not a number from the up keyboard
            if (e.Key < Key.D0 || e.Key > Key.D9)
                //if the key is not a number from the side keyboard
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                    if (e.Key != Key.Decimal)
                        nonNumeriable = true;

            if (counter == 8 || nonNumeriable == true)
            {
                e.Handled = true;
                counter = 0;
            }
        }
        private void tbRef_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumeriable = false;
            counter++;
            //if the key is not a number from the up keyboard
            if (e.Key < Key.D0 || e.Key > Key.D9)
                //if the key is not a number from the side keyboard
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                    if (e.Key != Key.Decimal)
                        nonNumeriable = true;

            if (counter == 8 || nonNumeriable == true)
            {
                e.Handled = true;
                counter = 0;
            }
        }

        private void tbKm_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumeriable = false;
            counter++;
            //if the key is not a number from the up keyboard
            if (e.Key < Key.D0 || e.Key > Key.D9)
                //if the key is not a number from the side keyboard
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                    if (e.Key != Key.Decimal)
                        nonNumeriable = true;

            if (counter == 8 || nonNumeriable == true)
            {
                e.Handled = true;
                counter = 0;
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbKm_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbTreat.Text != "" && tbRef.Text != "" && tbLiNum.Text != "" && tbKm.Text != "")
                add.IsEnabled = true;
            else
                add.IsEnabled = false;
        }

        private void tbLiNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (dateSt.SelectedDate!=null && dateTreat.SelectedDate != null && tbTreat.Text != "" && tbRef.Text != "" && tbLiNum.Text != "" && tbKm.Text != "")
                add.IsEnabled = true;
            else
                add.IsEnabled = false;
        }

        private void tbTreat_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (dateSt.Text!=null&&dateTreat.Text!=null&& tbTreat.Text != "" && tbRef.Text != "" && tbLiNum.Text != "" && tbKm.Text != "")
                add.IsEnabled = true;
            else
                add.IsEnabled = false;
        }

        private void tbRef_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbTreat.Text != "" && tbRef.Text != "" && tbLiNum.Text != "" && tbKm.Text != "")
                add.IsEnabled = true;
            else
                add.IsEnabled = false;
        }
    }
}
