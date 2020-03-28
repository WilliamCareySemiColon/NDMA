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
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Data.Model;

namespace NDMA.Resources.AdvisorActivities
{
    [Activity(Label = "AdvisorMain")]
    public class AdvisorMain : Activity
    {
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
            //setting the handlers on the images  WeeklyStatusImage
            //ImageView dailyStatusImage = FindViewById<ImageView>(Resource.Id.DailyStatusImage);
            ////ImageView weeklyStatusImage = FindViewById<ImageView>(Resource.Id.WeeklyStatusImage);
            //dailyStatusImage.Click += delegate { ImageClicked("Daily"); };

            //working with the chart itself
            SfChart chart = FindViewById<SfChart>(Resource.Id.SfChart);

            //the primary axis itself  
            CategoryAxis primaryAxis = new CategoryAxis();
            //setting the colours of the object itself
            primaryAxis.LineStyle.StrokeColor = Color.White;
            primaryAxis.Title.Text = "Name";
            primaryAxis.Title.StrokeColor = Color.White;
            primaryAxis.Title.TextColor = Color.White;
            primaryAxis.LabelStyle.TextColor = Color.Black;
            chart.PrimaryAxis = primaryAxis;

            // secondary Axis
            NumericalAxis secondaryAxis = new NumericalAxis();
            //setting the colours
            secondaryAxis.Title.Text = "Height (in cm)";
            secondaryAxis.LineStyle.StrokeColor = Color.White;
            secondaryAxis.Title.StrokeColor = Color.White;
            secondaryAxis.Title.TextColor = Color.White;
            secondaryAxis.LabelStyle.TextColor = Color.Black;

            //adding the axis to the charts
            chart.SecondaryAxis = secondaryAxis;
            
            //working with the chart data to be deisplayed
            ObservableCollection<ChartData> Data = new ObservableCollection<ChartData>()
            {
                new ChartData { Name = "David", Height = 180 },
                new ChartData { Name = "Michael", Height = 170 },
                new ChartData { Name = "Steve", Height = 160 },
                new ChartData { Name = "Joel", Height = 182 }
            };

            //Initializing column series
            ColumnSeries series = new ColumnSeries();
            series.ItemsSource = Data;
            series.XBindingPath = "Name";
            series.YBindingPath = "Height";

            //adding the series to the chart itself
            chart.Series.Add(series);

        }

        //mtehod when a image clicked to redirect to another layout - placeholder for inital graph design
        private void ImageClicked(String id)
        {
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
      
        private void ButtonClicked(String id)
        {
            switch (id)
            {
                case "Advise":
                    {
                        Intent intent = new Intent(this, typeof(MainAdviseContent));
                        StartActivity(intent);
                        break;
                    }
                case "overdone":
                    {
                        Intent intent = new Intent(this, typeof(OverdoneAdvise));
                        StartActivity(intent);
                        break;
                    }
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
        }
    }
}