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
using NDMA.Resources.Adapter;
using NDMA.Resources.LoggingFood;

namespace NDMA.Resources
{
    [Activity(Label = "LogDiet")]
    public class LogDiet : Activity
    {
        private String [] template = null;
        private String[] information = null;
        private CheckBox[] checkBoxes;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            if (information == null)
            {
                //Intent FoodScheduleActivitiy = new Intent(this, typeof(FoodDailySchedule));
                //StartActivity(FoodScheduleActivitiy);
                SetContentView(Resource.Layout.FoodDailySchedule);

            }

            GetTemplateFromUser();
           
        }

        private void ButtonClicked(string id)
        {
            switch (id)
            {
                case "add":
                    {
                        Intent SearchForFoodActivity = new Intent(this, typeof(SearchForFoodFromApi));
                        StartActivity(SearchForFoodActivity);
                        break;
                    }
                case "cancel":
                    {
                        Finish();
                        break;
                    }
                case "discard":
                    {
                        Toast.MakeText(Application.Context, "You have pressed the button with the id " + id, ToastLength.Short).Show();
                        break;
                    }
                case "save":
                    {
                        Toast.MakeText(Application.Context, "You have pressed the button with the id " + id, ToastLength.Short).Show();
                        break;
                    }
                case "submit":
                    {
                        Toast.MakeText(Application.Context, "You have pressed the button with the id " + id, ToastLength.Short).Show();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }//end switch

        }

        //private void ListItemClicked(ListView l, View v, int position, long id)
        //{
        //    var t = information[position];
        //    Toast.MakeText(Application.Context, t + " " + id, ToastLength.Short).Show();
        //}

        private void ListItemClicked(int position, long id)
        {
            var t = information[position];
            Toast.MakeText(Application.Context, t + " " + id, ToastLength.Short).Show();
        }

        private void SetUpMainLoggingPage()
        {
            //Button items and their handlers
            Button add = FindViewById<Button>(Resource.Id.Add);
            Button cancel = FindViewById<Button>(Resource.Id.Cancel);
            Button discard = FindViewById<Button>(Resource.Id.Discard);
            Button save = FindViewById<Button>(Resource.Id.Save);
            Button submit = FindViewById<Button>(Resource.Id.Submit);
            //applying the handlers to the buttons
            add.Click += delegate { ButtonClicked("add"); };
            cancel.Click += delegate { ButtonClicked("cancel"); };
            discard.Click += delegate { ButtonClicked("discard"); };
            save.Click += delegate { ButtonClicked("save"); };
            submit.Click += delegate { ButtonClicked("submit"); };


            //attempting to connect to the listview
            CustomDefaultListAdapter listSimpleAdapter = new CustomDefaultListAdapter(this, template);
            ArrayAdapter listAdapter = new ArrayAdapter(Application.Context, Android.Resource.Layout.SimpleListItem1, template);
            ListView list = FindViewById<ListView>(Resource.Id.UserFoodList);
            list.Adapter = listSimpleAdapter;


            list.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
            {
                //ListItemClicked(list, new View(Application.Context), e.Position, e.Position);
                ListItemClicked(e.Position, e.Position);
                //, list.SelectedItemId);

            };

        }

        private void GetTemplateFromUser()
        {
            Button cancel = FindViewById<Button>(Resource.Id.CancelSchBtn), submit = FindViewById<Button>(Resource.Id.SubmitSchBtn);

            cancel.Click += delegate { Finish(); };
            submit.Click += delegate { ProceedToMainLoggingPage(); };

            //Setting the checkboxes
            checkBoxes = new CheckBox[]
            {
                FindViewById<CheckBox>(Resource.Id.BreakfastCb),
                FindViewById<CheckBox>(Resource.Id.BrunchCb),
                FindViewById<CheckBox>(Resource.Id.LunchCb),
                FindViewById<CheckBox>(Resource.Id.DunchCb),
                FindViewById<CheckBox>(Resource.Id.DinnerCb),
                FindViewById<CheckBox>(Resource.Id.SupperCb)
            };

            foreach(CheckBox checks in checkBoxes)
            {
                checks.Click += delegate { checks.Selected = true; };
            }
        }

        private void ProceedToMainLoggingPage()
        {
            int amount = 0;
            int count = checkBoxes.Length;
            string[] convert = new string[count];

            for(int i = 0; i < count; i++)
            {
                if(checkBoxes[i].Selected == true)
                {
                    convert[amount] = checkBoxes[i].Text;
                    amount++;
                }
            }

            template = new String[amount];

            for(int i = 0; i < amount; i++)
            {
                template[i] = convert[i];
            }

            information = new String[] { "Sampe", "Sampe", "Sampe", "Sampe", "Sampe" };

            if (!(information == null))
            {
                SetContentView(Resource.Layout.LogDiet);
            }

            Toast.MakeText(Application.Context, "Your schedule is curently being created", ToastLength.Short).Show();

            SetUpMainLoggingPage();
        }

    }
}