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
    [Activity(Label = "CheckDailyInputForWeeklySample")]
    public class CheckDailyInputForWeeklySample : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CheckDailyInputForWeeklySample);

            Button returnBtn = FindViewById<Button>(Resource.Id.CancelCheck);
            returnBtn.Click += delegate { Finish(); };

            Button breakFastAdd = FindViewById<Button>(Resource.Id.TestAddBreakfastBtn);
            breakFastAdd.Click += delegate { ButtonPressed("breakfast"); };

            Button lunchAddn = FindViewById<Button>(Resource.Id.TestAddLunchBtn);
            lunchAddn.Click += delegate { ButtonPressed("lunch"); };

            Button dinnerAdd = FindViewById<Button>(Resource.Id.TestAddDinnerBtn);
            dinnerAdd.Click += delegate { ButtonPressed("dinner"); };

        }

        private void ButtonPressed(string id)
        {
            switch(id)
            {
                default:
                    {
                        Toast.MakeText(this, id + "  btn pressed", ToastLength.Short).Show();
                        break;
                    }
            }

            Intent TestDataApiSearchIntent = new Intent(this, typeof(TestDataSearchAPI));
            StartActivityForResult(TestDataApiSearchIntent, 4);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if(requestCode == 4 && resultCode == Result.Ok)
            {
                Toast.MakeText(this, "Application was successfully in returning the data", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Application was not successfully in returning the data", ToastLength.Short).Show();
            }
        }
    }
}