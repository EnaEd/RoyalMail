using System;
using Android.App;
using Android.Widget;
using Plugin.CurrentActivity;
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
            AlertDialog.Builder alertDialog = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity);
            alertDialog.SetTitle("Task Details");
            alertDialog.SetMessage($"{message}");
            alertDialog.SetPositiveButton("Ok", delegate
            {
                alertDialog.Dispose();
            });
            alertDialog.Show();
        }

        public void ShowMessageAlet(string message)
        {
            Toast.MakeText(Application.Context, $"{message}", ToastLength.Long).Show();
        }
    }
}