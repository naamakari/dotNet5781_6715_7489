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
    /// Interaction logic for BusStationsWindow.xaml
    /// </summary>
    public partial class BusStationsWindow : Window
    {
        IBL bl;
        public BusStationsWindow(IBL _Bl)
        {
            InitializeComponent();
            bl = _Bl;
        }
    }
}
