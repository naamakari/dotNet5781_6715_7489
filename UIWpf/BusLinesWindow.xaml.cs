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
using System.Collections.ObjectModel;
using BL;
using BO;
using APIBL;

namespace UIWpf
{
    /// <summary>
    /// Interaction logic for BusLinesWindow.xaml
    /// </summary>
    public partial class BusLinesWindow : Window
    {
        ObservableCollection<BusLineBL> busLineBLs = new ObservableCollection<BusLineBL>();
        ObservableCollection<BusStation> busStations = new ObservableCollection<BusStation>();
        ObservableCollection<BusStation> SelectedItemBusStations = new ObservableCollection<BusStation>();
        ObservableCollection<BusStation> AllbusStation = new ObservableCollection<BusStation>();
        BusStation busStationSelected;
        IBL bl;
        int index;
        int indexOfStation;
        int helpIndex = 0;
        bool flag = true;
        int indexOfDelete;
        public BusLinesWindow(IBL _Bl)
        {
            InitializeComponent();
            bl = _Bl;
            try
            {
                foreach (BusLineBL item in bl.GetAllLines())
                    busLineBLs.Add(item);
                busLineBLListView.ItemsSource = busLineBLs;
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (BO.DalEmptyCollectionExeption ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private void addBusLine_Click(object sender, RoutedEventArgs e)
        {
            RealyAddBusLine.IsEnabled = false;
            addBusLine.IsEnabled = false;
            cancledAddBus.Visibility = Visibility.Visible;
            backToNenu.Visibility = Visibility.Hidden;
            DetailsGrid.Visibility = Visibility.Hidden;
            AddBusLineGrid.Visibility = Visibility.Visible;
            areaAtLandComboBox.ItemsSource = Enum.GetValues(typeof(Area));
            AllStationListView.IsEnabled = true;

            AddDistance.Visibility = Visibility.Hidden;
            AddDistance.Text = "";
            AddTime.Visibility = Visibility.Hidden;
            AddTime.Text = "";
            finishDisAndTime.Visibility = Visibility.Hidden;
            AddTimeAndDisLable.Visibility = Visibility.Hidden;
            TimeImage.Visibility = Visibility.Hidden;
            DisImage.Visibility = Visibility.Hidden;


            try
            {
                AllStationListView.ItemsSource = bl.GetAllStations();
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (BO.DalEmptyCollectionExeption ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void UpdateBusLine_Click(object sender, RoutedEventArgs e)
        {
            DetailsGrid.Visibility = Visibility.Hidden;
            UpdateGrid.Visibility = Visibility.Visible;
            RealyUpdateBusLine.IsEnabled = false;
            UpdateGrid.DataContext = busLineBLListView.SelectedItem as BusLineBL;
            areaAtLandTextBoxUpdate.ItemsSource = Enum.GetValues(typeof(Area));
            BusLineBL busLineBL = busLineBLListView.SelectedItem as BusLineBL;
            try
            {
                if (busLineBL != null)
                {
                    //collectionOfStationListViewUpdate.ItemsSource = bl.GetBusLineBL(busLineBL.BusId).CollectionOfStation;
                    SelectedItemBusStations.Clear();
                    foreach (BusStation item in bl.GetBusLineBL(busLineBL.BusId).CollectionOfStation)
                        SelectedItemBusStations.Add(item);
                    collectionOfStationListViewUpdate.ItemsSource = SelectedItemBusStations;
                }
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void DeleteBusLine_Click(object sender, RoutedEventArgs e)
        {
            BusLineBL busLineBL = busLineBLListView.SelectedItem as BusLineBL;
            busLineBLs.Remove(busLineBL);
            DetailsGrid.DataContext = null;
            collectionOfStationListView.ItemsSource = null;

            MessageBox.Show(" קו אוטובוס מספר " + busLineBL.BusNumLine + " נמחק", "", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void busLineBLListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            busLineBLListView.ItemsSource = busLineBLs;
            DeleteBusLine.IsEnabled = true;
            UpdateBusLine.IsEnabled = true;
            DetailsGrid.DataContext = busLineBLListView.SelectedItem as BusLineBL;
            BusLineBL busLineBL = busLineBLListView.SelectedItem as BusLineBL;
            try
            {
                if (busLineBL != null)
                    collectionOfStationListView.ItemsSource = bl.GetBusLineBL(busLineBL.BusId).CollectionOfStation;
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void busNumLineTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool nonNumeriable = false;

            //if the key is not a number from the up keyboard
            if (e.Key < Key.D0 || e.Key > Key.D9)
                //if the key is not a number from the side keyboard
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                    nonNumeriable = true;

            if (nonNumeriable == true)
            {
                e.Handled = true;

            }

        }

        private void AllStationListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BusStation busStation = AllStationListView.SelectedItem as BusStation;
                if (busStation != null)
                {
                    if (!busStations.Any(x => x.StationCode == busStation.StationCode))
                        busStations.Add(busStation);
                    collectionOfStationListViewAdd.DataContext = busStations;

                    if (busNumLineTextBox.Text != null && areaAtLandComboBox.SelectedItem != null && busStations.Count >= 2)
                        RealyAddBusLine.IsEnabled = true;

                    if (busStations.Count >= 2)
                        try
                        {
                            for (index = 0; index < busStations.Count() - 1;)
                            {
                                bl.GetFollowingStations(new FollowingStations
                                {
                                    StationCode1 = busStations[index].StationCode,
                                    StationCode2 = busStations[index + 1].StationCode
                                });
                                index++;
                            }
                        }
                        catch (BO.DalAlreayExistFollowingStationsExeption ex)
                        {
                            AddDistance.Visibility = Visibility.Visible;
                            AddTime.Visibility = Visibility.Visible;
                            finishDisAndTime.Visibility = Visibility.Visible;
                            AddTimeAndDisLable.Visibility = Visibility.Visible;
                            TimeImage.Visibility = Visibility.Visible;
                            DisImage.Visibility = Visibility.Visible;
                            AllStationListView.IsEnabled = false;
                            finishDisAndTime.IsChecked = false;
                            AddTimeAndDisLable.Content = " :הכנס/י את המרחק והזמן בדקות מתחנה " + busStations[index].StationCode + " לתחנה " + busStations[index + 1].StationCode;
                        }

                }
            }
            catch (System.NullReferenceException ex)
            {

            }
        }

        private void AddDistance_KeyDown(object sender, KeyEventArgs e)
        {
            bool nonNumeriable = false;

            //if the key is not a number from the up keyboard
            if (e.Key < Key.D0 || e.Key > Key.D9)
                //if the key is not a number from the side keyboard
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                    if (e.Key != Key.Decimal)
                        nonNumeriable = true;
            if (nonNumeriable == true)
            {
                e.Handled = true;

            }

        }

        private void finishDisAndTime_Checked(object sender, RoutedEventArgs e)
        {
            if (AddDistance.Text != "" && AddTime.Text != "")
            {
                bl.AddFollowingStations(new FollowingStations
                {
                    StationCode1 = busStations[index].StationCode,
                    StationCode2 = busStations[index + 1].StationCode,
                    DistanceBetweenStations = float.Parse(AddDistance.Text),
                    TimeTravelBetweenStations = float.Parse(AddTime.Text)
                });
                AddDistance.Visibility = Visibility.Hidden;
                AddTime.Visibility = Visibility.Hidden;
                finishDisAndTime.Visibility = Visibility.Hidden;
                AddTimeAndDisLable.Visibility = Visibility.Hidden;
                TimeImage.Visibility = Visibility.Hidden;
                DisImage.Visibility = Visibility.Hidden;
                AllStationListView.IsEnabled = true;
                collectionOfStationListViewAdd.IsEnabled = true;
                AddDistance.Text = "";
                AddTime.Text = "";
                index++;
            }
            else
            {
                MessageBox.Show("נא למלא את כל השדות", "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Warning);
                finishDisAndTime.IsChecked = false;
            }

        }

        private void deleteFromNewListButton_Click(object sender, RoutedEventArgs e)
        {
            var busLine = sender as FrameworkElement;//casting for bus
            BusStation busStation = busLine.DataContext as BusStation;
            busStations.Remove(busStation);

            if (busStations.Count >= 2)
                try
                {
                    for (index = 0; index < busStations.Count() - 1;)
                    {
                        bl.GetFollowingStations(new FollowingStations
                        {
                            StationCode1 = busStations[index].StationCode,
                            StationCode2 = busStations[index + 1].StationCode
                        });
                        index++;
                    }
                }
                catch (BO.DalAlreayExistFollowingStationsExeption ex)
                {
                    AddDistance.Visibility = Visibility.Visible;
                    AddTime.Visibility = Visibility.Visible;
                    finishDisAndTime.Visibility = Visibility.Visible;
                    TimeImage.Visibility = Visibility.Visible;
                    DisImage.Visibility = Visibility.Visible;
                    finishDisAndTime.IsChecked = false;
                    AddTimeAndDisLable.Visibility = Visibility.Visible;
                    collectionOfStationListViewAdd.IsEnabled = false;
                    AddTimeAndDisLable.Content = " :הכנס/י את המרחק והזמן בדקות מתחנה " + busStations[index].StationCode + " לתחנה " + busStations[index + 1].StationCode;
                }
            else
            {
                AddDistance.Visibility = Visibility.Hidden;
                AddTime.Visibility = Visibility.Hidden;
                finishDisAndTime.Visibility = Visibility.Hidden;
                TimeImage.Visibility = Visibility.Hidden;
                DisImage.Visibility = Visibility.Hidden;
                finishDisAndTime.IsChecked = false;
                AddTimeAndDisLable.Visibility = Visibility.Hidden;
                collectionOfStationListViewAdd.IsEnabled = true;
                AddDistance.Text = "";
                AddTime.Text = "";
            }

        }

        private void RealyAddBusLine_Click(object sender, RoutedEventArgs e)
        {

            BusLineBL busLineBL = new BusLineBL
            {
                BusNumLine = int.Parse(busNumLineTextBox.Text),
                AreaAtLand = (BO.Area)areaAtLandComboBox.SelectedItem,
                CollectionOfStation = busStations,
                NumberFirstStation = busStations[0].StationCode,
                NumberLastStation = busStations[busStations.Count() - 1].StationCode,
                FirstStation = busStations[0],
                LastStation = busStations[busStations.Count() - 1]
            };
            try
            {
                bl.AddBusLine(busLineBL);
                busLineBLs.Add(busLineBL);

                areaAtLandComboBox.Text = null;
                busNumLineTextBox.Text = null;
                busStations.Clear();
                collectionOfStationListViewAdd.ItemsSource = busStations;
                AddBusLineGrid.Visibility = Visibility.Hidden;
                DetailsGrid.Visibility = Visibility.Visible;
                addBusLine.IsEnabled = true;
                MessageBox.Show("קו האוטובוס נוסף בהצלחה", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (BO.DalAlreayExistExeption ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (BO.DalAlreayExistFollowingStationsExeption ex)
            {
                // return;
            }

        }

        private void areaAtLandComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (busNumLineTextBox.Text != null && areaAtLandComboBox.SelectedItem != null && busStations.Count >= 2)
                RealyAddBusLine.IsEnabled = true;
        }

        private void busNumLineTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (busNumLineTextBox.Text != null && areaAtLandComboBox.SelectedItem != null && busStations.Count >= 2)
                RealyAddBusLine.IsEnabled = true;
        }

        private void cancleAddBus_Click(object sender, RoutedEventArgs e)
        {
            addBusLine.IsEnabled = true;
            cancledAddBus.Visibility = Visibility.Hidden;
            backToNenu.Visibility = Visibility.Visible;
            DetailsGrid.Visibility = Visibility.Visible;
            AddBusLineGrid.Visibility = Visibility.Hidden;
            areaAtLandComboBox.Text = null;
            busNumLineTextBox.Text = null;
            busStations.Clear();
            collectionOfStationListViewAdd.DataContext = busStations;
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IEnumerable<BusLineBL> busLinesCollection = busLineBLs.Where(x => x.FirstStation.StationName.Contains(searchStationTextBox.Text) || x.LastStation.StationName.Contains(searchStationTextBox.Text)
            || x.BusNumLine.ToString().Contains(searchStationTextBox.Text) || x.AreaAtLand.ToString().Contains(searchStationTextBox.Text));
            busLineBLListView.ItemsSource = busLinesCollection;
            collectionOfStationListView.ItemsSource = null;
            UpdateBusLine.IsEnabled = false;
            DeleteBusLine.IsEnabled = false;

        }

        private void addStationToLine_Click(object sender, RoutedEventArgs e)
        {

            addStationToLine.IsEnabled = false;
            AllStationListBox.Visibility = Visibility.Visible;
            AllStationListBox.IsEnabled = true;
            indexOfNewStation.Text = null;
            finishAddStationCheckBox.IsChecked = false;
            finishAddStationCheckBox.IsEnabled = false;
            indexOfNewStation.Visibility = Visibility.Visible;
            indexOfNewStation.IsEnabled = false;
            labelToAdd.Visibility = Visibility.Visible;
            finishAddStationCheckBox.Visibility = Visibility.Visible;

            try
            {
                AllStationListBox.ItemsSource = bl.GetAllStations();
                AllStationListBox.IsEnabled = true;
            }
            catch (BO.DalEmptyCollectionExeption ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private void AllStationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            indexOfNewStation.IsEnabled = true;
            AllStationListBox.IsEnabled = false;
            // indexOfNewStation.MaxLength=SelectedItemBusStations.Count()

            busStationSelected = AllStationListBox.SelectedItem as BusStation;
            if (busStationSelected != null)
            {
                if (SelectedItemBusStations.Any(x => x.StationCode == busStationSelected.StationCode))
                {
                    MessageBox.Show("תחנה זאת קיימת כבר בקו זה");
                    AllStationListBox.IsEnabled = true;
                }
            }

        }

        private void finishAddStationCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            bool isFirst = false;
            bool isLast = false;
            indexOfStation = int.Parse(indexOfNewStation.Text);
            if (int.Parse(indexOfNewStation.Text) > SelectedItemBusStations.Count() + 1 || int.Parse(indexOfNewStation.Text) <= 0)
            {
                MessageBox.Show("האינדקס לא מתאים למספר התחנות בקו, הכנס/י מספר מתאים");
                finishAddStationCheckBox.IsChecked = false;
                finishAddStationCheckBox.IsEnabled = true;
                indexOfNewStation.IsEnabled = true;
            }
            else
            {
                if (int.Parse(indexOfNewStation.Text) == 1)
                {
                    isFirst = true;
                }
                else if (int.Parse(indexOfNewStation.Text) == SelectedItemBusStations.Count())
                    isLast = true;

                StationInLine newStationInLine = new StationInLine
                {
                    IndexStationAtLine = int.Parse(indexOfNewStation.Text),
                    IsDeleted = false,
                    IsFirstStation = isFirst,
                    IsLastStation = isLast,
                    LineId = int.Parse(busIdTextBlock.Text),
                    StationCode = busStationSelected.StationCode
                };
                try
                {
                    bl.AddStationToBus(newStationInLine);
                    //collectionOfStationListViewUpdate.ItemsSource = bl.GetBusLineBL(int.Parse(busIdTextBlock.Text)).CollectionOfStation;
                    SelectedItemBusStations.Clear();
                    foreach (BusStation item in bl.GetBusLineBL(int.Parse(busIdTextBlock.Text)).CollectionOfStation)
                        SelectedItemBusStations.Add(item);
                    collectionOfStationListViewUpdate.ItemsSource = SelectedItemBusStations;
                    AllStationListBox.Visibility = Visibility.Hidden;
                    indexOfNewStation.Visibility = Visibility.Hidden;
                    labelToAdd.Visibility = Visibility.Hidden;
                    finishAddStationCheckBox.Visibility = Visibility.Hidden;
                    addStationToLine.IsEnabled = true;
                    collectionOfStationListViewAdd.IsEnabled = true;
                    flag = true;
                    if (int.Parse(indexOfNewStation.Text) == 1)
                        try
                        {
                            bl.GetFollowingStations(new FollowingStations
                            {
                                StationCode1 = SelectedItemBusStations[0].StationCode,
                                StationCode2 = SelectedItemBusStations[1].StationCode
                            });
                        }
                        catch (BO.DalAlreayExistFollowingStationsExeption ex)
                        {
                            AddDistanceUpdate.Visibility = Visibility.Visible;
                            AddTimeUpdate.Visibility = Visibility.Visible;
                            finishDisAndTimeUpdate.Visibility = Visibility.Visible;
                            AddTimeAndDisLableUpdate.Visibility = Visibility.Visible;
                            TimeImageUpdate.Visibility = Visibility.Visible;
                            DisImageUpdate.Visibility = Visibility.Visible;
                            AllStationListBox.IsEnabled = false;
                            finishDisAndTimeUpdate.IsChecked = false;
                            RealyUpdateBusLine.IsEnabled = false;
                            AddTimeAndDisLableUpdate.Content = " :הכנס/י את המרחק והזמן בדקות מתחנה " + SelectedItemBusStations[0].StationCode + " לתחנה " + SelectedItemBusStations[1].StationCode;
                        }
                    else if (int.Parse(indexOfNewStation.Text) == SelectedItemBusStations.Count() - 1)
                    {
                        try
                        {
                            bl.GetFollowingStations(new FollowingStations
                            {
                                StationCode1 = SelectedItemBusStations[SelectedItemBusStations.Count() - 2].StationCode,
                                StationCode2 = SelectedItemBusStations[SelectedItemBusStations.Count() - 1].StationCode
                            });
                        }
                        catch (BO.DalAlreayExistFollowingStationsExeption ex)
                        {
                            AddDistanceUpdate.Visibility = Visibility.Visible;
                            AddTimeUpdate.Visibility = Visibility.Visible;
                            finishDisAndTimeUpdate.Visibility = Visibility.Visible;
                            AddTimeAndDisLableUpdate.Visibility = Visibility.Visible;
                            TimeImageUpdate.Visibility = Visibility.Visible;
                            DisImageUpdate.Visibility = Visibility.Visible;
                            AllStationListBox.IsEnabled = false;
                            finishDisAndTimeUpdate.IsChecked = false;
                            RealyUpdateBusLine.IsEnabled = false;
                            AddTimeAndDisLableUpdate.Content = " :הכנס/י את המרחק והזמן בדקות מתחנה " + SelectedItemBusStations[SelectedItemBusStations.Count() - 2].StationCode + " לתחנה " + SelectedItemBusStations[SelectedItemBusStations.Count() - 1].StationCode;
                        }
                    }
                    else
                    {
                        try
                        {



                            bl.GetFollowingStations(new FollowingStations
                            {
                                StationCode1 = SelectedItemBusStations[indexOfStation - 2].StationCode,
                                StationCode2 = SelectedItemBusStations[indexOfStation - 1].StationCode
                            });


                        }
                        catch (BO.DalAlreayExistFollowingStationsExeption ex)
                        {
                            AddDistanceUpdate.Visibility = Visibility.Visible;
                            AddTimeUpdate.Visibility = Visibility.Visible;
                            finishDisAndTimeUpdate.Visibility = Visibility.Visible;
                            AddTimeAndDisLableUpdate.Visibility = Visibility.Visible;
                            TimeImageUpdate.Visibility = Visibility.Visible;
                            DisImageUpdate.Visibility = Visibility.Visible;
                            AllStationListBox.IsEnabled = false;
                            finishDisAndTimeUpdate.IsChecked = false;
                            RealyUpdateBusLine.IsEnabled = false;
                            AddTimeAndDisLableUpdate.Content = " :הכנס/י את המרחק והזמן בדקות מתחנה " + SelectedItemBusStations[int.Parse(indexOfNewStation.Text) - 2].StationCode + " לתחנה " + SelectedItemBusStations[int.Parse(indexOfNewStation.Text) - 1].StationCode;
                        }
                    }



                }
                catch (BO.DalAlreayExistExeption ex)
                {
                    MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                catch (KeyNotFoundException ex)
                {
                    MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }

        }

        private void indexOfNewStation_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (indexOfNewStation.Text != null)
                finishAddStationCheckBox.IsEnabled = true;
        }

        private void cancledUpdateClick_Click(object sender, RoutedEventArgs e)
        {
            UpdateGrid.Visibility = Visibility.Hidden;
            DetailsGrid.Visibility = Visibility.Visible;

            AddDistanceUpdate.Text = "";
            AddDistanceUpdate.Visibility = Visibility.Hidden;
            AddTimeUpdate.Text = "";
            AddTimeUpdate.Visibility = Visibility.Hidden;
            finishDisAndTimeUpdate.IsChecked = false;
            finishDisAndTimeUpdate.Visibility = Visibility.Hidden;
            AddTimeAndDisLableUpdate.Visibility = Visibility.Hidden;
            TimeImageUpdate.Visibility = Visibility.Hidden;
            DisImageUpdate.Visibility = Visibility.Hidden;
        }

        private void DeleteStationUpdate_Click(object sender, RoutedEventArgs e)
        {
            //bool isFirst = false;
            //bool isLast = false;
            var busLine = sender as FrameworkElement;//casting for bus line
            BusStation busStation = busLine.DataContext as BusStation;
            //indexOfDelete = SelectedItemBusStations.IndexOf(busStation);
            //if (indexOfDelete == 0)
            //    isFirst = true;
            //else if (indexOfDelete == SelectedItemBusStations.Count() - 1)
            //    isLast = true;
            //StationInLine stationInLineDelete = new StationInLine
            //{
            //    IsDeleted = false,
            //    IndexStationAtLine = indexOfDelete,
            //    IsFirstStation = isFirst,
            //    IsLastStation = isLast,
            //    StationCode = busStation.StationCode,
            //    LineId = int.Parse(busIdTextBlock.Text)
            //};
            try
            {
               StationInLine stationInLineDelete1= bl.getStationInLine(int.Parse(busIdTextBlock.Text), busStation.StationCode);
                bl.DeleteStationInLine(stationInLineDelete1);
                SelectedItemBusStations.Remove(busStation);
                //collectionOfStationListViewUpdate.ItemsSource = SelectedItemBusStations;

                if (indexOfDelete != 0 && indexOfDelete != SelectedItemBusStations.Count())
                {
                    try
                    {

                        bl.GetFollowingStations(new FollowingStations
                        {
                            StationCode1 = SelectedItemBusStations[indexOfDelete - 1].StationCode,
                            StationCode2 = SelectedItemBusStations[indexOfDelete].StationCode
                        });

                    }
                    catch (BO.DalAlreayExistFollowingStationsExeption ex)
                    {
                        AddDistanceUpdate.Visibility = Visibility.Visible;
                        AddTimeUpdate.Visibility = Visibility.Visible;
                        finishDisAndTimeUpdate.Visibility = Visibility.Visible;
                        AddTimeAndDisLableUpdate.Visibility = Visibility.Visible;
                        TimeImageUpdate.Visibility = Visibility.Visible;
                        DisImageUpdate.Visibility = Visibility.Visible;
                        AllStationListBox.IsEnabled = false;
                        finishDisAndTimeUpdate.IsChecked = false;
                        RealyUpdateBusLine.IsEnabled = false;
                        collectionOfStationListViewUpdate.IsEnabled = false;
                        AddTimeAndDisLableUpdate.Content = " :הכנס/י את המרחק והזמן בדקות מתחנה " + SelectedItemBusStations[indexOfDelete - 1].StationCode + " לתחנה " + SelectedItemBusStations[indexOfDelete].StationCode;
                        flag = false;
                    }
                }
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void areaAtLandTextBoxUpdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (busNumLineTextBoxUpdate.Text != null && collectionOfStationListViewUpdate.Items != null)
                RealyUpdateBusLine.IsEnabled = true;
        }

        private void busNumLineTextBoxUpdate_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (busNumLineTextBoxUpdate.Text != null && collectionOfStationListViewUpdate.Items != null && areaAtLandTextBoxUpdate.SelectedItem != null)
                RealyUpdateBusLine.IsEnabled = true;
        }

        private void RealyUpdateBusLine_Click(object sender, RoutedEventArgs e)
        {
            BusLine newBusLine = new BusLine
            {
                BusId = int.Parse(busIdTextBlock.Text),
                BusNumLine = int.Parse(busNumLineTextBoxUpdate.Text),
                NumberFirstStation = SelectedItemBusStations[0].StationCode,
                NumberLastStation = SelectedItemBusStations[SelectedItemBusStations.Count() - 1].StationCode,
                AreaAtLand = (BO.Area)areaAtLandTextBoxUpdate.SelectedItem
            };
            try
            {
                bl.UpdateBusLine(newBusLine);
                busLineBLs.Clear();
                foreach (BusLineBL item in bl.GetAllLines())
                    busLineBLs.Add(item);
                busLineBLListView.ItemsSource = busLineBLs;
                BusLineBL busLineBLNew = new BusLineBL();
                busLineBLNew = bl.GetBusLineBL(newBusLine.BusId);
                DetailsGrid.DataContext = busLineBLNew;
                collectionOfStationListView.ItemsSource = busLineBLNew.CollectionOfStation;
                DetailsGrid.Visibility = Visibility.Visible;
                UpdateGrid.Visibility = Visibility.Hidden;
                
                MessageBox.Show("קו האוטובוס עודכן בהצלחה", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (BO.DalEmptyCollectionExeption ex)
            {
                MessageBox.Show(ex.Message, "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void finishDisAndTimeUpdate_Checked(object sender, RoutedEventArgs e)
        {

            if (AddDistanceUpdate.Text != "" && AddTimeUpdate.Text != "")
            {
                if (flag == true && int.Parse(indexOfNewStation.Text) != 1)
                {
                    bl.AddFollowingStations(new FollowingStations
                    {
                        StationCode1 = SelectedItemBusStations[int.Parse(indexOfNewStation.Text) - 2].StationCode,
                        StationCode2 = SelectedItemBusStations[int.Parse(indexOfNewStation.Text) - 1].StationCode,
                        DistanceBetweenStations = float.Parse(AddDistanceUpdate.Text),
                        TimeTravelBetweenStations = float.Parse(AddTimeUpdate.Text)
                    });
                }
                else if (flag == true && int.Parse(indexOfNewStation.Text) == 1)
                {
                    bl.AddFollowingStations(new FollowingStations
                    {
                        StationCode1 = SelectedItemBusStations[int.Parse(indexOfNewStation.Text) - 1].StationCode,
                        StationCode2 = SelectedItemBusStations[int.Parse(indexOfNewStation.Text)].StationCode,
                        DistanceBetweenStations = float.Parse(AddDistanceUpdate.Text),
                        TimeTravelBetweenStations = float.Parse(AddTimeUpdate.Text)
                    });
                }
                else
                {
                    bl.AddFollowingStations(new FollowingStations
                    {
                        StationCode1 = SelectedItemBusStations[indexOfDelete - 1].StationCode,
                        StationCode2 = SelectedItemBusStations[indexOfDelete].StationCode,
                        DistanceBetweenStations = float.Parse(AddDistanceUpdate.Text),
                        TimeTravelBetweenStations = float.Parse(AddTimeUpdate.Text)
                    });
                }
                AddDistanceUpdate.Visibility = Visibility.Hidden;
                AddTimeUpdate.Visibility = Visibility.Hidden;
                finishDisAndTimeUpdate.Visibility = Visibility.Hidden;
                AddTimeAndDisLableUpdate.Visibility = Visibility.Hidden;
                TimeImageUpdate.Visibility = Visibility.Hidden;
                DisImageUpdate.Visibility = Visibility.Hidden;
                AllStationListBox.IsEnabled = true;
                collectionOfStationListViewUpdate.IsEnabled = true;
                ///RealyUpdateBusLine.IsEnabled = true;
                if (busNumLineTextBoxUpdate.Text != null && collectionOfStationListViewUpdate.Items != null && areaAtLandTextBoxUpdate.SelectedItem != null)
                    RealyUpdateBusLine.IsEnabled = true;
                else
                    RealyUpdateBusLine.IsEnabled = false;
                AddDistanceUpdate.Text = "";
                AddTimeUpdate.Text = "";
                if (helpIndex == 0 && flag == true)
                {
                    try
                    {

                        bl.GetFollowingStations(new FollowingStations
                        {
                            StationCode1 = SelectedItemBusStations[indexOfStation - 2].StationCode,
                            StationCode2 = SelectedItemBusStations[indexOfStation-1].StationCode
                        });

                        helpIndex++;
                    }
                    catch (BO.DalAlreayExistFollowingStationsExeption ex)
                    {
                        AddDistanceUpdate.Visibility = Visibility.Visible;
                        AddTimeUpdate.Visibility = Visibility.Visible;
                        finishDisAndTimeUpdate.Visibility = Visibility.Visible;
                        AddTimeAndDisLableUpdate.Visibility = Visibility.Visible;
                        TimeImageUpdate.Visibility = Visibility.Visible;
                        DisImageUpdate.Visibility = Visibility.Visible;
                        AllStationListBox.IsEnabled = false;
                        finishDisAndTimeUpdate.IsChecked = false;
                        RealyUpdateBusLine.IsEnabled = false;
                        collectionOfStationListViewUpdate.IsEnabled = false;
                        AddTimeAndDisLableUpdate.Content = " :הכנס/י את המרחק והזמן בדקות מתחנה " + SelectedItemBusStations[int.Parse(indexOfNewStation.Text) - 1].StationCode + " לתחנה " + SelectedItemBusStations[int.Parse(indexOfNewStation.Text)].StationCode;
                        helpIndex++;
                    }
                }

            }
            else
            {
                MessageBox.Show("נא למלא את כל השדות", "הודעת מערכת", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                finishDisAndTimeUpdate.IsChecked = false;
            }
        }
    }
}
