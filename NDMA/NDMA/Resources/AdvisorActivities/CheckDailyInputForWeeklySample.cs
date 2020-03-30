using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;

namespace NDMA.Resources.AdvisorActivities
{
    [Activity(Label = "CheckDailyInputForWeeklySample")]
    public class CheckDailyInputForWeeklySample : Activity
    {
        /***************************************************************************************************************************
         * The activity to take test input from the user and display the advise and the calorie intake of that input - this will be 
         * conducted through searching the api for the food then finding out if they are accurate themselves through the advise and 
         * the chart provided in the aftermath. This activity is getting the input from the user
         **************************************************************************************************************************/
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FoodStorageForTestData.FoodStorage.MaxItemsAmount = 3;
            FoodStorageForTestData.FoodStorage.FoodCollectionItems = new List<JsonLoggedFood.DBFood>();
            FoodStorageForTestData.FoodStorage.FoodCollectionItemsPos = new Dictionary<String, int>();

            // Create your application here
            SetContentView(Resource.Layout.CheckDailyInputForWeeklySample);

            Button returnBtn = FindViewById<Button>(Resource.Id.CancelCheck);
            returnBtn.Click += delegate { Finish(); };

            Button CheckBtn = FindViewById<Button>(Resource.Id.SubmitCheck);
            CheckBtn.Click += delegate { CheckFoodStatus(); };

            Button breakFastAdd = FindViewById<Button>(Resource.Id.TestAddBreakfastBtn);
            breakFastAdd.Click += delegate { ButtonPressed("breakfast"); };

            Button lunchAddn = FindViewById<Button>(Resource.Id.TestAddLunchBtn);
            lunchAddn.Click += delegate { ButtonPressed("lunch"); };

            Button dinnerAdd = FindViewById<Button>(Resource.Id.TestAddDinnerBtn);
            dinnerAdd.Click += delegate { ButtonPressed("dinner"); };
        }

        //the method called by the add buttons within the application for searching the api for the food
        private void ButtonPressed(string id) {
            switch(id)
            {
                case "breakfast":
                    {
                        FoodStorageForTestData.FoodStorage.FoodTrackId = "Breakfast";
                        break;
                    }
                case "lunch":
                    {
                        FoodStorageForTestData.FoodStorage.FoodTrackId = "Lunch";
                        break;
                    }
                case "dinner":
                    {
                        FoodStorageForTestData.FoodStorage.FoodTrackId = "Dinner";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            Intent TestDataApiSearchIntent = new Intent(this, typeof(TestDataSearchAPI));
            StartActivityForResult(TestDataApiSearchIntent, 4);
        }

        //the method to ensure all the fields have been filled before they check the recommendations based of a three main part diet plan
        //breakfast, lunch and dinner
        private void CheckFoodStatus() {
            var bFatsText = FindViewById<TextView>(Resource.Id.InputBreakFastName).Text;
            var lunchText = FindViewById<TextView>(Resource.Id.InputLunchName).Text;
            var dinnrText = FindViewById<TextView>(Resource.Id.InputDinnerName).Text;

            if(String.Equals(bFatsText, "Input Breakfast Name") ||
                String.Equals(lunchText, "Input Lunch Name") ||
                String.Equals(dinnrText, "Input Dinner Name") )
            {
                Toast.MakeText(this, 
                    "Cannot check unless all the fields are fields with the necessary food details", 
                    ToastLength.Short).Show();
            } else {
                Intent intent = new Intent(this, typeof(TestFoodResults));
                StartActivityForResult(intent, 8);
            }
        }
        //the method to find the needed button, disable it and return the needed textview
        private TextView GetTextView()
        {
            switch (FoodStorageForTestData.FoodStorage.FoodTrackId)
            {
                case "Breakfast":
                    {
                        FindViewById<Button>(Resource.Id.TestAddBreakfastBtn).Text = "Add - Disabled";
                        FindViewById<Button>(Resource.Id.TestAddBreakfastBtn).Enabled = false;
                        return FindViewById<TextView>(Resource.Id.InputBreakFastName);
                    }
                case "Lunch":
                    {
                        FindViewById<Button>(Resource.Id.TestAddLunchBtn).Text = "Add - Disabled";
                        FindViewById<Button>(Resource.Id.TestAddLunchBtn).Enabled = false;
                        return FindViewById<TextView>(Resource.Id.InputLunchName);
                    }
                case "Dinner":
                    {
                        FindViewById<Button>(Resource.Id.TestAddDinnerBtn).Text = "Add - Disabled";
                        FindViewById<Button>(Resource.Id.TestAddDinnerBtn).Enabled = false;
                        return FindViewById<TextView>(Resource.Id.InputDinnerName);
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        //the method to get the result back from searchng the api or the food results
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data) {
            if(requestCode == 4 && resultCode == Result.Ok) {
                //Toast.MakeText(this, "Application was successfully in returning the data", ToastLength.Short).Show();
                var textviewSet = GetTextView();
                textviewSet.Text = FoodStorageForTestData.FoodStorage.FoodCollectionItems.ToArray()[
                        FoodStorageForTestData.FoodStorage.FoodCollectionItemsPos[
                            FoodStorageForTestData.FoodStorage.FoodTrackId]
                    ].Recipe.label;
            }
            else if (requestCode == 8 && resultCode == Result.Ok)
            {
                Finish();
            } else {
                Toast.MakeText(this, "Application was not successfully in returning the data", ToastLength.Short).Show();
            }
        }// OnActivityResult end
    }
}