using MvvmCross.IoC;
using MvvmCross.ViewModels;
using RoyalMail.Core.ViewModel;

namespace RoyalMail.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterAppStart<TaskListViewModel>();
        }
    }
}
