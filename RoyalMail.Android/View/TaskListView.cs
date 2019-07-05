using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using Plugin.CurrentActivity;
using RoyalMail.Core.ViewModels;

namespace RoyalMail.Android.View
{
    [MvxActivityPresentation]
    [Activity(Label = "View for TaskListViewModel")]
    public class TaskListView : MvxActivity<TaskListViewModel>
    {
        private Refractored.Fab.FloatingActionButton _fab;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            CrossCurrentActivity.Current.Init(this, bundle);
            SetContentView(Resource.Layout.TaskListView);
            var listView = FindViewById<MvvmCross.Platforms.Android.Binding.Views.MvxListView>(Android.Resource.Id.list_item);
            _fab = FindViewById<Refractored.Fab.FloatingActionButton>(Resource.Id.fab);
            _fab.AttachToListView(listView);

            _fab.Click += CrateNewTask;

        }

        private void CrateNewTask(object sender, System.EventArgs e)
        {
            ViewModel.CreateTask();
        }
    }
}