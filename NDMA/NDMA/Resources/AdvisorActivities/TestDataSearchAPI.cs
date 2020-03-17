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
    [Activity(Label = "TestDataSearchAPI")]
    public class TestDataSearchAPI : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SearchForFood);

            EditText search = FindViewById<EditText>(Resource.Id.Search);
            //Button handlers
            Button cancel = FindViewById<Button>(Resource.Id.Cancel);
            Button searchBtn = FindViewById<Button>(Resource.Id.btnSearch);

            cancel.Click += delegate {
                SetResult(Result.Ok);
                Finish();
            };
            searchBtn.Click += delegate { SearchApi(search.Text); };
        }

        private void SearchApi(string message)
        {

            if (message.Length >= 3)
            {
                Toast.MakeText(this,
               "Application is searching for the items with the keyword: " + message,
               ToastLength.Long).Show();

                //GetFood(message);
            }
            else
            {
                Toast.MakeText(this,
                "character length needs to be at least 3 charaters: " + message,
                ToastLength.Long).Show();
            }
        }
    }
}