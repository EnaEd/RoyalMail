using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalMail.Core.ViewModel
{
    public class TaskListViewModel : MvxViewModel
    {
        public string HelloString { get; set; }
        public TaskListViewModel()
        {
            HelloString = "Hello MvvmCross";
        }
    }
}
