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
        private bool isTimerRun=false;
        BackgroundWorker timerworker;
        string str;
        IEnumerable<BusLineBL> busLineBLsPossiblePath;
        IBL bl;

        public LinePath(IBL _bl)
        {
            bl = _bl;
            InitializeComponent();

        
            firstStationComboBox.ItemsSource = bl.GetAllStations();
            lastStationComboBox.ItemsSource = bl.GetAllStations();


            // stopWatch = new Stopwatch();

            timerworker = new BackgroundWorker();
            timerworker.DoWork += Timerworker_DoWork;
            timerworker.ProgressChanged += Timerworker_ProgressChanged;
            timerworker.WorkerReportsProgress = true;
            float num = (float)130.5;
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
            //string timerText = stopWatch.Elapsed.ToString();
            // timerText = timerText.Substring(0, 8);
            //this.timerTextBlock.Text = timerText;
            lineTimingDataGrid.DataContext = bl.GetLineTimingsAccordingLine(busLineBLsPossiblePath, currBusStation);
        }


        private void LookAtTimeOfLines_Click(object sender, RoutedEventArgs e)
        {
         
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
        }

        private void searchLines_Click(object sender, RoutedEventArgs e)
        {
            BusStation firstStation = firstStationComboBox.SelectedItem as BusStation;
            BusStation lastStation = lastStationComboBox.SelectedItem as BusStation;
          //  string first = firstStationComboBox.SelectedItem as string;

            try
            {
                busLineBLsPossiblePath= bl.GetPossiblePath(firstStation.StationCode, lastStation.StationCode);
                busLineBLDataGrid.ItemsSource = busLineBLsPossiblePath;

            }
            catch (BO.DalEmptyCollectionExeption)
            {
               // busLineBLDataGrid.ItemsSource = null;
            }
        }

        private void firstStationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (firstStationComboBox.SelectedItem != null && lastStationComboBox.SelectedItem != null && (firstStationComboBox.SelectedItem != lastStationComboBox.SelectedItem))
                searchLines.IsEnabled = true;
            else if (firstStationComboBox.SelectedItem == lastStationComboBox.SelectedItem&&firstStationComboBox.SelectedItem!=null)
            {
                MessageBox.Show("תחנת המוצא והיעד לא אפשריות, בחר/י תחנות מוצא ויעד אחרות", "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                firstStationComboBox.SelectedItem = null;
                lastStationComboBox.SelectedItem = null;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource lineTimingViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("lineTimingViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // lineTimingViewSource.Source = [generic data source]
        }
    }
}