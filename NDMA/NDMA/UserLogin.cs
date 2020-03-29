using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using NDMA.Resources.ZZZTestData;

namespace NDMA.Resources
{
    /*****************************************************************************************************************************
     * The activity to allow the user to login into the application itself
     *****************************************************************************************************************************/
    [Activity(Label = "Login")]
    public class UserLogin : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.login);

            //setting the variables for the page
            Button login = FindViewById<Button>(Resource.Id.Login);
            Button RegisterInstead = FindViewById<Button>(Resource.Id.RegisterInstead);

            //setting the handlers onto the application itself
            login.Click += delegate { ButtonClicked("Login"); };
            RegisterInstead.Click += delegate {ButtonClicked("Register"); };
        }
        //Getting the detail to the buttons on the login page
        private void ButtonClicked(string id) {
            //if the login button is clicked, make sure the crdiatials are correct before logging into the application
            if (string.Equals(id, "Login", StringComparison.CurrentCulture)) {
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
                } else {
                    //for testing purposes, the application only accepts the specific details 
                    Toast.MakeText(Application.Context, "Username != Will190198 password != password", ToastLength.Short).Show();
                }
            }
            //if the register button is clicked, redirect to the register page
            else if (string.Equals(id, "Register", StringComparison.CurrentCulture)) {
                Intent RegisterActivity = new Intent(this, typeof(Register));
                StartActivity(RegisterActivity);
            }
        }//end the button clicked method
    }
}