using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using RoyalMail.Android.Services;
using RoyalMail.Core;
using RoyalMail.Core.Interfaces;

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