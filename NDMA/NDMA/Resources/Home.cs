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

namespace NDMA.Resources
{
    [Activity(Label = "Home")]
    public class Home : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Home);

            //Setting the text of the views of the appliaction
            TextView carbs = FindViewById<TextView>(Resource.Id.CarbsView);
            carbs.Text = "?%";
        }
    }
}