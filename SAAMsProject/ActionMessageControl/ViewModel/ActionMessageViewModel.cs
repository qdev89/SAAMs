using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SAAMControl.Model;
using SAAMs.Contracts.Base;
using SAAMs.Contracts.Enumerations;
using SAAMs.Contracts.Models;
using SAAMs.Contracts.ViewModels;

namespace SAAMControl.ViewModel
{
    public class ActionMessageViewModel : BaseViewModel, IActionMessageViewModel
    {
        #region Fields

        private IActionMessage _actionMessageModel;
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

        /// <summary>
        /// Current Action Message object that will be bound to view
        /// </summary>
        public IActionMessage MessageModel
        {
            get { return _actionMessageModel; }
            set
            {
                _actionMessageModel = value;
                NotifyPropertyChanged("MessageModel");
            }
        }


        /// <summary>
        /// If this Action Message is Information type
        /// </summary>
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

        /// <summary>
        /// If this Action Message is Exclamation  type
        /// </summary>
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
            get
            {
                return MessageModel.CanClose;
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
