using MvvmCross;
using MvvmCross.Commands;
using RoyalMail.Core.Interfaces;
using RoyalMail.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace RoyalMail.Core.ViewModels
{
    public class TaskListViewModel : BaseViewModel
    {
        #region Variables
        private const string TITLE = "Task Detail";
        private string _taskName;
        private string _taskDetail;
        private bool _isComplite;
        private ITaskRepository _taskService;
        private List<Task> _tasks;
        #endregion Variables

        #region Constructors
        public TaskListViewModel() : base()
        {
            _taskService = Mvx.IoCProvider.Resolve<ITaskRepository>();
            InitData();
        }
        #endregion Constructors

        #region Properties
        public string Title
        {
            get => TITLE;
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
        public string TaskDetailCard
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
        public bool IsClick { get; set; }
        #endregion Properties

        #region Commands
        public ICommand ShoTaskDetailCommand => new MvxCommand<Task>(ShowtaskDetail);

        public ICommand EditTaskCommand => new MvxCommand<Task>(EditTask);

        public ICommand CreateTaskCommand => new MvxCommand(CreateTask);
        #endregion Commands

        #region Methods
        private void InitData()
        {
            Tasks = _taskService.GetAll().Where(x => x.IsComlete == default(bool)).ToList();
            IsClick = false;
        }
        public void CreateTask()
        {
            if (!IsClick)
            {
                _navigationService.Navigate<TaskDetailViewModel, Task>(null);
                IsClick = !IsClick;
            }
        }
        public void CompleteTask(Task task)
        {
            task.IsComlete = true;
            _taskService.Save(task);
            InitData();
        }
        private void EditTask(Task obj)
        {
            _navigationService.Navigate<TaskDetailViewModel, Task>(obj);
        }
        private void ShowtaskDetail(Task obj)
        {
            InvokeOnMainThread(() => { _messageService.ShowMessage($"{obj.TaskDetail}"); });
        }
        #endregion Methods

        #region Ovverride
        public override void ViewAppearing()
        {
            InitData();
        }
        #endregion Ovverride
    }
}
