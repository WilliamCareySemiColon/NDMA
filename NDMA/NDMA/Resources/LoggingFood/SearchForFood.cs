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

namespace NDMA.Resources.LoggingFood
{
    [Activity(Label = "SearchForFood")]
    public class SearchForFood : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SearchForFood);

            EditText search = FindViewById<EditText>(Resource.Id.Search);
            search.TextChanged += delegate
            {
                TextChanged(search.Text);
            };

            //Button handlers
            Button cancel = FindViewById<Button>(Resource.Id.Cancel);

            cancel.Click += delegate { Finish(); };
            //getting to the 

        }

        private void TextChanged(string message)
        {
            //TextView text = FindViewById<TextView>(Resource.Id.SampleTest);

            //text.Text = message;
        }
    }
}