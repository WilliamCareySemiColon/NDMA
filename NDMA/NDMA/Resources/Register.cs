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
    [Activity(Label = "Register")]
    public class Register : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Register);

            //age category details
            Spinner ageCategory = FindViewById<Spinner>(Resource.Id.AgeCategory);
            ageCategory.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_ItemSelected);
            ArrayAdapter ageCategoryAdapter = ArrayAdapter.CreateFromResource(this, 
                Resource.Array.AgeCategory, Android.Resource.Layout.SimpleSpinnerItem);
            ageCategoryAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            ageCategory.Adapter = ageCategoryAdapter;
            //sex category details
            Spinner sexCategory = FindViewById<Spinner>(Resource.Id.SexCategory);
            sexCategory.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_ItemSelected);
            ArrayAdapter sexCategoryAdpater = ArrayAdapter.CreateFromResource(this,
                Resource.Array.SexCategory, Android.Resource.Layout.SimpleSpinnerItem);
            sexCategoryAdpater.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            sexCategory.Adapter = sexCategoryAdpater;
            //button details
            Button register = FindViewById<Button>(Resource.Id.Register);
            register.Click += delegate
            {
                ButtonClicked("Register");
            };

            Button loginInstead = FindViewById<Button>(Resource.Id.LoginInstead);
            loginInstead.Click += delegate
            {
                ButtonClicked("Login");
            };
        }

        private void Spinner_ItemSelected(Object sender,AdapterView.ItemSelectedEventArgs e)
        {
            var spinner = sender as Spinner;
            if(!(string.Equals(spinner.GetItemAtPosition(e.Position).ToString(),"Age Category") 
                || string.Equals(spinner.GetItemAtPosition(e.Position).ToString(), "Sex Category")))
            {
                Toast.MakeText(Application.Context,
                "You choice the item " + spinner.GetItemAtPosition(e.Position),
                ToastLength.Short).Show();
            }
        }

        private void ButtonClicked(string id)
        {
            Toast.MakeText(Application.Context,
                "You have pressed the " + id + " button", ToastLength.Short).Show();
        }
    }
}