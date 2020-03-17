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

namespace NDMA.Resources.AdvisorActivities
{
    [Activity(Label = "TestAdviseLog")]
    public class TestAdviseLog : Activity
    {
        private String[] IngNames, IngAmount;
        DBFood food;
        int data;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here FoodLayoutSpecification
            SetContentView(Resource.Layout.FoodLayoutSpecification);

            //getting the food details
            food = FoodStorageForTestData.FoodStorage.DBFood;
            var ingrdients = food.Recipe.Ingredients;
            //setting the food image into the displaying on the page.
            var foodImage = FindViewById<ImageView>(Resource.Id.FoodLayoutPhotoId);
            foodImage.SetImageBitmap(GetImageBitmapFromUrl(food.Recipe.Image));
            //getting the names of the ingrdients themselves
            var count = ingrdients.Count;
            IngNames = new String[count];
            IngAmount = new String[count];
            for (int i = 0; i < count; i++)
            {
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

                SetData();

                if(FoodStorageForTestData.FoodStorage.FoodCollectionItems.Count == FoodStorageForTestData.FoodStorage.MaxItemsAmount + 1)
                {
                    List<DBFood> lisItems = FoodStorageForTestData.FoodStorage.FoodCollectionItems;

                    DBFood[] arrItems = lisItems.ToArray();

                    arrItems[FoodStorageForTestData.FoodStorage.FoodCollectionItemsPos
                        [
                            FoodStorageForTestData.FoodStorage.FoodTrackId
                        ]] = food;

                    FoodStorageForTestData.FoodStorage.FoodCollectionItems = new List<DBFood>();

                    foreach(DBFood food in arrItems)
                    {
                        FoodStorageForTestData.FoodStorage.FoodCollectionItems.Add(food);
                    }
                }
                else
                {
                    AddToListCollection();
                }

                SetResult(Result.Ok);
                Finish();
            };

            ArrayAdapter listAdapter = new ArrayAdapter(Application.Context, Android.Resource.Layout.SimpleListItem1, IngNames);
            FoodLayoutSpecArrayAdapter FoodListAdapter = new FoodLayoutSpecArrayAdapter(this, IngNames, IngAmount);
            ListView list = FindViewById<ListView>(Resource.Id.NutFoodList);
            list.Adapter = FoodListAdapter;

        }

        private void AddToListCollection()
        {
            FoodStorageForTestData.FoodStorage.FoodCollectionItems.Add(food);
            FoodStorageForTestData.FoodStorage.FoodCollectionItemsPos.Add(FoodStorageForTestData.FoodStorage.FoodTrackId, data);
        }

        private void SetData()
        {
            switch(FoodStorageForTestData.FoodStorage.FoodTrackId)
            {
                case "Breakfast":
                    {
                        data = 0;
                        break;
                    }
                case "Lunch":
                    {
                        data = 1;
                        break;
                    }
                case "Dinner":
                    {
                        data = 2;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
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
    }
}