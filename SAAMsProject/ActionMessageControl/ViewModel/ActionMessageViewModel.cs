using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SAAMControl.Enumerations;
using SAAMControl.Model;

namespace SAAMControl.ViewModel
{
    public class ActionMessageViewModel : BaseViewModel
    {
        #region Fields

        private ActionMessageModel _actionMessageModel;
        private bool _isInformation;
        private bool _isWarning;
        private bool _canClose;
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
            get
            {
                if (MessageModel.Type == MessageType.Information)
                {
                    return true;
                }
                return false;
            }
            set
            {
                _isInformation = value;
                NotifyPropertyChanged("IsInformation");
            }
        }

        public bool IsWarning
        {
            get
            {
                if (MessageModel.Type == MessageType.Exclamation)
                {
                    return true;
                }
                return false;
            }
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

        public bool CanClose
        {
            get { return MessageModel.CanClose; }            
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
