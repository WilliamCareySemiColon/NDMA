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
    /**************************************************************************************************************************
     * The logging part that queries the Ednaman recipe API to get the food result to return as part of the application. This 
     * is called from the logDiet. Within the listview, the name and images of the application are displayed
     *************************************************************************************************************************/
    [Activity(Label = "SearchForFood")]
    public class SearchForFoodFromApi : Activity
    {
        //The application user id for the api and the password for the usage of the apis for the static strings

        //food api creditails to read from
        //private readonly string[] FoodDBApiCreds = new string[] {
        //    "40bde6df" , "3249bb41449954869d9cae17f11061b1" };

        ////nutrition wizard api crediatials
        //private readonly string[] NutritionAnalysisApiCreds = new string[] {
        //    "69c87eb5", "025e6570cf3f613168acc8c6e74c37ae" };

        //Recipe search api
        private readonly string[] RecipeSearchApCreds = new string[] {
            "c570405e", "14793a0482c121e16b365ac4ff89cb1e" };

        //The variable to work with in this class for connection to the api itself
        //Have moved the code to sepatrate class in attempt to decouple the application regarding the http connection
        HttpClient client;
        HttpResponseMessage response;
        String json;
        Uri uri;
        public ParsedFoodCollection food;
        CustomSearchedAPIListAdapter listAdapter;

        //variables to capture the items
        public EditText search;
        Button cancel;
        public Button searchBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SearchForFood);

            EditText search = FindViewById<EditText>(Resource.Id.Search);
            //Button handlers
            cancel = FindViewById<Button>(Resource.Id.Cancel);
            searchBtn = FindViewById<Button>(Resource.Id.btnSearch);

            cancel.Click += delegate {
                SetResult(Result.Canceled);
                Finish(); 
            };
            searchBtn.Click += delegate { SearchApi(search.Text); };
        }

        //the method to call the asyc method to search the api for the approiate food itself
        public void SearchApi(string message){
            if (message.Length >= 2) {
                //Toast.MakeText(this, "Application is searching for the items with the keyword: " + message,
                //    ToastLength.Short).Show();
                GetFood(message);
            } else {
                Toast.MakeText(this, "character length needs to be at least 3 charaters: " + message,ToastLength.Long).Show();
            }
        }

        //the querying of the api for the recipe on the internet
        private async void GetFood(String keyWord) {
            client = new HttpClient();
            int from = 0, to = 10;
            string url = "https://api.edamam.com/search?q=" + keyWord + "&app_id=" + RecipeSearchApCreds[0] + "&app_key="
                + RecipeSearchApCreds[1] + "&from=" + from + "&to=" + to;
            ListView list = FindViewById<ListView>(Resource.Id.SearchFoodList);
            try {
                uri = new Uri(url);
                response = await client.GetAsync(uri);
                json = await response.Content.ReadAsStringAsync();

                Toast.MakeText(this, json, ToastLength.Long).Show();

                food = JsonConvert.DeserializeObject<ParsedFoodCollection>(json);
                if (food.Hits.Count == 0)
                {
                    AlertDialog.Builder builder = new AlertDialog.Builder(this);
                    builder.SetTitle("Error - Food not found")
                        .SetMessage("There was no food that macthes your Query")
                        .SetPositiveButton("OK", delegate 
                        {
                            void Click()
                            {
                                return;
                            }
                        });

                    builder.Show();

                } else{
                    listAdapter = new CustomSearchedAPIListAdapter(this, food);
                    list.Adapter = listAdapter;

                    list.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e) {
                        ListItemClicked(e.Position, e.Position);
                    };
                }
                listAdapter = new CustomSearchedAPIListAdapter(this, food);
                list.Adapter = listAdapter;
            } catch (Exception e) {
                Toast.MakeText(Application.Context, "Error while retreiving the results from the api. Try agina later" 
                    + e.Message.ToString() , ToastLength.Long).Show();
            }
        }
        //the method to select the food from the listview itself
        private void ListItemClicked(int position, long id) {
            var t = food.Hits.ToArray()[position];
            FoodStorage.FoodStorageItems.food = food;
            FoodStorage.FoodStorageItems.DBFood = t;
            Intent FoodSpecActvity = new Intent(this, typeof(FoodLayoutSpec));
            StartActivityForResult(FoodSpecActvity, 1);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data) {
            if (requestCode == 1) {
                if (resultCode == Result.Ok) {
                    SetResult(Result.Ok);
                    Finish();
                }
                //if (resultCode == Result.Canceled){
                //}
            }
        }//OnActivityResult end
    }
}