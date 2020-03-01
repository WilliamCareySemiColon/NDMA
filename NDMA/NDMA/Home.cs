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
using NDMA.Resources.AdvisorActivities;

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
            //Button Connections
            Button viewAccount = FindViewById<Button>(Resource.Id.ViewAccount);
            Button vistAdvisorSystem = FindViewById<Button>(Resource.Id.AdvisorSystem);
            Button LogDailyDiet = FindViewById<Button>(Resource.Id.LogDiet);

            viewAccount.Click += delegate { ButtonClicked("View"); };

            vistAdvisorSystem.Click += delegate { ButtonClicked("Advise"); };

            LogDailyDiet.Click += delegate { ButtonClicked("Log"); };
        }

        private void ButtonClicked(string id)
        {
            Toast.MakeText(Application.Context, "Ypu have pressed the button with the id of " + id,
                ToastLength.Short).Show();

            if (string.Equals(id, "Log", StringComparison.CurrentCulture))
            {
                Intent LogDietActivity = new Intent(this, typeof(LogDiet));
                StartActivity(LogDietActivity);
            }

            if (string.Equals(id, "Advise", StringComparison.CurrentCulture))
            {
                Intent AdviseActivity = new Intent(this, typeof(AdvisorMain));
                StartActivity(AdviseActivity);
            }
        }
    }
}