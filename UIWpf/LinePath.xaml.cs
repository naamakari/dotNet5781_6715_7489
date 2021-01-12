using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Collections.ObjectModel;

using BL;
using BO;
using APIBL;

namespace UIWpf
{
    /// <summary>
    /// Interaction logic for LinePath.xaml
    /// </summary>
    public partial class LinePath : Window
    {

        private Stopwatch stopWatch;
        private bool isTimerRun = false;
        BackgroundWorker timerworker;
        string str;
        IEnumerable<BusStationBL> stations;
        IEnumerable<BusLineBL> busLineBLsPossiblePath;
        IBL bl;

        public LinePath(IBL _bl)
        {
            bl = _bl;
            InitializeComponent();
            stations = bl.GetAllStations();


            firstStationComboBox.ItemsSource = stations;
            lastStationComboBox.ItemsSource = stations;


            // stopWatch = new Stopwatch();

            timerworker = new BackgroundWorker();
            timerworker.DoWork += Timerworker_DoWork;
            timerworker.ProgressChanged += Timerworker_ProgressChanged;
            timerworker.WorkerReportsProgress = true;

            // MessageBox.Show( TimeSpan.FromMinutes(num).ToString());
            //  timeSpan = TimeSpan.Parse(num.ToString());
            // MessageBox.Show(timeSpan.ToString());
            //MessageBox.Show(DateTime.Now.Hour+DateTime.Now.Minute.ToString()+DateTime.Now.Second);


        }

        private void Timerworker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isTimerRun)
            {
                timerworker.ReportProgress(1);
                Thread.Sleep(1000);
            }
        }

        private void Timerworker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            BusStation currBusStation = firstStationComboBox.SelectedItem as BusStation;
            str = DateTime.Now.ToString();
            timer.Text = str.Substring(10, 9);
            IEnumerable<LineTiming> lineTimings = bl.GetLineTimingsAccordingLine(busLineBLsPossiblePath, currBusStation);

            lineTimingDataGrid.DataContext = lineTimings;
            if (lineTimings.Count() == 0)
                exeption1.Visibility = Visibility.Visible;


        }


        private void LookAtTimeOfLines_Click(object sender, RoutedEventArgs e)
        {
            lineTimingDataGrid.Visibility = Visibility.Visible;
            timer.Visibility = Visibility.Visible;
            StopWatch.IsEnabled = true;

            if (!isTimerRun)
            {
                // stopWatch.Restart();
                str = DateTime.Now.ToString();
                timer.Text = str.Substring(10, 9);
                timer.Visibility = Visibility.Visible;
                isTimerRun = true;
                timerworker.RunWorkerAsync();
            }
        }

        private void StopWatch_Click(object sender, RoutedEventArgs e)
        {
            if (isTimerRun)
            {
                //stopWatch.Stop();
                timer.Visibility = Visibility.Hidden;
                isTimerRun = false;
            }
            searchLines.IsEnabled = true;
            busLineBLDataGrid.ItemsSource = null;
            busLineBLDataGrid.Visibility = Visibility.Visible;
            lineTimingDataGrid.Visibility = Visibility.Hidden;
            exeption1.Visibility = Visibility.Hidden;
            exeption2.Visibility = Visibility.Hidden;
            LookAtTimeOfLines.IsEnabled = false;
            searchLines.IsEnabled = false;
            StopWatch.IsEnabled = false;
            search1.Text = "";
            search2.Text = "";
            firstStationComboBox.SelectedItem =null;
            lastStationComboBox.SelectedItem = null;
        }

        private void searchLines_Click(object sender, RoutedEventArgs e)
        {
            BusStation firstStation = firstStationComboBox.SelectedItem as BusStation;
            BusStation lastStation = lastStationComboBox.SelectedItem as BusStation;
            searchLines.IsEnabled = false;
            try
            {
                busLineBLsPossiblePath = bl.GetPossiblePath(firstStation.StationCode, lastStation.StationCode);
                busLineBLDataGrid.ItemsSource = busLineBLsPossiblePath;
                LookAtTimeOfLines.IsEnabled = true;
                StopWatch.IsEnabled = true;
               // searchLines.IsEnabled = true;

            }
            catch (BO.DalEmptyCollectionExeption ex)
            {
                MessageBox.Show("", ex.Message);
            }
            catch (BO.invalidRequestExeption)
            {
                exeption2.Visibility = Visibility.Visible;
            }
        }

        private void firstStationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            exeption2.Visibility = Visibility.Hidden;
            exeption1.Visibility = Visibility.Hidden;
            if (firstStationComboBox.SelectedItem != null && lastStationComboBox.SelectedItem != null && (firstStationComboBox.SelectedItem.ToString() != lastStationComboBox.SelectedItem.ToString()))
                searchLines.IsEnabled = true;
            else if (firstStationComboBox.SelectedItem != null && lastStationComboBox.SelectedItem != null && firstStationComboBox.SelectedItem.ToString() == lastStationComboBox.SelectedItem.ToString())
            {
                MessageBox.Show("תחנת המוצא והיעד לא אפשריות, בחר/י תחנות מוצא ויעד אחרות", "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                firstStationComboBox.SelectedItem = null;
                lastStationComboBox.SelectedItem = null;
            }
        }

        private void search1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search1.Text != "")
            {
                IEnumerable<BusStationBL> busStationCollection = stations.Where(x => x.StationName.Contains(search1.Text));
                firstStationComboBox.ItemsSource = busStationCollection;
            }
            else
                firstStationComboBox.ItemsSource = bl.GetAllStations();
        }

        private void search2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search2.Text != "")
            {
                IEnumerable<BusStationBL> busStationCollection = stations.Where(x => x.StationName.Contains(search2.Text));
                lastStationComboBox.ItemsSource = busStationCollection;
            }
            else
                lastStationComboBox.ItemsSource = bl.GetAllStations();
        }
    }
}