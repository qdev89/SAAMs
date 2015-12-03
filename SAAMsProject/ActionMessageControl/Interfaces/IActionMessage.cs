using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAAMControl.Enumerations;

namespace SAAMControl.Interfaces
{
    public interface IActionMessage
    {
        Guid Id { get; set; }
        MessageType Type { get; set; }
        bool CanClose { get; set; }
        bool CanStopShowing { get; set; }
        string Message { get; set; }

        Action ActionMessage { get; set; }
    }
}
