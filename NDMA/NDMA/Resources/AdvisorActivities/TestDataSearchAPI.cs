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

namespace NDMA.Resources.AdvisorActivities
{
    [Activity(Label = "TestDataSearchAPI")]
    public class TestDataSearchAPI : Activity
    {
        //varaibles to make the class work
        private readonly string[] FoodDBApiCreds = new string[] {
            "40bde6df" , "3249bb41449954869d9cae17f11061b1" };

        //nutrition wizard api crediatials
        private readonly string[] NutritionAnalysisApiCreds = new string[] {
            "69c87eb5", "025e6570cf3f613168acc8c6e74c37ae" };

        //Recipe search api
        private readonly string[] RecipeSearchApCreds = new string[] {
            "c570405e", "14793a0482c121e16b365ac4ff89cb1e" };

        //The variable to work with in this class
        HttpClient client;
        HttpResponseMessage response;
        String json;
        Uri uri;
        ParsedFoodCollection food;
        TestCustomSearchedAPIListAdapter listAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SearchForFood);

            EditText search = FindViewById<EditText>(Resource.Id.Search);
            //Button handlers
            Button cancel = FindViewById<Button>(Resource.Id.Cancel);
            Button searchBtn = FindViewById<Button>(Resource.Id.btnSearch);

            cancel.Click += delegate {
                SetResult(Result.Ok);
                Finish();
            };
            searchBtn.Click += delegate { SearchApi(search.Text); };
        }

        private void SearchApi(string message)
        {

            if (message.Length >= 3)
            {
                Toast.MakeText(this,
               "Application is searching for the items with the keyword: " + message,
               ToastLength.Long).Show();

                GetFood(message);
            }
            else
            {
                Toast.MakeText(this,
                "character length needs to be at least 3 charaters: " + message,
                ToastLength.Long).Show();
            }
        }

        private async void GetFood(String keyWord)
        {
            client = new HttpClient();
            int from = 0, to = 10;
            string url = "https://api.edamam.com/search?q=" + keyWord + "&app_id=" + RecipeSearchApCreds[0] + "&app_key="
                + RecipeSearchApCreds[1] + "&from=" + from + "&to=" + to;
            ListView list = FindViewById<ListView>(Resource.Id.SearchFoodList);
            try
            {
                uri = new Uri(url);
                response = await client.GetAsync(uri);
                json = await response.Content.ReadAsStringAsync();

                food = JsonConvert.DeserializeObject<ParsedFoodCollection>(json);
                listAdapter = new TestCustomSearchedAPIListAdapter(this, food);
                list.Adapter = listAdapter;
            }
            catch (Exception e)
            {
                Toast.MakeText(Application.Context, "Error while retreiving the results from the api. Try agina later"
                    + e.Message.ToString(), ToastLength.Long).Show();
            }

            list.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e) {
                ListItemClicked(e.Position, e.Position);
            };
        }

        private void ListItemClicked(int position, long id)
        {
            var t = food.Hits.ToArray()[position];
            //FoodStorage.FoodStorage.food
            FoodStorage.FoodStorage.food = food;
            FoodStorage.FoodStorage.DBFood = t;
            var json = JsonConvert.SerializeObject(food);
            //Toast.MakeText(Application.Context, t.label + " " + id, ToastLength.Short).Show();

            //Intent FoodSpecActvity = new Intent(this, typeof(FoodLayoutSpec));
            //StartActivityForResult(FoodSpecActvity, 1);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {

            if (requestCode == 1)
            {
                if (resultCode == Result.Ok)
                {
                    SetResult(Result.Ok);
                    Finish();
                }
                //if (resultCode == Result.Canceled){
                //}
            }

        }
    }
}