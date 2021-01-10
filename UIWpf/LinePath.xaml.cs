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
        IBL bl;
        public LinePath(IBL _bl)
        {
            bl = _bl;
            InitializeComponent();
            firstStationListBox.ItemsSource = bl.GetAllStations();
            LastStationListBox.ItemsSource = bl.GetAllStations();



            // stopWatch = new Stopwatch();

            timerworker = new BackgroundWorker();
            timerworker.DoWork += Timerworker_DoWork;
            timerworker.ProgressChanged += Timerworker_ProgressChanged;
            timerworker.WorkerReportsProgress = true;
            float num = (float)130.5;
           MessageBox.Show( TimeSpan.FromMinutes(num).ToString());
          //  timeSpan = TimeSpan.Parse(num.ToString());
           // MessageBox.Show(timeSpan.ToString());
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
            str = DateTime.Now.ToString();
            timer.Text = str.Substring(10, 9);
            //string timerText = stopWatch.Elapsed.ToString();
            // timerText = timerText.Substring(0, 8);
            //this.timerTextBlock.Text = timerText;

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
            BusStation firstStation = firstStationListBox.SelectedItem as BusStation;
            BusStation lastStation = LastStationListBox.SelectedItem as BusStation;
            try
            {

                busLineBLDataGrid.ItemsSource = bl.GetPossiblePath(firstStation.StationCode, lastStation.StationCode);
            }
            catch(BO.DalEmptyCollectionExeption)
            {

            }
        }
    }
}