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
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow(string name)
        {
            InitializeComponent();
            UserName.Content = " ,שלום"+ name;
        }
        User user { get; set; }

        private void Bus_Click(object sender, RoutedEventArgs e)
        {
            BusWindow busWindow = new BusWindow();
            busWindow.ShowDialog();
        }

        private void busStation_Click(object sender, RoutedEventArgs e)
        {
            BusStationWindow busStationWindow = new BusStationWindow();
            busStationWindow.ShowDialog();
        }

        private void BusLine_Click(object sender, RoutedEventArgs e)
        {
            BusLineWindow busLineWindow = new BusLineWindow();
            busLineWindow.ShowDialog();
        }
    }
}
