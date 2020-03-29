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
    [Activity(Label = "AddAdditionalIngredient")]
    public class AddAdditionalIngredient : Activity
    {
        /**********************************************************************************************************
         This class was designed to allow the user to add ingredients to the logged food to personalise it. 
         This class is not used and developed properly due to timing contraints and scope of the application
         *********************************************************************************************************/
        private string[] StringCollection = new string[] {
                "Itemz", "Itemz", "Itemz", "Itemz", "Itemz", "Itemz"
        };
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AddAdditionalIngredient);

            Button Search = FindViewById<Button>(Resource.Id.NutSearch);
            Search.Click += delegate { ButtonClicked(("Search"));};
        }

        private void ButtonClicked(String id) {
            Toast.MakeText(Application.Context, "you have pressed the button id " + id, ToastLength.Short).Show();
            ArrayAdapter listAdapter = new ArrayAdapter(Application.Context, Android.Resource.Layout.SimpleListItem1, StringCollection);
            ListView list = FindViewById<ListView>(Resource.Id.SearchFoodList);
            list.Adapter = listAdapter;
        }
    }
}