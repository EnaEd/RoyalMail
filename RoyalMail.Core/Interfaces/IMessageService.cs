using System;

namespace RoyalMail.Core.Interfaces
{
    public interface IMessageService
    {
        void Alert(Exception ex);
        void ShowMessage(string message);
        void ShowMessageAlet(string message);
    }
}
