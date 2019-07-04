using System;
using Android.App;
using Android.Widget;
using RoyalMail.Android.View;
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
            AlertDialog.Builder alertDialog = new AlertDialog.Builder(TaskListView.Activity);
            alertDialog.SetTitle("Task Details");
            alertDialog.SetMessage($"{message}");
            alertDialog.SetPositiveButton("Ok", delegate
            {
                alertDialog.Dispose();
            });
            alertDialog.Show();
        }
    }
}