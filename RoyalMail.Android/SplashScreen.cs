﻿using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;

namespace RoyalMail.Android
{
    [Activity(
        Label = "RoyalMail.Android"
        , MainLauncher = true
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
             : base(Resource.Layout.SplashScreen)
        {
        }
    }
}