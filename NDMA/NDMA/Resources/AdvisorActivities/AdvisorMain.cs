using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
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

            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjI4MzE1QDMxMzcyZTM0MmUzMEhtcEU5a1lNRDBkSW9qWnM2OTIxSklSUnI2UW9PaEJPZ01aU2UyVFdYdjg9");

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
            ImageView dailyStatusImage = FindViewById<ImageView>(Resource.Id.DailyStatusImage);
            //ImageView weeklyStatusImage = FindViewById<ImageView>(Resource.Id.WeeklyStatusImage);

            dailyStatusImage.Click += delegate { ImageClicked("Daily"); };
            //weeklyStatusImage.Click += delegate { ImageClicked("Weekly"); };

            //Newer items
            ////////////////////////////////////////////////////////////////////////////////////
            //// set license key before using SciChart
            //SciChartSurface.SetRuntimeLicenseKey("");

            //// Get our chart from the layout resource,
            //var chart = FindViewById<SciChartSurface>(Resource.Id.Chart);

            //// Create a numeric X axis
            //var xAxis = new NumericAxis(this) { AxisTitle = "Number of Samples (per Series)" };

            //// Create a numeric Y axis
            //var yAxis = new NumericAxis(this)
            //{
            //    AxisTitle = "Value",
            //    VisibleRange = new DoubleRange(-1, 1)
            //};

            //// Add xAxis to the XAxes collection of the chart
            //chart.XAxes.Add(xAxis);

            //// Add yAxis to the YAxes collection of the chart
            //chart.YAxes.Add(yAxis);
            //////////////////////////////////////////////////////////////////////////////////////////////////
            SfChart chart = FindViewById<SfChart>(Resource.Id.SfChart);
                //new SfChart(this);

            //Initializing Primary Axis
            //CategoryAxis primaryAxis = new CategoryAxis();

            //chart.PrimaryAxis = primaryAxis;

            ////Initializing Secondary Axis
            //NumericalAxis secondaryAxis = new NumericalAxis();

            //chart.SecondaryAxis = secondaryAxis;

            // Initializing primary axis
            CategoryAxis primaryAxis = new CategoryAxis();

            primaryAxis.Title.Text = "Name";

            chart.PrimaryAxis = primaryAxis;

            //Initializing secondary Axis
            NumericalAxis secondaryAxis = new NumericalAxis();

            secondaryAxis.Title.Text = "Height (in cm)";

            chart.SecondaryAxis = secondaryAxis;

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

            chart.Series.Add(series);
        }

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