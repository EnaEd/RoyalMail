using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using RoyalMail.Core.Interfaces;

namespace RoyalMail.Core.ViewModels
{
    public abstract class BaseViewModel: MvxViewModel, IMvxViewModel
    {
        #region Variables
        protected readonly IMvxNavigationService _navigationService;
        protected IMessageService _messageService;
        #endregion Variables

        #region Constructors
        public BaseViewModel()
        {
            _navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            _messageService = Mvx.IoCProvider.Resolve<IMessageService>();
        }
        #endregion Constructors
    }
}
