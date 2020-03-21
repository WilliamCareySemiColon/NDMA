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
using NDMA.Resources.Adapter;

namespace NDMA.Resources.AdvisorActivities
{
    [Activity(Label = "MainAdviseContent")]
    public class MainAdviseContent : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.UserAdviseMainLayout);

            TextView header = FindViewById<TextView>(Resource.Id.HeaderMainAdvise);

            header.Text = "Main advise contents";

            string[] Sm = new string[]
            {
                "Sample",
                "Sample",
                "Sample",
                "Sample",
                 "Sample"
            };

            string[] Sm2 = new string[]
           {
                "Sample",
                "Sample",
                "Sample",
                "Sample",
                 "Sample"
           };

            ListView list = FindViewById<ListView>(Resource.Id.AdviseFoodListView);
            AdvisorAdapter arrayAdapter2 = new AdvisorAdapter(this, Sm, Sm2);
            list.Adapter = arrayAdapter2;

            Button button = FindViewById<Button>(Resource.Id.AdviseReturnBtn);
            button.Click += delegate { Finish(); };
        }
    }
}