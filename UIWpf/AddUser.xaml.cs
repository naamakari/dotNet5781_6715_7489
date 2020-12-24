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

namespace UIWpf
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void manager_Checked(object sender, RoutedEventArgs e)
        {
            if(manager.IsChecked==true)
               driver.IsEnabled = false;
            else
                driver.IsEnabled = true;
        }

        private void driver_Checked(object sender, RoutedEventArgs e)
        {
            if (driver.IsChecked == true)
               manager.IsEnabled = false;
            else
                manager.IsEnabled = true;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            //הוספת המשתמש החדש לנתונים
            //אם הוא מנהל
            ManagerWindow managerWindow = new ManagerWindow();
            //לשלוח את היוזר
            this.Close();
            managerWindow.ShowDialog();
            //אם הוא נוסע
            //פןתח חלון לנוסע

            
        }
    }
}
