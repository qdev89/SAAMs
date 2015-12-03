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
                if (CloseEventHandler != null)
                {
                    CloseEventHandler.Invoke((this.DataContext as ActionMessageViewModel).MessageModel, null);
                }
                this.Close();
            };
            this.DataContext = viewModel;
        }

        public event EventHandler CloseEventHandler;

        public void Init(ActionMessageModel model)
        {
            var dataContext = (this.DataContext as ActionMessageViewModel);
            dataContext.MessageModel = model;
            dataContext.MessageModel.ActionMessage = new Action(
                () =>
                {
                   MessageBoxResult messageBoxResult = MessageBox.Show(string.Format("Action Performed: {0}", dataContext.MessageModel.Id), "Message", MessageBoxButton.OKCancel);

                    if (messageBoxResult == MessageBoxResult.OK)
                    {
                        this.Close();                        
                    }
                });
        }

        private void Hyperlink_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (this.DataContext as ActionMessageViewModel).MessageModel.ActionMessage();
        }

        public delegate void ChangeListAction();
    }
}
