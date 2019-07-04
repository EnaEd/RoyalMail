using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalMail.Core.ViewModels
{
    public abstract class BaseTViewModel<TParam> : BaseViewModel, IMvxViewModel<TParam>
    {
        public abstract void Prepare(TParam parameter);
    }
}
