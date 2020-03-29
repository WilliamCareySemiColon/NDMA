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
using NDMA.Resources.JsonLoggedFood;
using Newtonsoft.Json;

namespace NDMA.Resources
{
    [Activity(Label = "FoodLayoutSpec")]
    public class FoodLayoutSpec : Activity
    {
        /**************************************************************************************************************
         * The class that displays the food ingredient contents before they log the food as well as the name and images
         **************************************************************************************************************/
        private String[] IngNames, IngAmount;
        DBFood food;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here FoodLayoutSpecification
            SetContentView(Resource.Layout.FoodLayoutSpecification);
            //getting the food details
            food = FoodStorage.FoodStorage.DBFood;
            var ingrdients = food.Recipe.Ingredients;
            //setting the food image into the displaying on the page.
            var foodImage = FindViewById<ImageView>(Resource.Id.FoodLayoutPhotoId);
            foodImage.SetImageBitmap(GetImageBitmapFromUrl(food.Recipe.Image));
            //getting the names of the ingrdients themselves
            var count = ingrdients.Count;
            IngNames = new String[count];
            IngAmount = new String[count];
            for(int i = 0; i < count;i++) {
                IngNames[i] = ingrdients.ToArray()[i].Text;
                IngAmount[i] = ingrdients.ToArray()[i].Weight.ToString();
            }

            TextView FoodDisplayedName = FindViewById<TextView>(Resource.Id.FoodLayoutItemNameId);
            FoodDisplayedName.Text = food.Recipe.label;

            //connecting to the ui
            Button RetSearch = FindViewById<Button>(Resource.Id.ReturnToSearch);
            RetSearch.Click += delegate {
                SetResult(Result.Canceled);
                Finish(); 
            };

            Button Log = FindViewById<Button>(Resource.Id.Log);
            Log.Click += delegate {
                var pos = FoodStorageItems.FoodScheduleStorage.ScheduleTrack[
                    FoodStorageItems.FoodScheduleStorage.ScheduleID];

                FoodStorageItems.FoodScheduleStorage.FoodItemNamesStorage[pos] = FoodDisplayedName.Text;
                FoodStorageItems.StaticFoodCollection.StoredFood.Add(food);
                
                SetResult(Result.Ok);
                Finish();
            };

            /*********************************************************************************************
             * Was attemptng the idea of allowing the capability of modifying the food for home cook basis
             * Using a button to add other ingredients itself. 
             * Incomplete due to time constraints and workload
             *********************************************************************************************/
            //Button AddIngredient = FindViewById<Button>(Resource.Id.AddIngredient);
            //AddIngredient.Click += delegate { ClickItem("sample"); };

            //ArrayAdapter listAdapter = new ArrayAdapter(Application.Context, Android.Resource.Layout.SimpleListItem1, IngNames);
            FoodLayoutSpecArrayAdapter FoodListAdapter = new FoodLayoutSpecArrayAdapter(this, IngNames, IngAmount);
            ListView list = FindViewById<ListView>(Resource.Id.NutFoodList);
            list.Adapter = FoodListAdapter;
        }

        private Android.Graphics.Bitmap GetImageBitmapFromUrl(string url)
        {
            Android.Graphics.Bitmap imageBitmap = null;

            using (var webClient = new System.Net.WebClient()) {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0) {
                    imageBitmap = Android.Graphics.BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
            return imageBitmap;
        }//end the GetImageBitmapFromUrl
    }
}