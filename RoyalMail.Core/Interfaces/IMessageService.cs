using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalMail.Core.Interfaces
{
    public interface IMessageService
    {
        void Alert(Exception ex);
        void ShowMessage(string message);
    }
}
