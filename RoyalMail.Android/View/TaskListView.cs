using Android.App;
using Android.OS;
using Android.Support.V7.Widget.Helper;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using Plugin.CurrentActivity;
using RoyalMail.Android.Services;
using RoyalMail.Core.ViewModels;

namespace RoyalMail.Android.View
{
    [MvxActivityPresentation]
    [Activity(Label = "View for TaskListViewModel")]
    public class TaskListView : MvxActivity<TaskListViewModel>
    {
        private Refractored.Fab.FloatingActionButton _fab;
        private ItemTouchHelper _itemTouchHelper;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            CrossCurrentActivity.Current.Init(this, bundle);
            SetContentView(Resource.Layout.TaskListView);
            var listView = FindViewById<MvxRecyclerView>(Android.Resource.Id.list_item);
            _itemTouchHelper = new ItemTouchHelper(new Swipe2DismissTouchHelperService(this));
            _itemTouchHelper.AttachToRecyclerView(listView);
            _fab = FindViewById<Refractored.Fab.FloatingActionButton>(Resource.Id.fab);
            _fab.AttachToRecyclerView(listView);

            _fab.Click += CrateNewTask;

        }

        private void CrateNewTask(object sender, System.EventArgs e)
        {
            ViewModel.CreateTask();
        }
    }
}