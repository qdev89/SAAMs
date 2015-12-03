using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using SAAMControl.Enumerations;
using SAAMControl.Interfaces;

namespace SAAMControl.Model
{
    public class ActionMessageModel : IActionMessage
    {
        #region Fields
        private Guid _id;
        private MessageType _type;
        private bool _canClose;
        private bool _canStopShowing;
        private string _message;
        #endregion

        #region Properties
        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        public bool CanStopShowing
        {
            get { return _canStopShowing; }
            set { _canStopShowing = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public Action ActionMessage { get; set; }

        public MessageType Type
        {
            get { return _type; }
            set { _type = value; }
        }


        #endregion

        public ActionMessageModel()
        {
            Id = Guid.NewGuid();
            this.CanClose = true;
            this.Message = "test <a>click here..</a>";
        }
    }
}
