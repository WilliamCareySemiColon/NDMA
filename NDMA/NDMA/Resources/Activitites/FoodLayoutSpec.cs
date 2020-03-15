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
        private String[] IngNames, IngAmount;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here FoodLayoutSpecification
            SetContentView(Resource.Layout.FoodLayoutSpecification);
            //getting the food details
            var food = FoodStorage.FoodStorage.DBFood;
            var ingrdients = food.Recipe.Ingredients;
            //setting the food image into the displaying on the page.
            var foodImage = FindViewById<ImageView>(Resource.Id.FoodLayoutPhotoId);
            foodImage.SetImageBitmap(GetImageBitmapFromUrl(food.Recipe.Image));
            //getting the names of the ingrdients themselves
            var count = ingrdients.Count;
            IngNames = new String[count];
            IngAmount = new String[count];
            for(int i = 0; i < count;i++)
            {
                IngNames[i] = ingrdients.ToArray()[i].Text;
                IngAmount[i] = ingrdients.ToArray()[i].Weight.ToString();
            }

            TextView FoodDisplayedName = FindViewById<TextView>(Resource.Id.FoodLayoutItemNameId);
            FoodDisplayedName.Text = food.Recipe.label;

            //connecting to the ui
            Button RetSearch = FindViewById<Button>(Resource.Id.ReturnToSearch);
            RetSearch.Click += delegate { Finish(); };

            Button Log = FindViewById<Button>(Resource.Id.Log);
            Log.Click += delegate {
                //List<String> FoodItems = FoodStorageItems.FoodScheduleStorage.FoodItemNamesStorage;
                //if (FoodItems == null)
                //{
                //    FoodItems = new List<String>();
                //}
                //FoodItems.Add(food.Recipe.label);

                //FoodStorageItems.FoodScheduleStorage.FoodItemNamesStorage = FoodItems;
                Toast.MakeText(Application.Context, "Successfully logged the data", ToastLength.Short).Show();
                Finish();
            };

            /*********************************************************************************************
             * Was attemptng the idea of allowing the capability of modifying the food for home cook basis
             * Using a button to add other ingredients itself. 
             * Incomplete due to time constraints and workload
             *********************************************************************************************/
            //Button AddIngredient = FindViewById<Button>(Resource.Id.AddIngredient);
            //AddIngredient.Click += delegate { ClickItem("sample"); };

            ArrayAdapter listAdapter = new ArrayAdapter(Application.Context, Android.Resource.Layout.SimpleListItem1, IngNames);
            FoodLayoutSpecArrayAdapter FoodListAdapter = new FoodLayoutSpecArrayAdapter(this, IngNames, IngAmount);
            ListView list = FindViewById<ListView>(Resource.Id.NutFoodList);
            list.Adapter = FoodListAdapter;

            //list.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
            //{
            //    ListItemClicked(e.Position, e.Position);
            //};

        }

        private Android.Graphics.Bitmap GetImageBitmapFromUrl(string url)
        {
            Android.Graphics.Bitmap imageBitmap = null;

            using (var webClient = new System.Net.WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = Android.Graphics.BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        //private void ListItemClicked(int position, long id)
        //{
        //    var t = IngNames[position];
        //    Toast.MakeText(Application.Context, t + " " + id, ToastLength.Short).Show();
        //}

        //private void ClickItem(String word)
        //{
        //    Toast.MakeText(Application.Context, "Word: " + word, ToastLength.Short).Show();
        //    Intent AddIngredientActvity = new Intent(this, typeof(AddAdditionalIngredient));
        //    StartActivity(AddIngredientActvity);
        //}
    }
}