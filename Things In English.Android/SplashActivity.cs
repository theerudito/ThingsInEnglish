﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace ThingsInEnglish.Droid
{
    [Activity(Label = "Things In English", Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}