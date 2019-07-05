using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;
using RoyalMail.Core.Models;

namespace RoyalMail.Android.Services
{
    class Swipe2DismissTouchHelperService : ItemTouchHelper.SimpleCallback
    {
        private readonly Context _context;
        private bool _swipeBack;
        public Swipe2DismissTouchHelperService(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public Swipe2DismissTouchHelperService(Context context) : base(0, ItemTouchHelper.Left)
        {
            _context = context;
            _swipeBack = false;
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            return false;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            var holder = (MvxRecyclerViewHolder)viewHolder;
            var item = (Task)holder.DataContext;
            Toast.MakeText(Application.Context, $"swiped", ToastLength.Long).Show();

        }
    }
}