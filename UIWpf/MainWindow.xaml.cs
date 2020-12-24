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

namespace UIWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            //בדיקה בנתונים שלנו אם הכל טוב
            //ואם לא, להקפיץ הודעה שיש בעיה (לפי החריגה המתאימה), למחוק את מה שיש בשדות ולהפוך את כפתור הכניסה ללא זמין
           // ManagerWindow managerWindow = new ManagerWindow();
          //  managerWindow.User;

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
