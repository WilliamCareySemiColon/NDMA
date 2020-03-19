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
using NDMA.Resources.JsonLoggedFood;

namespace NDMA.Resources
{
    [Activity(Label = "LogDiet")]
    public class LogDiet : Activity
    {
        private String[] template = null;
        private CheckBox[] checkBoxes;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            if(FoodStorageItems.FoodScheduleStorage.Template == null)
            {
                SetContentView(Resource.Layout.FoodDailySchedule);

                GetTemplateFromUser();
            }
           else
            {
                SetUpMainLoggingPage();
            }
        }

        private void ButtonClicked(string id)
        {
            switch (id)
            {
                //case "add":
                //    {
                //        Intent SearchForFoodActivity = new Intent(this, typeof(SearchForFoodFromApi));
                //        StartActivity(SearchForFoodActivity);
                //        break;
                //    }
                case "cancel":
                    {
                        Finish();
                        break;
                    }
                case "discard":
                    {
                        FoodStorageItems.FoodScheduleStorage.Template = null;
                        FoodStorageItems.FoodScheduleStorage.ScheduleTrack = null;
                        FoodStorageItems.FoodScheduleStorage.FoodItemNamesStorage = null;
                        FoodStorageItems.FoodScheduleStorage.ScheduleID = null;
                        FoodStorageItems.StaticFoodCollection.StoredFood = new List<DBFood>();
                        Finish();
                        break;
                    }
                //case "save":
                //    {
                //        Toast.MakeText(Application.Context, "You have pressed the button with the id " + id, ToastLength.Short).Show();
                //        break;
                //    }
                case "submit":
                    {
                        FoodStorageItems.FoodScheduleStorage.Template = null;
                        FoodStorageItems.FoodScheduleStorage.ScheduleTrack = null;
                        FoodStorageItems.FoodScheduleStorage.FoodItemNamesStorage = null;
                        FoodStorageItems.FoodScheduleStorage.ScheduleID = null;
                        //Toast.MakeText(Application.Context,
                        //    "The size of the list is "  + FoodStorageItems.StaticFoodCollection.StoredFood.Count
                        //    , ToastLength.Short).Show();
                        Finish();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }//end switch

        }

        private void SetUpMainLoggingPage()
        {
            SetContentView(Resource.Layout.LogDiet);

            //Button items and their handlers
            //Button add = FindViewById<Button>(Resource.Id.Add);
            Button cancel = FindViewById<Button>(Resource.Id.Cancel);
            Button discard = FindViewById<Button>(Resource.Id.Discard);
            //Button save = FindViewById<Button>(Resource.Id.Save);
            Button submit = FindViewById<Button>(Resource.Id.Submit);
            //applying the handlers to the buttons
            //add.Click += delegate { ButtonClicked("add"); };
            cancel.Click += delegate { ButtonClicked("cancel"); };
            discard.Click += delegate { ButtonClicked("discard"); };
            //save.Click += delegate { ButtonClicked("save"); };
            submit.Click += delegate { ButtonClicked("submit"); };

            //attempting to connect to the listview
            SetListView();
        }

        public void SetListView()
        {
            //attempting to connect to the listview
            CustomDefaultListAdapter listSimpleAdapter = new CustomDefaultListAdapter(this,
                FoodStorageItems.FoodScheduleStorage.Template,
                FoodStorageItems.FoodScheduleStorage.FoodItemNamesStorage);

            ListView list = FindViewById<ListView>(Resource.Id.UserFoodList);
            list.Adapter = listSimpleAdapter;
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

            foreach (CheckBox check in checkBoxes)
            {
                if (check.Selected)
                {
                    convert[amount] = check.Text;
                    amount++;
                }
            }

            template = new String[amount + 1];
            Dictionary<String, int> ScheduleTrack = new Dictionary<String, int>();
            String[] FoodNames = new String[amount + 1];
            FoodNames[0] = "";

            template[0] = "Food Schedule List";
            ScheduleTrack.Add("Food Schedule List", 0);

            for (int i = 0; i < amount; i++)
            {
                int j = i + 1;
                template[j] = convert[i];

                ScheduleTrack.Add(template[j], j);
                FoodNames[j] = "";
            }

            foreach(CheckBox check in checkBoxes)
            {
                if(!template.Contains(check.Text))
                {
                    check.Selected = false;
                }
            }

            FoodStorageItems.FoodScheduleStorage.Template = template;
            FoodStorageItems.FoodScheduleStorage.ScheduleTrack = ScheduleTrack;

            FoodStorageItems.FoodScheduleStorage.FoodItemNamesStorage = FoodNames;

            SetUpMainLoggingPage();
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if(requestCode == 2)
            {
                if(resultCode == Result.Ok)
                {
                    SetListView();
                }
            }
        }
    }
}