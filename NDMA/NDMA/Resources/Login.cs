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
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.login);

            //setting the variables for the page
            Button login = FindViewById<Button>(Resource.Id.Login);
            Button RegisterInstead = FindViewById<Button>(Resource.Id.RegisterInstead);

            //setting the handlers onto the application itself
            login.Click += delegate
            {
                ButtonClicked("Login");
            };

            RegisterInstead.Click += delegate
            {
                ButtonClicked("Register");
            };
        }

        private void ButtonClicked(string id)
        {
            if(string.Equals(id, "Login"))
            {
                //getting the username and password details
                EditText username = FindViewById<EditText>(Resource.Id.Username);
                EditText password = FindViewById<EditText>(Resource.Id.Password);

                string usernameValue = username.Text;
                string passwordValue = password.Text;

                Toast.MakeText(Application.Context,
                "Username =  " + usernameValue + " password = " + passwordValue,
                ToastLength.Short).Show();
            }
            else if (string.Equals(id, "Register"))
            {
                // start the register page
                 Intent RegisterActivity = new Intent(this, typeof(Register));
                StartActivity(RegisterActivity);
            }
                
        }

    }
}