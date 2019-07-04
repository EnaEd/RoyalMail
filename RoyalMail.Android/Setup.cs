using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;
using RoyalMail.Android.Services;
using RoyalMail.Core.Interfaces;

namespace RoyalMail.Android
{
    public class Setup : MvxAndroidSetup
    {
        protected override IMvxApplication CreateApp()
        {
            Mvx.IoCProvider.RegisterSingleton<ITaskRepository>(() => new TaskService());
            return new Core.App();
        }
    }
}