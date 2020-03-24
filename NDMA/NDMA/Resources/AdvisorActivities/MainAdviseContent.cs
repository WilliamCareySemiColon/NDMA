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
using NDMA.Resources.NutritionalAdvisors;
using NDMA.TestStaticData;

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

            TextView adviseText = FindViewById<TextView>(Resource.Id.AdviseParagraph);

            //ListView list = FindViewById<ListView>(Resource.Id.AdviseFoodListView);
            //AdvisorAdapter arrayAdapter2 = new AdvisorAdapter(this, Sm, Sm2);
            //list.Adapter = arrayAdapter2;

            if (FoodStorageItems.StaticFoodCollection.StoredFood.Count != 0)
            {
                var elements = NutrionalAdvisor.GetCaloriesAdvise(FoodStorageItems.StaticFoodCollection.StoredFood, this);
                if (elements.Length == 1)
                {
                    adviseText.Text = elements[0];
                }
                else
                {
                    adviseText.Text = elements[0] + "\n\n Amount Comsumed: " + NutrionalAdvisor.GetStaticCalories() 
                        + "\n Amount recommended on personal status: " + NutrionalAdvisor.GetRecommendedAmount()
                        + "\n\nDescription \n" + elements[1];
                    if (String.Equals(elements[0], "Obesity"))
                    {
                        ImageView image = FindViewById<ImageView>(Resource.Id.AdvisePhoto);
                        image.SetImageBitmap(StaticDataModel.Obesity.GetImage());
                    }
                    else
                    {
                        ImageView image = FindViewById<ImageView>(Resource.Id.AdvisePhoto);
                        image.SetImageBitmap(StaticDataModel.Underweight.GetImage());
                    }
                }
            }
            else
            {
                adviseText.Text = "There is no advise to be made at this current of time as no food has been current logged for the application";
            }

            Button button = FindViewById<Button>(Resource.Id.AdviseReturnBtn);
            button.Click += delegate { Finish(); };
        }
    }
}