﻿using System;
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
       List<string> str = new List<string>();
            str.Add("Bus1");
            str.Add("Bus2");
            str.Add("Bus3");
            cbListBuses.ItemsSource = str;
  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddBus newAddWin = new AddBus();
            newAddWin.ShowDialog();
        }

        private void detailButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello", "Hi");
        }

        private void refuelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}