using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    [Activity(Label = "SearchForFood")]
    public class SearchForFoodFromApi : Activity
    {
        //food api creditails to read from
        private readonly string[] FoodDBApiCreds = new string[] {
            "40bde6df" , "3249bb41449954869d9cae17f11061b1" };

        //nutrition wizard api crediatials
        private readonly string[] NutritionAnalysisApiCreds = new string[] {
            "69c87eb5", "025e6570cf3f613168acc8c6e74c37ae" };

        //Recipe search api
        private readonly string[] RecipeSearchApCreds = new string[] {
            "c570405e", "14793a0482c121e16b365ac4ff89cb1e" };

        string[] ListToDisplayTemp;

        //The variable to work with in this class
        HttpClient client;
        HttpResponseMessage response;
        String json;
        Uri uri;
        ParsedFoodCollection food;
        CustomSearchedAPIListAdapter listAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SearchForFood);

            EditText search = FindViewById<EditText>(Resource.Id.Search);

            //Button handlers
            Button cancel = FindViewById<Button>(Resource.Id.Cancel);
            Button searchBtn = FindViewById<Button>(Resource.Id.btnSearch);

            cancel.Click += delegate { Finish(); };
            searchBtn.Click += delegate { SearchApi(search.Text); };

        }

        private void SearchApi(string message)
        {
            if (message.Length >= 3)
                GetFood(message);
        }

        private async void GetFood(String keyWord)
        {
            client = new HttpClient();
            int from = 0, to = 10;
            //string url = $"https://api.edamam.com/api/food-database/parser?ingr={keyWord}&app_id={FoodDBApiCreds[0]}&app_key={FoodDBApiCreds[1]}";
            string url = "https://api.edamam.com/search?q=" + keyWord + "&app_id=" + RecipeSearchApCreds[0] + "&app_key="
                + RecipeSearchApCreds[1] + "&from=" + from + "&to=" + to;
            ListView list = FindViewById<ListView>(Resource.Id.SearchFoodList);
            try
            {
                uri = new Uri(url);
                response = await client.GetAsync(uri);
                json = await response.Content.ReadAsStringAsync();
                food = JsonConvert.DeserializeObject<ParsedFoodCollection>(json);

                Toast.MakeText(Application.Context, food.Q + " " + food.Count + " " + food.Hits.ToArray()[1].Recipe.label
                    , ToastLength.Short).Show();

                listAdapter = new CustomSearchedAPIListAdapter(this, food);
                list.Adapter = listAdapter;
            }
            catch (Exception e)
            {
                Toast.MakeText(Application.Context,
                    "Error while retreiving the results from the api. Try agina later"
                    + e.Message.ToString(), ToastLength.Long).Show();
            }

            //{ keyWord};
            list.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
            {
                //ListItemClicked(list, new View(Application.Context), e.Position, e.Position);
                ListItemClicked(e.Position, e.Position);
                //, list.SelectedItemId);

            };
        }

        //private void ListItemClicked(ListView l, View v, int position, long id)
        //{
        //    var t = information[position];
        //    Toast.MakeText(Application.Context, t + " " + id, ToastLength.Short).Show();
        //}

        private void ListItemClicked(int position, long id)
        {
            var t = ListToDisplayTemp[position];
            Toast.MakeText(Application.Context, t + " " + id, ToastLength.Short).Show();

            Intent FoodSpecActvity = new Intent(this, typeof(FoodLayoutSpec));
            StartActivity(FoodSpecActvity);
            // Finish();
        }

    }
}