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

namespace NDMA.Resources.AdvisorActivities
{
    [Activity(Label = "AdvisorMain")]
    public class AdvisorMain : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AdvisorMain);

            //Setting the handlers on the buttons
            Button advise = FindViewById<Button>(Resource.Id.AdviseBtn);
            Button overdone = FindViewById<Button>(Resource.Id.OverdoneBtn);
            Button underdone = FindViewById<Button>(Resource.Id.UnderdoneBtn);
            Button checkQuicklyBtn = FindViewById<Button>(Resource.Id.CheckQuicklyBtn);
            Button cancel = FindViewById<Button>(Resource.Id.CancelAdvise);

            advise.Click += delegate { ButtonClicked("Advise"); };
            overdone.Click += delegate { ButtonClicked("overdone"); };
            underdone.Click += delegate { ButtonClicked("underdone"); };
            checkQuicklyBtn.Click += delegate { ButtonClicked("checkQuickly"); };
            cancel.Click += delegate { ButtonClicked("cancel"); };
            //setting the handlers on the images     WeeklyStatusImage
            ImageView dailyStatusImage = FindViewById<ImageView>(Resource.Id.DailyStatusImage);
            ImageView weeklyStatusImage = FindViewById<ImageView>(Resource.Id.WeeklyStatusImage);

            dailyStatusImage.Click += delegate { ImageClicked("Daily"); };
            weeklyStatusImage.Click += delegate { ImageClicked("Weekly"); };
           
        }

        private void ImageClicked(String id)
        {
            //Toast.MakeText(Application.Context, "You have pressed the image with tthe id of " + id,
            //    ToastLength.Short).Show();

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