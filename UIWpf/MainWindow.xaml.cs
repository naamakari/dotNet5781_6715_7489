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
using BL;
using BO;
using APIBL;
namespace UIWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static IBL bl = BlFactory.GetBL();
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void textName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textName.Text != "" && textPas.Password != "")
                enter.IsEnabled = true;
        }

        private void textPas_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (textName.Text != "" && textPas.Password != "")
                enter.IsEnabled = true;
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string str = bl.isAllowEntry(textName.Text, textPas.Password);
                if (str == "MANAGER")
                {
                    ManagerWindow managerWindow = new ManagerWindow(bl, textName.Text);
                    managerWindow.ShowDialog();
                }
                else if (str == "DRIVER")
                {
                    ;
                }          
            }
            catch(KeyNotFoundException ex)
            {
                enter.IsEnabled = false;
                error.Visibility = Visibility.Visible;
                textName.Text = "";
                textPas.Password = "";

            }
            
                
            

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUserWin = new AddUser(bl);
            addUserWin.ShowDialog();
            textName.Text = "";
            textPas.Password = "";
        } 

        private void add_MouseEnter(object sender, MouseEventArgs e)
        {
            add.FontSize = 16;
        }

        private void add_MouseLeave(object sender, MouseEventArgs e)
        {
            add.FontSize = 14;
        }
    }
}
