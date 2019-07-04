using System;
using Android.App;
using Android.Widget;
using RoyalMail.Core.Interfaces;

namespace RoyalMail.Android.Services
{
    public class MessageService : IMessageService
    {
        public void Alert(Exception ex)
        {
            Toast.MakeText(Application.Context, $"{ex.Message}\n{ex.StackTrace}", ToastLength.Long).Show();
        }

        public void ShowMessage(string message)
        {
            Toast.MakeText(Application.Context, $"{message}", ToastLength.Short).Show();
        }
    }
}