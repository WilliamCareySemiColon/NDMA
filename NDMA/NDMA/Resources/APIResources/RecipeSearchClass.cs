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

namespace NDMA.Resources.APIResources
{
    public static class RecipeSearchClass
    {
        /**********************************************************************************
         * The ideal way to decouple the application to use HTTP connetion - to search the 
         * api for the logged food itself
         * 
         * This is not used inside the application
         *********************************************************************************/
        //food api creditails to read from
        private static readonly string[] FoodDBApiCreds = new string[] {
            "40bde6df" , "3249bb41449954869d9cae17f11061b1" };

        //nutrition wizard api crediatials
        private static readonly string[] NutritionAnalysisApiCreds = new string[] {
            "69c87eb5", "025e6570cf3f613168acc8c6e74c37ae" };

        //Recipe search api
        private static readonly string[] RecipeSearchApCreds = new string[] {
            "c570405e", "14793a0482c121e16b365ac4ff89cb1e" };

        public static ParsedFoodCollection food;

        public static ParsedFoodCollection ReturnFood(int from, int to, String keyWord)
        {
            GetApiContent(from, to, keyWord);
            return food;
        }
        public static async void GetApiContent(int from, int to, String keyWord)
        {
            HttpClient client = new HttpClient();

            string url = "https://api.edamam.com/search?q=" + keyWord +
                "&app_id=" + RecipeSearchApCreds[0] + "&app_key="
                + RecipeSearchApCreds[1] + "&from=" + from + "&to=" + to;

            Uri uri = new Uri(url);
            var response = await client.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();
            food = JsonConvert.DeserializeObject<ParsedFoodCollection>(json);
        }
    }
}