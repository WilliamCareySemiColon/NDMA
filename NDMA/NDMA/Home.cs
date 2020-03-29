using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using NDMA.Resources.AdvisorActivities;

namespace NDMA.Resources
{
    /******************************************************************************************************************************
     * The home page of the application that connects all the functionality of the system together - the logging aspect, the advise
     * system and the view details account system. The view account details was the only aspect that could not be implemented within
     * the given timefame
     *****************************************************************************************************************************/
    [Activity(Label = "Home")]
    public class Home : Activity {
        protected override void OnCreate(Bundle savedInstanceState){
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Home);
            //Button Connections
            Button vistAdvisorSystem = FindViewById<Button>(Resource.Id.AdvisorSystem);
            Button LogDailyDiet = FindViewById<Button>(Resource.Id.LogDiet);

            /*********************************************************************
             * The viewAccount button - the intention is to include the 
             * functionality to allow the user to get access to their user details
             ********************************************************************/
            //Button viewAccount = FindViewById<Button>(Resource.Id.ViewAccount);
            //viewAccount.Click += delegate { ButtonClicked("View"); };

            vistAdvisorSystem.Click += delegate { ButtonClicked("Advise"); };
            LogDailyDiet.Click += delegate { ButtonClicked("Log"); };

            //setting the static list for later measurements
            FoodStorageItems.StaticFoodCollection.StoredFood = new List<JsonLoggedFood.DBFood>();
        }

        //the button clicked method that is used by every button on the page
        private void ButtonClicked(string id) {
            switch (id) {
                //Switching to the logging funtionality of the application
                case "Log":
                    {
                        Intent LogDietActivity = new Intent(this, typeof(LogDiet));
                        StartActivity(LogDietActivity);
                        break;
                    }
                //Switching to the advise funtionality of the application
                case "Advise":
                    {
                        Intent AdviseActivity = new Intent(this, typeof(AdvisorMain));
                        StartActivity(AdviseActivity);
                        break;
                    }
                //The view button - the idea was to switch to the view user details 
                case "View":
                    {
                        Toast.MakeText(Application.Context, "You have pressed the button with the id of " + id,ToastLength.Short).Show();
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