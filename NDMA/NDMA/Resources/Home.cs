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

<<<<<<< HEAD
            Button advisorSystem = FindViewById<Button>(Resource.Id.AdvisorSystem);
            Button viewAccountDetails = FindViewById<Button>(Resource.Id.ViewAccountDetails);
            Button logDailyDiet = FindViewById<Button>(Resource.Id.LogDailyDiet);

            advisorSystem.Click += delegate
            {
                ButtonClicked("Advise");
            };

            viewAccountDetails.Click += delegate
            {
                ButtonClicked("ViewAccount");
            };

            logDailyDiet.Click += delegate
            {
                ButtonClicked("LogDiet");
            };

        }

        private void ButtonClicked(string id)
        {
            Toast.MakeText(Application.Context, "You have pressed the " + id + " Button", ToastLength.Short).Show();

            if(string.Equals(id, "LogDiet"))
            {
                Intent LogDietActivity = new Intent(this, typeof(LogDiet));
                StartActivity(LogDietActivity);
            }
=======
            //Setting the text of the views of the appliaction
            TextView carbs = FindViewById<TextView>(Resource.Id.CarbsView);
            carbs.Text = "?%";
>>>>>>> 839ee71dad96a33133b8a982bf0d00413979a8c6
        }
    }
}