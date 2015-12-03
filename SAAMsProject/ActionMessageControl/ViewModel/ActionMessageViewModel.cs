using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SAAMControl.Model;

namespace SAAMControl.ViewModel
{
    public class ActionMessageViewModel : BaseViewModel
    {
        #region Fields

        private ActionMessageModel _actionMessageModel;
        private bool _isInformation;
        private bool _isWarning;
        #endregion

        #region Contructor

        public ActionMessageViewModel()
        {
            
        }
        #endregion

        #region Properties
        public ActionMessageModel MessageModel
        {
            get { return _actionMessageModel; }
            set
            {
                _actionMessageModel = value;
                NotifyPropertyChanged("MessageModel");
            }
        }

        public bool IsInformation
        {
            get { return _isInformation; }
            set
            {
                _isInformation = value;
                NotifyPropertyChanged("IsInformation");
            }
        }

        public bool IsWarning
        {
            get { return _isWarning; }
            set
            {
                _isWarning = value;
                NotifyPropertyChanged("IsWarning");
            }
        }
        #endregion

        #region Command
        private ICommand closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                {
                    closeCommand = new RelayCommand(OnClose, CanExecuteClose);
                }
                return closeCommand;
            }
        }

        public void OnClose(object parameter)
        {
            base.OnRequestClose(false);
        }

        private bool CanExecuteClose(object parameter)
        {
            return true;
        }
        #endregion
    }
}
