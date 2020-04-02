﻿using System;
using System.Collections.ObjectModel;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using Com.Syncfusion.Charts;
using NDMA.Resources.NutritionalAdvisors;

namespace NDMA.Resources.AdvisorActivities
{
    [Activity(Label = "AdvisorMain")]
    public class AdvisorMain : Activity
    {
        /**************************************************************************************************************************
         * The advisor system that displays the chart for the user to see their calories in the chart form. The trial liscense is 
         * used here for the usage of the application chart system. This application also connects to the other parts of the advisor
         * system that are used inside the system
         *************************************************************************************************************************/
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Register Syncfusion license - trial liscense itself
            Syncfusion.
                Licensing.
                SyncfusionLicenseProvider.
                RegisterLicense("MjI4MzE1QDMxMzcyZTM0MmUzMEhtcEU5a1lNRDBkSW9qWnM2OTIxSklSUnI2UW9PaEJPZ01aU2UyVFdYdjg9");

            // Create your application here
            SetContentView(Resource.Layout.AdvisorMain);

            //Setting the handlers on the buttons
            Button advise = FindViewById<Button>(Resource.Id.AdviseBtn);
            //Button overdone = FindViewById<Button>(Resource.Id.OverdoneBtn);
            //Button underdone = FindViewById<Button>(Resource.Id.UnderdoneBtn);
            Button checkQuicklyBtn = FindViewById<Button>(Resource.Id.CheckQuicklyBtn);
            Button cancel = FindViewById<Button>(Resource.Id.CancelAdvise);

            advise.Click += delegate { ButtonClicked("Advise"); };
            //overdone.Click += delegate { ButtonClicked("overdone"); };
            //underdone.Click += delegate { ButtonClicked("underdone"); };
            checkQuicklyBtn.Click += delegate { ButtonClicked("checkQuickly"); };
            cancel.Click += delegate { ButtonClicked("cancel"); };

            //The images as temp placeholders and direction to the newer activities which are not used and developed due to timing constraints
            //ImageView dailyStatusImage = FindViewById<ImageView>(Resource.Id.DailyStatusImage);
            //dailyStatusImage.Click += delegate { ImageClicked("Daily"); };

            //working with the chart itself
            SfChart chart = FindViewById<SfChart>(Resource.Id.SfChart);

            //the primary axis itself  
            CategoryAxis primaryAxis = new CategoryAxis();
            //setting the colours of the object itself
            primaryAxis.LineStyle.StrokeColor = Color.White;
            primaryAxis.Title.Text = "Calories";
            primaryAxis.Title.StrokeColor = Color.White;
            primaryAxis.Title.TextColor = Color.White;
            primaryAxis.LabelStyle.TextColor = Color.Black;
            chart.PrimaryAxis = primaryAxis;

            // secondary Axis
            NumericalAxis secondaryAxis = new NumericalAxis();
            //setting the colours
            secondaryAxis.Title.Text = "Amount Consumed ";
            secondaryAxis.LineStyle.StrokeColor = Color.White;
            secondaryAxis.Title.StrokeColor = Color.White;
            secondaryAxis.Title.TextColor = Color.White;
            secondaryAxis.LabelStyle.TextColor = Color.Black;

            //adding the axis to the charts
            chart.SecondaryAxis = secondaryAxis;

            var elements = NutrionalAdvisor.GetCaloriesAdvise(FoodStorageItems.StaticFoodCollection.StoredFood, this);

            var loggedDataCalories = FoodStorageItems.StaticFoodCollection.StoredFood.Count != 0 ? NutrionalAdvisor.GetStaticCalories() : 0 ;
            var carbLoggedData = FoodStorageItems.StaticFoodCollection.StoredFood.Count != 0 ? NutrionalAdvisor.GetStaticCarbs() : 0;
            var waterLogged = FoodStorageItems.StaticFoodCollection.StoredFood.Count != 0 ? NutrionalAdvisor.GetStaticWater() : 0;
            var fatLogged = FoodStorageItems.StaticFoodCollection.StoredFood.Count != 0 ? NutrionalAdvisor.GetStaticFat() : 0;
            var protienLogged = FoodStorageItems.StaticFoodCollection.StoredFood.Count != 0 ? NutrionalAdvisor.GetStaticProtein() : 0;
            var fiberLogged = FoodStorageItems.StaticFoodCollection.StoredFood.Count != 0 ? NutrionalAdvisor.GetStaticFiber() : 0;

