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
    /// Interaction logic for toDrive.xaml
    /// </summary>
    public partial class toDrive : Window
    {
        public toDrive()
        {
            InitializeComponent();
        }
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
                drive.Visibility = Visibility.Visible;

        }
    }
}
