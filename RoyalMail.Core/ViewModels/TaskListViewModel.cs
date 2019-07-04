using MvvmCross.Commands;
using MvvmCross.ViewModels;
using RoyalMail.Core.Models;
using System.Windows.Input;

namespace RoyalMail.Core.ViewModels
{
    public class TaskListViewModel : BaseViewModel
    {
        private string _helloString;
        
        public TaskListViewModel():base()
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

        private MvxCommand _createTaskCommand;
        public ICommand CreateTaskCommand
        {
            get
            {
                _createTaskCommand = _createTaskCommand ?? new MvxCommand(CreateTask);
                return _createTaskCommand;
            }
        }

        private void CreateTask()
        {
            _navigationService.Navigate<TaskDetailViewModel,Task>(null);
        }
    }
}
