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

namespace UtilitiesProject
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();

            SAAMControl.Model.ActionMessageModel model = new ActionMessageModel();
            model.Message = "Test https://www.google.com in textblock";
            SAAMControl.ActionmessageControl control = new SAAMControl.ActionmessageControl();

            control.Init(model);
            control.Show();
        }
    }
}
