using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NDMA.Resources.AdvisorActivities
{
    [Activity(Label = "CheckDailyInputForWeeklySample")]
    public class CheckDailyInputForWeeklySample : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CheckDailyInputForWeeklySample);

            Button returnBtn = FindViewById<Button>(Resource.Id.CancelCheck);
            returnBtn.Click += delegate { Finish(); };

        }
    }
}