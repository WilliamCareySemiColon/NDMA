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
    [Activity(Label = "TestFoodResults")]
    public class TestFoodResults : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.TestFoodResults);

            Button FinishAssessingInfoBtn = FindViewById<Button>(Resource.Id.FinishAssessingInfoBtn);

            FinishAssessingInfoBtn.Click += delegate
            {
                //SetResult(Result.Ok);
                //Finish();

                Toast.MakeText(this, "Pressed", ToastLength.Short).Show();
            };
        }
    }
}