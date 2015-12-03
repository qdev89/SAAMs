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
using SAAMControl.Model;
using Telerik.Windows.Controls;
using WPFTestClientApplication.ViewModels;

namespace WPFTestClientApplication
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class MainWindow : RadRibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
}
