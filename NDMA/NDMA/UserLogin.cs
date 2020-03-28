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
using NDMA.Resources.ZZZTestData;

namespace NDMA.Resources
{
    [Activity(Label = "Login")]
    public class UserLogin : Activity
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
            if (string.Equals(id, "Login", StringComparison.CurrentCulture))
            {
                //getting the username and password details
                EditText username = FindViewById<EditText>(Resource.Id.Username);
                EditText password = FindViewById<EditText>(Resource.Id.Password);

                string usernameValue = username.Text;
                string passwordValue = password.Text;

                if(String.Equals(usernameValue, TestSampleData.Username) &&
                    String.Equals(passwordValue, TestSampleData.Password))
                {
                    Intent HomeActivity = new Intent(this, typeof(Home));
                    StartActivity(HomeActivity);
                }
                else
                {
                    Toast.MakeText(Application.Context,
                        "Username != Will190198 password != password",
                        ToastLength.Short).Show();
                }
               
            }
            else if (string.Equals(id, "Register", StringComparison.CurrentCulture))
            {
                // start the register page
                Intent RegisterActivity = new Intent(this, typeof(Register));
                StartActivity(RegisterActivity);
            }

        }

    }
}