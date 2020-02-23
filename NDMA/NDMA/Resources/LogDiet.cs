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

namespace NDMA.Resources
{
    [Activity(Label = "LogDiet")]
    public class LogDiet : Activity
    {

        String[] information = new String[] { "Sampe", "Sampe", "Sampe", "Sampe", "Sampe" };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LogDiet);

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
            ArrayAdapter listAdapter = new ArrayAdapter(Application.Context, Android.Resource.Layout.SimpleListItem1, information);
            ListView list = FindViewById < ListView >(Resource.Id.UserFoodList);
            list.Adapter = listAdapter;

            list.ItemClick +=  delegate (object sender, AdapterView.ItemClickEventArgs e)
            {
                ListItemClicked(list, new View(Application.Context), e.Position, e.Position);
                    //, list.SelectedItemId);

            };


        }

        private void ButtonClicked(string id)
        {
            Toast.MakeText(Application.Context,
                "You have pressed the button with the id " + id, ToastLength.Short).Show();


        }

        private void ListItemClicked(ListView l, View v, int position, long id)
        {
            var t = information[position];
            Toast.MakeText(Application.Context, t + " " + id, ToastLength.Short).Show();
        }

       
    }
}