            var recommendedData = NutrionalAdvisor.GetRecommendedAmount();
            var recommendCarbs = NutrionalAdvisor.GetRecommendedCarbAmount();
            var recommendedProtein = NutrionalAdvisor.GetRecommendedProteinAmount();
            var recommendedFat = NutrionalAdvisor.GetRecommendedFatAmount();
            var recommendedWater = NutrionalAdvisor.GetRecommendedWaterAmount();
            var recommededFiber = NutrionalAdvisor.GetRecommendedFiberAmount();

            //working with the chart data to be deisplayed
            ObservableCollection<ChartData> ConsumedData = new ObservableCollection<ChartData>() {
                new ChartData{ Name = "Cal (KCAL)",Height = loggedDataCalories },
                new ChartData{ Name = "Carbs (g)",Height = carbLoggedData },
                new ChartData{ Name = "Water (ml)",Height = waterLogged },
                new ChartData{ Name = "Fat (g) ",Height = fatLogged },
                new ChartData{ Name = "Protein (g)",Height = protienLogged },
                new ChartData{ Name = "Fiber (g)",Height = fiberLogged }
            };

            //Initializing column series
            ColumnSeries Consumedseries = new ColumnSeries();
            Consumedseries.ItemsSource = ConsumedData;
            Consumedseries.XBindingPath = "Name";
            Consumedseries.YBindingPath = "Height";
            //Consumedseries.Spacing =  0.5;
            Consumedseries.Label = "User Comsumed";

            ObservableCollection<ChartData> RecommendedData = new ObservableCollection<ChartData>() {
                new ChartData {Name = "", Height = recommendedData },
                new ChartData{Name = "",Height = recommendCarbs},
                new ChartData{Name = "", Height = recommendedWater},
                new ChartData{Name = "", Height = fatLogged},
                new ChartData{Name = "", Height = recommendedProtein},  
                new ChartData {Name = "",Height = recommededFiber}
            };

            //Initializing column series
            ColumnSeries Recommendedseries = new ColumnSeries();
            Recommendedseries.ItemsSource = RecommendedData;
            Recommendedseries.XBindingPath = "Name";
            Recommendedseries.YBindingPath = "Height";
            Recommendedseries.Color = Color.Navy;
            //Recommendedseries.Spacing = 0.5;
            Recommendedseries.Label = "Recommended Amount";

            //adding the series to the chart itself
            chart.Series.Add(Consumedseries);
            chart.Series.Add(Recommendedseries);

            chart.Legend.Visibility = Visibility.Visible;

            Toast.MakeText(this, "Fiber contains " + fiberLogged, ToastLength.Short).Show();

        }

        //mtehod when a image clicked to redirect to another layout - placeholder for inital graph design
        //The method is not used inside the application due to timing constraints
        private void ImageClicked(String id) {
            if(String.Equals(id,"Daily"))
            {
                Intent intent = new Intent(this, typeof(DailyStatusGraph));
                StartActivity(intent);
            }
            else if (String.Equals(id, "Weekly"))
            {
                Intent intent = new Intent(this, typeof(WeeklyStatusGraph));
                StartActivity(intent);
            }
        }
      
        private void ButtonClicked(String id) {
            switch (id) {
                case "Advise":
                    {
                        Intent intent = new Intent(this, typeof(MainAdviseContent));
                        StartActivity(intent);
                        break;
                    }
                //The activity for this is never triggered and is not used due to timing contraints
                case "overdone":
                    {
                        Intent intent = new Intent(this, typeof(OverdoneAdvise));
                        StartActivity(intent);
                        break;
                    }
                //The activity for this is never triggered and is not used due to timing contraints
                case "underdone":
                    {
                        Intent intent = new Intent(this, typeof(Underdone));
                        StartActivity(intent);
                        break;
                    }
                case "checkQuickly":
                    {
                        Intent intent = new Intent(this, typeof(CheckDailyInputForWeeklySample));
                        StartActivity(intent);
                        break;
                    }
                case "cancel":
                    {
                        Finish();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }//end button clicked
    }
}