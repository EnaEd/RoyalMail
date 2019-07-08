using MvvmCross;
using MvvmCross.Commands;
using RoyalMail.Core.Interfaces;
using RoyalMail.Core.Models;
using System.Windows.Input;

namespace RoyalMail.Core.ViewModels
{
    public class TaskDetailViewModel : BaseTViewModel<Task>
    {
        #region Variables
        private const int DEFAULT_LENGTH_TASK_NAME = 10;
        private const int DEFAULT_LENGTH_TASK_DETAIL = 210;
        private const string DEFAULT_ALERT_MAX_LENGTH = "task max length";
        private const string TITLE = "Task Detail";
        private string _taskDetail;
        private bool _isComplete;
        private int _idTask;
        private ITaskRepository _taskService;
        #endregion Variables

        #region Constructors
        public TaskDetailViewModel()
        {
            _taskService = Mvx.IoCProvider.Resolve<ITaskRepository>();
        }
        #endregion Constructors

        #region Properties
        public string Title
        {
            get => TITLE;
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
                if (_taskDetail.Length>= DEFAULT_LENGTH_TASK_DETAIL)
                {
                    _messageService.ShowMessageAlet(DEFAULT_ALERT_MAX_LENGTH);
                }
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
        public bool IsClick { get; set; }
        #endregion Properties

        #region Commands
        private MvxCommand _saveTaskCommand;
        public ICommand SaveTaskCommand => new MvxCommand(SaveTask);
        public ICommand GoBackCommand => new MvxCommand(GoBack);
        #endregion Commands

        #region Methods
        private void GoBack()
        {
            _navigationService.Close(this);
        }

        private void SaveTask()
        {
            if (string.IsNullOrEmpty(TaskDetail))
            {
                _navigationService.Close(this);
                return;
            }
            if (IsClick)
            {
                return;
            }
            Task task = new Task
            {
                Id = _idTask,
                IsComlete = this.IsComplete,
                TaskDetail = this.TaskDetail,
                TaskName = this.TaskName
            };
            IsClick = !IsClick;
            _taskService.Save(task);
            _navigationService.Close(this);
        }
        #endregion Methods

        #region Ovverride
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
        #endregion Ovverride
    }
}
