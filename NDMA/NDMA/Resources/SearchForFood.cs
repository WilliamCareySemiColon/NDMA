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
using NDMA.Resources.JsonLoggedFood;
using Newtonsoft.Json;

namespace NDMA.Resources
{
    [Activity(Label = "SearchForFood")]
    public class SearchForFood : Activity
    {
        //food api creditails to read from
        private readonly string[] FoodDBApiCreds = new string[]
        {
            "40bde6df" ,
            "3249bb41449954869d9cae17f11061b1"
        };
        //nutrition wizard api crediatials
        private readonly string[] NutritionAnalysisApiCreds = new string[]
        {
            "69c87eb5",
            "025e6570cf3f613168acc8c6e74c37ae"
        };

        //Recipe search api
        private readonly string[] RecipeSearchApCreds = new string[]
        {
            "c570405e",
            "14793a0482c121e16b365ac4ff89cb1e"
        };

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
            searchBtn.Click += delegate
            {
                TextChanged(search.Text);
            };

        }

        private void TextChanged(string message)
        {
            //TextView text = FindViewById<TextView>(Resource.Id.SampleTest);

            if (message.Length >= 3)
            {
                GetFood(message);
            }
        }

        private async void GetFood(String keyWord)
        {
            HttpClient client = new HttpClient();
            //string url = $"https://api.edamam.com/api/food-database/parser?ingr={keyWord}&app_id={FoodDBApiCreds[0]}&app_key={FoodDBApiCreds[1]}";
            string url = $"https://api.edamam.com/search?q={keyWord}n&app_id={RecipeSearchApCreds[0]}&app_key={RecipeSearchApCreds[1]}";//&from=0&to=3&calories=591-722&health=alcohol-free"
            HttpResponseMessage response;
            String json;
            Uri uri;
            ParsedFoodCollection food;
            try
            {
                uri = new Uri(url);
                response = await client.GetAsync(uri);
                json = await response.Content.ReadAsStringAsync();
                //Toast.MakeText(Application.Context, json.Length, ToastLength.Long).Show();
                food = JsonConvert.DeserializeObject<ParsedFoodCollection>(json);

                Toast.MakeText(Application.Context, food.Q
                    , ToastLength.Short).Show();

                //Toast.MakeText(Application.Context, food.Parsed[0].food.Label
                //    , ToastLength.Short).Show();

                //Console.WriteLine(food.Text);
            }
            catch (Exception e)
            {
                Toast.MakeText(Application.Context, "Exception " + e.Message.ToString(), ToastLength.Long).Show();
            }
            //var response = await client.GetAsync(url).ConfigureAwait(false);


            //Toast.MakeText(Application.Context, "Before the read items as string ", ToastLength.Long).Show();
            //var json = await response.Content.ReadAsStringAsync();

            //Toast.MakeText(Application.Context,json.Length, ToastLength.Long).Show();
        }



    }
}