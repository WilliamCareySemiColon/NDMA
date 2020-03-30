using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using NDMA.Resources.NutritionalAdvisors;

namespace NDMA.Resources.AdvisorActivities
{
    [Activity(Label = "TestFoodResults")]
    public class TestFoodResults : Activity
    {
        /*******************************************************************************************************
         * The activity to display the food results and get the advice from the nutrional advisor and the chart 
         * display for the graphical advice
         *******************************************************************************************************/
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.TestFoodResults);

            Button FinishAssessingInfoBtn = FindViewById<Button>(Resource.Id.FinishAssessingInfoBtn);
            FinishAssessingInfoBtn.Click += delegate {
                SetResult(Result.Ok);
                Finish();
            };

            TextView displayText = FindViewById<TextView>(Resource.Id.TestSampleTextViewResult);

            var cal = NutrionalAdvisor.GetCalorieCount(FoodStorageForTestData.FoodStorage.FoodCollectionItems);
            var context = NutrionalAdvisor.GetCalorieAdvise(cal);

            if(context.Length ==1) {
                displayText.Text = context[0];
            } else {
                if(String.Equals(context[0],"Obesity")) {
                    displayText.Text = "Overweight\n " + context[1];
                } else {
                    displayText.Text = "Underweight\n " + context[1];
                }
            }
          
            //working with the chart itself
            SfChart chart = FindViewById<SfChart>(Resource.Id.SfChartTestData);

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
            secondaryAxis.Title.Text = "Amount Consumed (in kcal)";
            secondaryAxis.LineStyle.StrokeColor = Color.White;
            secondaryAxis.Title.StrokeColor = Color.White;
            secondaryAxis.Title.TextColor = Color.White;
            secondaryAxis.LabelStyle.TextColor = Color.Black;

            //adding the axis to the charts
            chart.SecondaryAxis = secondaryAxis;

            var elements = NutrionalAdvisor.GetCaloriesAdvise(FoodStorageItems.StaticFoodCollection.StoredFood, this);
            var loggedDataCalories = FoodStorageItems.StaticFoodCollection.StoredFood.Count != 0 ? NutrionalAdvisor.GetStaticCalories() : 0;
            var recommendedData = NutrionalAdvisor.GetRecommendedAmount();

            //working with the chart data to be deisplayed
            ObservableCollection<ChartData> ConsumedData = new ObservableCollection<ChartData>(){
                new ChartData{Name = "User Comsumed ",
                    //the code below is test data
                    //Height = 2000
                    Height = cal
                }
            };

            //Initializing column series
            ColumnSeries Consumedseries = new ColumnSeries();
            Consumedseries.ItemsSource = ConsumedData;
            Consumedseries.XBindingPath = "Name";
            Consumedseries.YBindingPath = "Height";
            Consumedseries.Spacing = 0.5;
            Consumedseries.Label = "User Comsumed";

            ObservableCollection<ChartData> RecommendedData = new ObservableCollection<ChartData>(){
                new ChartData{Name = "Recommended Amount",Height = recommendedData}
            };

            //Initializing column series
            ColumnSeries Recommendedseries = new ColumnSeries();
            Recommendedseries.ItemsSource = RecommendedData;
            Recommendedseries.XBindingPath = "Name";
            Recommendedseries.YBindingPath = "Height";
            Recommendedseries.Color = Color.BlueViolet;
            Recommendedseries.Spacing = 0.5;
            Recommendedseries.Label = "Recommended Amount";

            //adding the series to the chart itself
            chart.Series.Add(Consumedseries);
            chart.Series.Add(Recommendedseries);
            chart.Legend.Visibility = Visibility.Visible;
        }//end oncreate method
    }
}