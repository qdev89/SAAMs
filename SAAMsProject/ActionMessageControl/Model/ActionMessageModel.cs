using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using SAAMs.Contracts.Enumerations;
using SAAMs.Contracts.Models;

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

        /// <summary>
        /// Used to uniquely identify the SAAM type (and is used to stop the message being displayed again if Do not show again is ticked)
        /// </summary>
        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// If SAAM includes a close button that can be used to dismiss the message (with no further action taken).
        /// </summary>
        public bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        /// <summary>
        /// If true then SAAM includes a Do not show again check-box, which if ticked then a setting is stored in the registry for HKCU and provided ID which will be used to stop this specific SAAM from being displayed again in the future.
        /// </summary>
        public bool CanStopShowing
        {
            get { return _canStopShowing; }
            set { _canStopShowing = value; }
        }

        /// <summary>
        /// This is the text message to be displayed. It also provides a facility for marking the action hyperlink (perhaps <a> </a> in the string)
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        /// <summary>
        /// The action to perform if the hyperlink is clicked. The implementation of this might also cause the SAAM to be closed on successful completion of the action.
        /// </summary>
        public Action ActionMessage { get; set; }

        /// <summary>
        /// Used to indicate the message type (and icon to use)
        /// </summary>
        public MessageType Type
        {
            get { return _type; }
            set { _type = value; }
        }


        #endregion

        public ActionMessageModel()
        {
            // mock data to test
            Id = Guid.NewGuid();
            this.CanClose = true;
            this.Message = "test <a>click here..</a>";
            this.Type = MessageType.Information;
        }
    }
}
