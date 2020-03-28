using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private String GenderText = null, AgeText = null;
        private Int32 AgeCatId, SexCatId;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Register);

            //age category details
            Spinner ageCategory = FindViewById<Spinner>(Resource.Id.AgeCategory);
            ageCategory.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_ItemSelected);
            ArrayAdapter ageCategoryAdapter = ArrayAdapter.CreateFromResource(this,
                Resource.Array.AgeCategory, Android.Resource.Layout.SimpleSpinnerItem);
            ageCategoryAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            ageCategory.Adapter = ageCategoryAdapter;
            AgeCatId = ageCategory.Id;
            //sex category details
            Spinner sexCategory = FindViewById<Spinner>(Resource.Id.SexCategory);
            sexCategory.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_ItemSelected);
            ArrayAdapter sexCategoryAdpater = ArrayAdapter.CreateFromResource(this,
                Resource.Array.SexCategory, Android.Resource.Layout.SimpleSpinnerItem);
            sexCategoryAdpater.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            sexCategory.Adapter = sexCategoryAdpater;
            SexCatId = sexCategory.Id;
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

        private void Spinner_ItemSelected(Object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var spinner = sender as Spinner;
            var id = spinner.Id;

            if(id == AgeCatId)
            {
                GenderText = string.Equals(
                    spinner.GetItemAtPosition(e.Position).ToString(),
                    "Age Category", StringComparison.CurrentCulture) ?
                    spinner.GetItemAtPosition(e.Position).ToString() : null;
            }
            else if (id == SexCatId)
            {
                AgeText = string.Equals(
                    spinner.GetItemAtPosition(e.Position).ToString(), 
                    "Sex Category", StringComparison.CurrentCulture) ?
                    spinner.GetItemAtPosition(e.Position).ToString() : null;
            }
            //if (!(string.Equals(spinner.GetItemAtPosition(e.Position).ToString(), "Age Category", StringComparison.CurrentCulture)
            //    || string.Equals(spinner.GetItemAtPosition(e.Position).ToString(), "Sex Category", StringComparison.CurrentCulture)))
            //{
            //    Toast.MakeText(Application.Context,
            //    //"You choice the item " + spinner.GetItemAtPosition(e.Position),
            //    "The spinner clicked has the id of " + id,
            //    ToastLength.Short).Show();
            //}
        }

        private void ButtonClicked(string id)
        {
            if (string.Equals(id, "Login"))
            {
                Intent LoginActivity = new Intent(this, typeof(UserLogin));
                StartActivity(LoginActivity);
            }

            else if (string.Equals(id, "Register"))
            {
                
                var stringToPassToDB = GatherContents();

                if(stringToPassToDB != null)
                {
                    // Intent HomeActivity = new Intent(this, typeof(Home));
                    // StartActivity(HomeActivity);
                }
                else
                {
                    Toast.MakeText(this, "all the fields needs to be filled in correct", ToastLength.Short).Show();
                }
            }
        }

        private String [] GatherContents()
        {
            EditText name = FindViewById<EditText>(Resource.Id.Name);
            EditText username = FindViewById<EditText>(Resource.Id.Username);
            EditText email = FindViewById<EditText>(Resource.Id.Email);
            EditText password = FindViewById<EditText>(Resource.Id.Password);
            EditText Confirmpassword = FindViewById<EditText>(Resource.Id.ConfirmPassword);

            var nameText = name.Text;
            var usernameText = username.Text;
            var emailText = email.Text;
            var passText = password.Text;
            var conPassText = Confirmpassword.Text;

            //regex expression to confirm email address
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailText);

            if ((!(String.Equals(nameText, "") && String.Equals(usernameText, "") &&
                 String.Equals(emailText, "") && String.Equals(passText, "") &&
                 String.Equals(conPassText, "")))&& String.Equals(passText, conPassText)
                 && GenderText != null && AgeText != null
                 && match.Success
                 )
            {
                return new string[] { nameText, usernameText, emailText, passText };
                Toast.MakeText(this, "success", ToastLength.Short).Show();
            }
            else
            {
                return null;
            }

        }
    }
}