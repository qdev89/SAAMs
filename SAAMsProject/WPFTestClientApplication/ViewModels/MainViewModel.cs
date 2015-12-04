using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SAAMControl.Model;
using SAAMs.Contracts.Base;

namespace WPFTestClientApplication.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ActionMessageModel _newActionMessage;
        private ActionMessageModel _selectedActionMessage;
        private ObservableCollection<ActionMessageModel> _actionMessageList;

        public MainViewModel()
        {
            this.NewActionMessage = new ActionMessageModel();
            this.ActionMessageList = new ObservableCollection<ActionMessageModel>();
        }

        #region Properties
        /// <summary>
        /// current selected action message in grid view
        /// </summary>
        public ActionMessageModel SelectedActionMessage
        {
            get { return _selectedActionMessage; }
            set
            {
                _selectedActionMessage = value;
                NotifyPropertyChanged("SelectedActionMessage");
            }
        }

        /// <summary>
        /// the new action message that will be added to grid view
        /// </summary>
        public ActionMessageModel NewActionMessage
        {
            get { return _newActionMessage; }
            set
            {
                _newActionMessage = value;
                NotifyPropertyChanged("NewActionMessage");
            }
        }

        /// <summary>
        /// The list is bound to grid view
        /// </summary>
        public ObservableCollection<ActionMessageModel> ActionMessageList
        {
            get { return _actionMessageList; }
            set
            {
                _actionMessageList = value;
                NotifyPropertyChanged("ActionMessageList");
            }
        }
        #endregion

        #region Commands
        #region ShowActionMessageCommand Command
        private RelayCommand _showCommand;

        /// <summary>
        /// Show selected Action Message
        /// </summary>
        public ICommand ShowActionMessageCommand
        {
            get
            {
                if (_showCommand == null)
                {
                    _showCommand = new RelayCommand(OnShow, CanExecuteShow);
                }

                return _showCommand;
            }
        }

        public void OnShow(object parameter)
        {
            if (!SelectedActionMessage.CanStopShowing)
            {
                SAAMControl.ActionmessageControl control = new SAAMControl.ActionmessageControl();
                control.CloseEventHandler += ControlCloseEventHandler;
                control.Init(this.SelectedActionMessage);
                control.Show();
            }
        }

        /// <summary>
        /// Handler for close event of Action Message Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlCloseEventHandler(object sender, System.EventArgs e)
        {
            var senderActionMessageModel = sender as ActionMessageModel;
            var existActionMessageModel = ActionMessageList.SingleOrDefault(x => x.Id == senderActionMessageModel.Id);
            if (existActionMessageModel != null)
            {
                // update status of can stop showing 
                existActionMessageModel.CanStopShowing = senderActionMessageModel.CanStopShowing;
            }
        }

        /// <summary>
        /// Command just can enable if action message has been selected
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private bool CanExecuteShow(object parameter)
        {
            return this.SelectedActionMessage != null;
        }

        #endregion
        #region AddActionMessageCommand Command
        private RelayCommand _addCommand;

        /// <summary>
        /// Command to add an action message
        /// </summary>
        public ICommand AddActionMessageCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(OnAdd, CanExecuteAdd);
                }

                return _addCommand;
            }
        }

        public void OnAdd(object parameter)
        {
            this.ActionMessageList.Add(NewActionMessage);
            this.NewActionMessage = new ActionMessageModel();
        }

        private bool CanExecuteAdd(object parameter)
        {
            return NewActionMessage != null;
        }

        #endregion

        #region Cancel Command
        private RelayCommand cancelAddCommand;
        public ICommand CancelAddActionMessageCommand
        {
            get
            {
                if (cancelAddCommand == null)
                {
                    cancelAddCommand = new RelayCommand(OnCancelAdd, CanExecuteCancelAdd);
                }
                return cancelAddCommand;
            }
        }

        public void OnCancelAdd(object parameter)
        {
            this.NewActionMessage = new ActionMessageModel();
        }

        private bool CanExecuteCancelAdd(object parameter)
        {
            return true;
        }

        #endregion
        #endregion
    }
}