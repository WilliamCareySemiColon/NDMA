using System;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace NDMA.Resources
{
    /******************************************************************************************************************************************
     *The activity to allow the user to login into the application for the first time by registering for the application
     *****************************************************************************************************************************************/
    [Activity(Label = "Register")]
    public class Register : Activity
    {
        //the strings and ids to properly capture the strings and ids of the dropdowns for the page
        private String GenderText = null, AgeText = null;
        //private Int32 AgeCatId, SexCatId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Register);

            //age category details spinner
            Spinner ageCategory = FindViewById<Spinner>(Resource.Id.AgeCategory);
            ageCategory.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_ItemSelected);
            ArrayAdapter ageCategoryAdapter = ArrayAdapter.CreateFromResource(this,
                Resource.Array.AgeCategory, Android.Resource.Layout.SimpleSpinnerItem);
            ageCategoryAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            ageCategory.Adapter = ageCategoryAdapter;
            //AgeCatId = ageCategory.Id;
            //sex category details
            Spinner sexCategory = FindViewById<Spinner>(Resource.Id.SexCategory);
            sexCategory.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_ItemSelected2);
            ArrayAdapter sexCategoryAdpater = ArrayAdapter.CreateFromResource(this,
                Resource.Array.SexCategory, Android.Resource.Layout.SimpleSpinnerItem);
            sexCategoryAdpater.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            sexCategory.Adapter = sexCategoryAdpater;
            //SexCatId = sexCategory.Id;
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
        //get the string from either of the dropdoowns for the age category and sex category 
        //and assigning them to the stings GenderText and AgeText
        private void Spinner_ItemSelected(Object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var spinner = sender as Spinner;
            AgeText = string.Equals(
                spinner.GetItemAtPosition(e.Position).ToString(),
                "Age Category", StringComparison.CurrentCulture) ?
                null: spinner.GetItemAtPosition(e.Position).ToString();
        }

        private void Spinner_ItemSelected2(Object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var spinner = sender as Spinner;

            GenderText = string.Equals(
                spinner.GetItemAtPosition(e.Position).ToString(),
                "Sex Category", StringComparison.CurrentCulture) ?
                null : spinner.GetItemAtPosition(e.Position).ToString();
        }

        //The method when the register and login button are pressed
        private void ButtonClicked(string id)
        {
            //If the login button is clicked, redirect to the login page
            if (string.Equals(id, "Login"))
            {
                Intent LoginActivity = new Intent(this, typeof(UserLogin));
                StartActivity(LoginActivity);
            }
            //if the register page is clicked, make sure all the fields have been entered correctly before registering the user
            else if (string.Equals(id, "Register"))
            {
                var stringToPassToDB = GatherContents();

                if(stringToPassToDB != null) {
                    Toast.MakeText(Application.Context, "Welcome to the application", ToastLength.Short).Show();
                    Intent HomeActivity = new Intent(this, typeof(Home));
                    StartActivity(HomeActivity);
                } 
            }
        }

        //The test for all the string crediatls to ensure all the details are correct
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

            var flag = true;

            if(String.Equals(nameText, "") || nameText.Length < 2)
            {
                Toast.MakeText(this, "name is in the incorrect format", ToastLength.Short).Show();
                flag = false;
            }

            if(String.Equals(usernameText, "") || usernameText.Length < 4)
            {
                Toast.MakeText(this, "Username is in the incorrect format", ToastLength.Short).Show();
                flag = false;
            }

            if (String.Equals(emailText, "") || (!match.Success))
            {
                Toast.MakeText(this, "Email is in the incorrect format", ToastLength.Short).Show();
                flag = false;
            }

            if (String.Equals(passText, "") || passText.Length < 4)
            {
                Toast.MakeText(this, "password is in the incorrect format", ToastLength.Short).Show();
                flag = false;
            }

            if (!String.Equals(conPassText, passText))
            {
                Toast.MakeText(this, "confirm password and password are not the same", ToastLength.Short).Show();
                flag = false;
            }

            if (GenderText == null)
            {
                Toast.MakeText(this, "Gender needs to be selected", ToastLength.Short).Show();
                flag = false;
            }

            if (AgeText == null)
            {
                Toast.MakeText(this, "Age needs to be selected", ToastLength.Short).Show();
                flag = false;
            }

            if(flag)
            {
                return new string[] { nameText, usernameText, emailText, passText };
            } else {
                return null;
            }

        }//end GatherContents
    }
}