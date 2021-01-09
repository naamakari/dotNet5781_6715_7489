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
using BO;
using APIBL;

namespace UIWpf
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        IBL bl;
        public AddUser(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
        }

        private void manager_Checked(object sender, RoutedEventArgs e)
        {
            if(manager.IsChecked==true)
               driver.IsEnabled = false;
            else
                driver.IsEnabled = true;
            if (textName.Text.Length >= 5 && textPas.Text.Length >= 6 && (manager.IsChecked == true || driver.IsChecked == true))
            {
                add.IsEnabled = true;
            }
        }

        private void driver_Checked(object sender, RoutedEventArgs e)
        {
            if (driver.IsChecked == true)
               manager.IsEnabled = false;
            else
                manager.IsEnabled = true;
            if (textName.Text.Length >= 5 && textPas.Text.Length >= 6 && (manager.IsChecked == true || driver.IsChecked == true))
            {
                add.IsEnabled = true;
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addUser(textName.Text, textPas.Text,(bool)manager.IsChecked);
                this.Close();
                ManagerWindow managerWindow = new ManagerWindow(bl, textName.Text);
                managerWindow.ShowDialog();
                
            }
            catch (BO.DalAlreayExistExeption ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                textName.Text = "";
                add.IsEnabled = false;
            }
            

            
        }

        private void textName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textName.Text.Length>=5&& textPas.Text.Length>=6&&(manager.IsChecked==true||driver.IsChecked==true))
            {
                add.IsEnabled = true;
            }
        }

        private void textPas_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textName.Text.Length >= 5 && textPas.Text.Length >= 6 && (manager.IsChecked == true || driver.IsChecked == true))
            {
                add.IsEnabled = true;
            }
        }
    }
}
