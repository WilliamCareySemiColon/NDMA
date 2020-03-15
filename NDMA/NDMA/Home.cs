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

            //setting the static list for later measurements
            FoodStorageItems.StaticFoodCollection.StoredFood = new List<JsonLoggedFood.DBFood>();
        }

        private void ButtonClicked(string id)
        {

            switch (id)
            {
                case "Log":
                    {
                        Intent LogDietActivity = new Intent(this, typeof(LogDiet));
                        StartActivity(LogDietActivity);
                        break;
                    }
                case "Advise":
                    {
                        Intent AdviseActivity = new Intent(this, typeof(AdvisorMain));
                        StartActivity(AdviseActivity);
                        break;
                    }
                case "View":
                    {
                        Toast.MakeText(Application.Context, 
                            "You have pressed the button with the id of " + id,ToastLength.Short).Show();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }//end switch case

        }
    }
}