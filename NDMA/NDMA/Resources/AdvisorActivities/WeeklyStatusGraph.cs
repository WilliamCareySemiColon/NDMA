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
        /****************************************************************************************************************
         * The activity to display the daily graph trends for the user - due to timing contraints, this activity is not 
         * being used
         ****************************************************************************************************************/
    [Activity(Label = "WeeklyStatusGraph")]
    public class WeeklyStatusGraph : Activity
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