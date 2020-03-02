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
    [Activity(Label = "DailyStatusGraph")]
    public class DailyStatusGraph : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.GraphLayout);

            Button button = FindViewById<Button>(Resource.Id.ReturnToAdviseSearchBtn);
            button.Click += delegate { Finish(); };

        }
    }
}