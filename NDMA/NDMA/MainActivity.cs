using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using NDMA.Resources;

namespace NDMA
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //connecting the buttons to the approaite handlers
            Button Register = FindViewById<Button>(Resource.Id.Register);
            Button Login = FindViewById<Button>(Resource.Id.Login);

            Login.Click += delegate
            {
                ButtonClicked("Login");
            };

            Register.Click += delegate
            {
                ButtonClicked("Register");
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void ButtonClicked(string id)
        {
            if(string.Equals(id, "Login"))
            {
                //switching to the the login page
                Intent LoginActivity = new Intent(this, typeof(Login));
                StartActivity(LoginActivity);
            }
            else if(string.Equals(id, "Register"))
            {
                //start the register page
                Intent RegisterActivity = new Intent(this, typeof(Register));
                StartActivity(RegisterActivity);
            }
        }
    }
}