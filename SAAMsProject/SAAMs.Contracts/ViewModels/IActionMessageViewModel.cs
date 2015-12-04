using System;
using System.ComponentModel;
using System.Windows.Input;
using SAAMs.Contracts.Models;

namespace SAAMs.Contracts.ViewModels
{
    public interface IActionMessageViewModel
    {
        IActionMessage MessageModel { get; set; }
        bool IsInformation { get; set; }
        bool IsWarning { get; set; }
        ICommand CloseCommand { get; }
        bool CanClose { get; }
        void OnClose(object parameter);
    }
}