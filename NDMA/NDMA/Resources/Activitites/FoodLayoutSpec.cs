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
using NDMA.Resources.JsonLoggedFood;
using Newtonsoft.Json;

namespace NDMA.Resources
{
    [Activity(Label = "FoodLayoutSpec")]
    public class FoodLayoutSpec : Activity
    {
        private readonly string[] SampleIngreList =
            new string[] { "Item", "Item", "Item", "Item", "Item", "Item" };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here FoodLayoutSpecification
            SetContentView(Resource.Layout.FoodLayoutSpecification);

            Button RetSearch = FindViewById<Button>(Resource.Id.ReturnToSearch);
            RetSearch.Click += delegate { Finish(); };

            Button Log = FindViewById<Button>(Resource.Id.Log);
            Log.Click += delegate { 
                Toast.MakeText(Application.Context, "Successfully logged the data", ToastLength.Short).Show();
                Finish();
            };

            //Button AddIngredient = FindViewById<Button>(Resource.Id.AddIngredient);
            //AddIngredient.Click += delegate { ClickItem("sample"); };

            ArrayAdapter listAdapter = new ArrayAdapter(Application.Context, Android.Resource.Layout.SimpleListItem1, SampleIngreList);
            ListView list = FindViewById<ListView>(Resource.Id.NutFoodList);
            list.Adapter = listAdapter;

            list.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
            {
                //ListItemClicked(list, new View(Application.Context), e.Position, e.Position);
                ListItemClicked(e.Position, e.Position);
                //, list.SelectedItemId);

            };

            var food = FoodStorage.FoodStorage.DBFood;

            Toast.MakeText(this, "Food item" + FoodStorage.FoodStorage.DBFood.Recipe.label, ToastLength.Short).Show();

            //Toast.MakeText(this, "Food item" + food.Recipe.label,ToastLength.Short);

            //var text = Intent.GetStringExtra("FoodHitsSpec");
            //var pos = Intent.GetIntExtra("Postion",0);

            //var FoodItem = JsonConvert.DeserializeObject<ParsedFoodCollection>(text);

            //Toast.MakeText(this,"Sample string: " + 
            //    FoodItem.Hits.ToArray()[pos].Recipe.label, ToastLength.Short);
        }

        //private void ListItemClicked(ListView l, View v, int position, long id)
        //{
        //    var t = information[position];
        //    Toast.MakeText(Application.Context, t + " " + id, ToastLength.Short).Show();
        //}

        private void ListItemClicked(int position, long id)
        {
            var t = SampleIngreList[position];
            Toast.MakeText(Application.Context, t + " " + id, ToastLength.Short).Show();
        }

        private void ClickItem(String word)
        {
            Toast.MakeText(Application.Context, "Word: " + word, ToastLength.Short).Show();
            Intent AddIngredientActvity = new Intent(this, typeof(AddAdditionalIngredient));
            StartActivity(AddIngredientActvity);
        }
    }
}