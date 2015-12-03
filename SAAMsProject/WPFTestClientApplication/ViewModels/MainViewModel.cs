using System.Collections.ObjectModel;
using System.Windows.Input;
using SAAMControl.Model;

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
        public ActionMessageModel SelectedActionMessage
        {
            get { return _selectedActionMessage; }
            set
            {
                _selectedActionMessage = value;
                NotifyPropertyChanged("SelectedActionMessage");
            }
        }
        public ActionMessageModel NewActionMessage
        {
            get { return _newActionMessage; }
            set
            {
                _newActionMessage = value;
                NotifyPropertyChanged("NewActionMessage");
            }
        }

        public ObservableCollection<ActionMessageModel> ActionMessageList
        {
            get { return _actionMessageList; }
            set
            {
                _actionMessageList = value;
                NotifyPropertyChanged("ActionMessageList");
            }
        }


        #region Commands
        #region ShowCommand Command
        private RelayCommand _showCommand;
        public ICommand ShowCommand
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
            SAAMControl.ActionmessageControl control = new SAAMControl.ActionmessageControl();
            control.Init(this.SelectedActionMessage);
            control.Show();
        }

        private bool CanExecuteShow(object parameter)
        {
            return this.SelectedActionMessage != null;
        }

        #endregion
        #region AddCommand Command
        private RelayCommand _addCommand;
        public ICommand AddCommand
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
        }

        private bool CanExecuteAdd(object parameter)
        {
            return NewActionMessage != null;
        }

        #endregion

        #region Cancel Command
        private RelayCommand cancelAddCommand;
        public ICommand CancelAddCommand
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