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

namespace NDMA.Resources.NutritionalAdvisors
{
    public static class NutrionalAdvisor
    {
        //test method to connect the advisor page to the actual advisor
        public static void GetCalories(List<DBFood> dBFoodCollection, Activity context)
        {
            double cal = 0;


            foreach(DBFood food in dBFoodCollection )
            {
                var nutritionCollection = food.Recipe.TotalNutrients;

                var caloriesChecking = nutritionCollection.ENERC_KCAL;

                cal = caloriesChecking.quantity;

            }
           

            Toast.MakeText(context, "Item looked at is " + cal,ToastLength.Short).Show();
        }
    }
}