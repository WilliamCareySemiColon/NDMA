﻿using System;
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

        //actually methods for the three main pages
        public static int GetOverConsumedProducts(List<DBFood> dBFoodCollection)
        {
            double cal = 0, fat = 0, fasat = 0, chocdf = 0, fibig = 0, sugar = 0, protein = 0, water = 0;
            foreach (DBFood food in dBFoodCollection)
            {
                var foodIn = food.Recipe.TotalNutrients;

                cal += foodIn.ENERC_KCAL.quantity;
                fat += foodIn.FAT.quantity;
                fasat += foodIn.FASAT.quantity;
                chocdf += foodIn.CHOCDF.quantity;
                fibig += foodIn.FIBTG.quantity;
                sugar += foodIn.SUGAR.quantity;
                protein += foodIn.PROCNT.quantity;
                water += foodIn.WATER.quantity;
            }
            //going over each of the variables to find the over consumed food
            List<double> OverComsumedfood = new List<double>();
            //calories
            if(cal > TestSampleData.Calories)
            {
                OverComsumedfood.Add(cal);
            }
            //fat - going through percentage rather then direct value
            float FatPercentage = float.Parse(TestRecAmoDBData.Fat.MaxPercentage);
            if(fat > (TestSampleData.Calories * FatPercentage / 100))
            {
                OverComsumedfood.Add(fat);
            }
            //carbs
            float Carb = float.Parse(
                TestRecAmoDBData.Carbohydrates.AmountMale.Remove(
                    TestRecAmoDBData.Carbohydrates.AmountMale.Length - 1,1
                    )
                );
            if (chocdf > Carb)
            {
                OverComsumedfood.Add(chocdf);
            }
            //protein
            float proteinInput = float.Parse(
                TestRecAmoDBData.Protein.AmountMale.Remove(
                    TestRecAmoDBData.Protein.AmountMale.Length - 1, 1
                    )
                );
            if (protein > proteinInput)
            {
                OverComsumedfood.Add(protein);
            }
            //water
            float waterInput = float.Parse(
                 TestRecAmoDBData.Water.AmountMale.Remove(
                     TestRecAmoDBData.Water.AmountMale.Length - 1, 1
                     )
                 );

            if(water > waterInput)
            {
                if (protein > proteinInput)
                {
                    OverComsumedfood.Add(protein);
                }
            }

            //return data
            return OverComsumedfood.Count;
        }

        //actually methods for the three main pages
        public static int GetUnderConsumedProducts(List<DBFood> dBFoodCollection)
        {
            double cal = 0, fat = 0, fasat = 0, chocdf = 0, fibig = 0, sugar = 0, protein = 0, water = 0;
            foreach (DBFood food in dBFoodCollection)
            {
                var foodIn = food.Recipe.TotalNutrients;

                cal += foodIn.ENERC_KCAL.quantity;
                fat += foodIn.FAT.quantity;
                fasat += foodIn.FASAT.quantity;
                chocdf += foodIn.CHOCDF.quantity;
                fibig += foodIn.FIBTG.quantity;
                sugar += foodIn.SUGAR.quantity;
                protein += foodIn.PROCNT.quantity;
                water += foodIn.WATER.quantity;
            }
            //going over each of the variables to find the over consumed food
            List<double> UnderComsumedfood = new List<double>();
            //calories
            if (cal < TestSampleData.MinCalories)
            {
                UnderComsumedfood.Add(cal);
            }
            //fat - going through percentage rather then direct value
            float FatPercentage = float.Parse(TestRecAmoDBData.Fat.MinPercentage);
            if (fat < (TestSampleData.Calories * FatPercentage / 100))
            {
                UnderComsumedfood.Add(fat);
            }
            //carbs
            float Carb = float.Parse(
                TestRecAmoDBData.Carbohydrates.AmountMale.Remove(
                    TestRecAmoDBData.Carbohydrates.AmountMale.Length - 1, 1
                    )
                );
            if (chocdf < Carb)
            {
                UnderComsumedfood.Add(chocdf);
            }
            //protein
            float proteinInput = float.Parse(
                TestRecAmoDBData.Protein.AmountMale.Remove(
                    TestRecAmoDBData.Protein.AmountMale.Length - 1, 1
                    )
                );
            if (protein < proteinInput)
            {
                UnderComsumedfood.Add(protein);
            }
            //water
            float waterInput = float.Parse(
                 TestRecAmoDBData.Water.AmountMale.Remove(
                     TestRecAmoDBData.Water.AmountMale.Length - 1, 1
                     )
                 );

            if (water < waterInput)
            {
                if (protein > proteinInput)
                {
                    UnderComsumedfood.Add(protein);
                }
            }

            //return data
            return UnderComsumedfood.Count;
        }

    }
}