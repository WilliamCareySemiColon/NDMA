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
                //case "checkQuickly":
                //    {
                //        Intent intent = new Intent(this, typeof());
                //        break;
                //    }
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
            //Toast.MakeText(Application.Context,
            //    "You have presseed the button with the id of " + id,
            //    ToastLength.Short).Show();
        }
    }
}