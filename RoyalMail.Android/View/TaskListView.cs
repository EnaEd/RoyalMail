using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace RoyalMail.Android.View
{
    [MvxActivityPresentation]
    [Activity(Label = "View for TaskListViewModel")]
    public class TaskListView : MvxActivity
    {
        public static Activity Activity;
        protected override void OnCreate(Bundle bundle)
        {
            Activity = this;
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TaskListView);
        }
    }
}