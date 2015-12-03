using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAAMControl.Model
{
    public class BaseViewModel : INotifyPropertyChanged
    {        
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event EventHandler<bool> RequestClose;

        protected virtual void OnRequestClose(bool dialogResult = true)
        {
            if (this.RequestClose != null)
            {
                this.RequestClose(this, dialogResult);
            }
        }

        public event EventHandler RequestDispose;

        protected virtual void OnRequestDispose()
        {
            if (this.RequestDispose != null)
            {
                this.RequestDispose.Invoke(this, null);
            }
        }

        #endregion
    }
}
