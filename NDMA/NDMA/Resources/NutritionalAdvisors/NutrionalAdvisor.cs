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
using NDMA.Resources.ZZZTestData;

namespace NDMA.Resources.NutritionalAdvisors
{
    public static class NutrionalAdvisor
    {
        //test method to connect the advisor page to the actual advisor
        public static void GetCalories(List<DBFood> dBFoodCollection, Activity context)
        {
            double cal = 0;
            string message;

            foreach(DBFood food in dBFoodCollection )
            {
                var nutritionCollection = food.Recipe.TotalNutrients;

                var caloriesChecking = nutritionCollection.ENERC_KCAL;

                cal = caloriesChecking.quantity;

            }

            var boolState = cal > TestSampleData.Calories ? true : false;


            if (cal > TestSampleData.Calories)
            {
                message = "Too much calories are being consumed with consumed food, please consome less";
            }
            else if (cal < TestSampleData.MinCalories)
            {
                message = "Too little calories are being consumed with consumed food, please consome more";
            }
            else
            {
                message = "Amount of calories comsuned within acceptable paramters";
            }

            Toast.MakeText(context, message,ToastLength.Short).Show();
        }

    }
}