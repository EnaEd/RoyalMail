using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalMail.Core.ViewModels
{
    public class TaskListViewModel : MvxViewModel
    {
        private string _helloString;
        
        public TaskListViewModel()
        {
            HelloString = "Hello MvvmCross";
        }

        public string HelloString
        {
            get => _helloString;

            set
            {
                _helloString = value;
                RaisePropertyChanged(nameof(HelloString));
            }
        }
    }
}
