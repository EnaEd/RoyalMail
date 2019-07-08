using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using Android.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;
using RoyalMail.Core.Models;
using RoyalMail.Core.ViewModels;

namespace RoyalMail.Android.Services
{
    class Swipe2DismissTouchHelperService : ItemTouchHelper.SimpleCallback
    {
        private readonly Context _context;
        private TaskListViewModel _viewModel;
        public Swipe2DismissTouchHelperService(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public Swipe2DismissTouchHelperService(Context context,TaskListViewModel viewModel) : base(0, ItemTouchHelper.Left)
        {
            _context = context;
            _viewModel = viewModel;
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            return false;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            var holder = (MvxRecyclerViewHolder)viewHolder;
            Task item = (Task)holder.DataContext;
            _viewModel.CompleteTask(item);
            Toast.MakeText(Application.Context, $"complete", ToastLength.Long).Show();

        }
    }
}