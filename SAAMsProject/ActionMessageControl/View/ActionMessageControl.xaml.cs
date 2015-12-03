using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using SAAMControl.Model;
using SAAMControl.ViewModel;

namespace SAAMControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ActionmessageControl : Window
    {
        public ActionmessageControl()
        {
            var viewModel = new ActionMessageViewModel();
            InitializeComponent();
            viewModel.RequestClose += (i, ex) =>
            {
                this.Close();
            };
            this.DataContext = viewModel;
        }

        public void Init(ActionMessageModel model)
        {
            (this.DataContext as ActionMessageViewModel).MessageModel = model;
        }

        private void Hyperlink_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var hyperlink = sender as Hyperlink;
            Process.Start(hyperlink.NavigateUri.ToString());
        }
    }
}
