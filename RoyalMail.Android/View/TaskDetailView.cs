using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace RoyalMail.Android.View
{
    [MvxActivityPresentation]
    [Activity(Label = "View for TaskDetailViewModel", ScreenOrientation = ScreenOrientation.Portrait)]
    public class TaskDetailView : MvxActivity
    {
        private EditText _editText;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TaskDetailView);
            _editText = FindViewById<EditText>(Resource.Id.inputTask);
            _editText.SetSelection(_editText.Length());
        }
    }
}