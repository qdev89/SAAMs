using System;
using SAAMs.Contracts.Enumerations;

namespace SAAMs.Contracts.Models
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
