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
        /**********************************************************************************************************************
         * The activity for the user to qeury the api to get back food data to log for the sample input. The string arrays are 
         * the key and password to the application itself
         *********************************************************************************************************************/
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

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SearchForFood);

            EditText search = FindViewById<EditText>(Resource.Id.Search);
            //Button handlers
            Button cancel = FindViewById<Button>(Resource.Id.Cancel);
            Button searchBtn = FindViewById<Button>(Resource.Id.btnSearch);

            cancel.Click += delegate {
                SetResult(Result.Canceled);
                Finish();
            };
            searchBtn.Click += delegate { SearchApi(search.Text); };
        }

        //search the api for the food data
        private void SearchApi(string message) {
            if (message.Length >= 2) {
                Toast.MakeText(this,"Application is searching for the items with the keyword: " + message,
                    ToastLength.Long).Show();

                GetFood(message);
            } else {
                Toast.MakeText(this,
                "character length needs to be at least 3 charaters: " + message,
                ToastLength.Long).Show();
            }
        }

        //getting the json food back from the api
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

                food = JsonConvert.DeserializeObject<ParsedFoodCollection>(json);

                if (food.Hits.Count == 0)
                {
                    //found the builder at the following site
                    //https://forums.xamarin.com/discussion/18186/how-to-start-an-activity-from-a-dialog-when-ok-button-is-pressed
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
                } else {
                    listAdapter = new TestCustomSearchedAPIListAdapter(this, food);
                    list.Adapter = listAdapter;

                    list.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e) {
                        ListItemClicked(e.Position, e.Position);
                    };
                }

            } catch (Exception e) {
                Toast.MakeText(Application.Context, "Error while retreiving the results from the api. Try agina later"
                    + e.Message.ToString(), ToastLength.Long).Show();
            }

        }

        //the method that is called when the listview is clicked on
        private void ListItemClicked(int position, long id) {
            var t = food.Hits.ToArray()[position];
            FoodStorageForTestData.FoodStorage.food = food;
            FoodStorageForTestData.FoodStorage.DBFood = t;

            Intent FoodSpecActvity = new Intent(this, typeof(TestAdviseLog));
            StartActivityForResult(FoodSpecActvity, 1);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data){
            if (requestCode == 1 && resultCode == Result.Ok) {
                SetResult(Result.Ok);
                Finish();
            //if (resultCode == Result.Canceled){
            //}
            }
        }//end OnActivityResult
    }
}