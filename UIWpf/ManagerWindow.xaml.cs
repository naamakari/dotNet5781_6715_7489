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

namespace UIWpf
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        IBL bl;   
        public ManagerWindow(IBL _Bl,string name)
        {
            bl = _Bl;
            InitializeComponent();

           UserName.Content = ","+name+" שלום ";
            UserName.Visibility = Visibility.Visible;
        }
      

        private void Bus_Click(object sender, RoutedEventArgs e)
        {
            BusWindow1 busWindow = new BusWindow1(bl);
            busWindow.ShowDialog();
        }

        private void busStation_Click(object sender, RoutedEventArgs e)
        {
            BusStationsWindow busStationWindow = new BusStationsWindow(bl);
            busStationWindow.ShowDialog();
        }

        private void BusLine_Click(object sender, RoutedEventArgs e)
        {
            BusLinesWindow busLineWindow = new BusLinesWindow(bl);
            busLineWindow.ShowDialog();
        }
    }
}
