using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalMail.Core.ViewModels
{
    public abstract class BaseViewModel: MvxViewModel, IMvxViewModel
    {
        protected readonly IMvxNavigationService _navigationService;
        public BaseViewModel()
        {
            _navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
        }
    }
}
