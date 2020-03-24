using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NDMA.Resources.Adapter;
using NDMA.TestStaticData;

namespace NDMA.Resources.AdvisorActivities
{
    [Activity(Label = "Underdone")]
    public class Underdone : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.UserAdviseMainLayout);

            TextView header = FindViewById<TextView>(Resource.Id.HeaderMainAdvise);

            header.Text = "Underdone advise contents";

            var caloriesItems = NutritionalAdvisors.NutrionalAdvisor.GetCaloriesAdvise(FoodStorageItems.StaticFoodCollection.StoredFood, this);

            if (caloriesItems.Length == 3)
            {
                //var image = Convert.FromBase64String(caloriesItems[2]);
                //var imageBitmap = Android.Graphics.BitmapFactory.DecodeByteArray(image, 0, image.Length);

                var image = String.Equals(caloriesItems[0], "Obesity") ? StaticDataModel.Obesity.GetImage() : StaticDataModel.Underweight.GetImage();

            };

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

        public Bitmap convert(String base64Str) throws IllegalArgumentException
        {
             byte[] decodedBytes = Base64.decode(
                 base64Str.substring(base64Str.indexOf(",") + 1),
                 Base64.DEFAULT);
        return BitmapFactory.decodeByteArray(decodedBytes, 0, decodedBytes.length);
    }
}
}