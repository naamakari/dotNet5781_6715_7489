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
using dotNet5781_01_6715_7489;

namespace dotNet5781_03B_6715_7489
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BusListView.ItemsSource = busStatic.buses;
            //cbListBuses.DisplayMemberPath = "Id";
            BusListView.SelectedIndex = 0;


            //List<string> str = new List<string>();
            //str.Add("Bus1");
            //str.Add("Bus2");
            //str.Add("Bus3");
            //cbListBuses.ItemsSource = str;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddBus newAddWin = new AddBus();
            newAddWin.ShowDialog();
            BusListView.ItemsSource = busStatic.buses;
        }

        private void detailButton_Click(object sender, RoutedEventArgs e)
        {
            toDrive newWin = new toDrive();
            newWin.myBus = (Bus)BusListView.SelectedItem;
            newWin.ShowDialog();
            //cbListBuses.SelectedIndex =
        }

        private void refuelButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hi", "world");
        }

        private void BusListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }

}
