using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using RoyalMail.Core.Interfaces;
using RoyalMail.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace RoyalMail.Core.ViewModels
{
    public class TaskListViewModel : BaseViewModel
    {

        private string _taskName;
        private string _taskDetail;
        private bool _isComplite;
        private ITaskRepository _taskService;
        private List<Task> _tasks;
        public TaskListViewModel():base()
        {
            _taskService = Mvx.IoCProvider.Resolve<ITaskRepository>();
            InitData();
        }

        
        public string TaskName
        {
            get => _taskName;
            set
            {
                _taskName = value;
                RaisePropertyChanged(nameof(TaskName));
            }
        }
        public string TaskDetail
        {
            get => _taskDetail;
            set
            {
                _taskDetail = value;
                RaisePropertyChanged(nameof(TaskDetail));
            }
        }
        public bool IsComplite
        {
            get => _isComplite;
            set
            {
                _isComplite = value;
                RaisePropertyChanged(nameof(IsComplite));
            }
        }
        public List<Task> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                RaisePropertyChanged(nameof(Tasks));
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

        private void InitData()
        {
            if (Tasks is null)
            {
                Tasks = _taskService.GetAll().Where(x => x.IsComlete == default(bool)).ToList();
            }
        }

        private void CreateTask()
        {
            _navigationService.Navigate<TaskDetailViewModel,Task>(null);
        }
    }
}
