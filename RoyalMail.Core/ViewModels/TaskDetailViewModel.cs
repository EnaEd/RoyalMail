using MvvmCross;
using MvvmCross.Commands;
using RoyalMail.Core.Interfaces;
using RoyalMail.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RoyalMail.Core.ViewModels
{
    public class TaskDetailViewModel : BaseTViewModel<Task>
    {
        private const int DEFAULT_LENGTH_TASK_NAME = 10;
        private string _taskDetail;
        private bool _isComplete;
        private int _idTask;
        private ITaskRepository _taskService;
        public TaskDetailViewModel()
        {
            _taskService = Mvx.IoCProvider.Resolve<ITaskRepository>();
        }

        public string TaskName
        {
            get
            {
                string name = string.Empty;
                if (TaskDetail.Length < DEFAULT_LENGTH_TASK_NAME)
                {
                    name = TaskDetail;
                    return name;
                }
                name = $"{TaskDetail.Substring(default(int), DEFAULT_LENGTH_TASK_NAME)}...";
                return name;
            }

        }
        public string TaskDetail
        {
            get => _taskDetail;
            set
            {
                _taskDetail = value;
                RaisePropertyChanged(nameof(TaskName));
                RaisePropertyChanged(nameof(TaskDetail));
            }
        }
        public bool IsComplete
        {
            get => _isComplete;
            set
            {
                _isComplete = value;
                RaisePropertyChanged(nameof(IsComplete));
            }
        }

        private MvxCommand _saveTaskCommand;
        public ICommand SaveTaskCommand => new MvxCommand(SaveTask);

        private void SaveTask()
        {
            if (string.IsNullOrEmpty(TaskDetail))
            {
                _navigationService.Navigate<TaskListViewModel>();
                return;
            }
            Task task = new Task
            {
                Id = _idTask,
                IsComlete = this.IsComplete,
                TaskDetail = this.TaskDetail,
                TaskName = this.TaskName
            };
            _taskService.Save(task);
            _navigationService.Navigate<TaskListViewModel>();
        }

        public override void Prepare(Task parameter)
        {
            if (parameter is null)
            {
                return;
            }

            TaskDetail = parameter.TaskDetail;
            IsComplete = parameter.IsComlete;
            _idTask = parameter.Id;
        }
    }
}
