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
using SAAMs.Contracts.ViewModels;

namespace SAAMControl
{
    /// <summary>
    /// Interaction logic for ActionmessageControl
    /// </summary>
    public partial class ActionmessageControl : Window
    {
        private ActionMessageViewModel _actionMessageViewModel;

        public ActionmessageControl()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            _actionMessageViewModel = new ActionMessageViewModel();

            _actionMessageViewModel.RequestClose += (i, ex) =>
            {
                this.Close();
            };
            this.DataContext = _actionMessageViewModel;

            this.Closing += ActionmessageControl_Closing;

            this.Loaded += ActionmessageControl_Loaded;
        }

        private void ActionmessageControl_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }

        private void ActionmessageControl_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // trigger event close to notify that control has been close
            if (CloseEventHandler != null)
            {
                CloseEventHandler.Invoke(_actionMessageViewModel.MessageModel, null);
            }
        }


        public void Init(ActionMessageModel model)
        {
            _actionMessageViewModel.MessageModel = model;
            // In the case of the Action delegate, for the test client application, this will simply be to display a standard MessageBox with text “Action Performed: { 0}”, where { 0} is ID and with OK and Cancel buttons. 
            _actionMessageViewModel.MessageModel.ActionMessage = new Action(
                () =>
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show(string.Format("Action Performed: {0}", _actionMessageViewModel.MessageModel.Id), "Message", MessageBoxButton.OKCancel);

                    // If OK is pressed then the SAAM should be closed.
                    if (messageBoxResult == MessageBoxResult.OK)
                    {
                        this.Close();
                    }
                });
        }

        public event EventHandler CloseEventHandler;

        /// <summary>
        /// TODO: Implement better approach instead of using code behind handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // invoke Action Mesage
            _actionMessageViewModel.MessageModel.ActionMessage();
        }
    }
}
