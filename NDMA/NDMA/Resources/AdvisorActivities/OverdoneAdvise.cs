
using Android.App;
using Android.OS;

namespace NDMA.Resources.AdvisorActivities
{
    [Activity(Label = "OverdoneAdvise")]
    public class OverdoneAdvise : Activity
    {
        /**********************************************************************************************
         * The activity to display to the user the food contents that they displayed which they 
         * overconsumed on - this activity is not being used
         ********************************************************************************************/
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.UserAdviseMainLayout);

            //TextView header = FindViewById<TextView>(Resource.Id.HeaderMainAdvise);
            //header.Text = "Overdone advise contents";

            string[] Sm = new string[] { "Sample",
                "Sample","Sample","Sample","Sample"
            };

            string[] Sm2 = new string[] { "Sample",
                "Sample","Sample","Sample","Sample"
           };

            //ListView list = FindViewById<ListView>(Resource.Id.AdviseFoodListView);
            //AdvisorAdapter arrayAdapter2 = new AdvisorAdapter(this, Sm, Sm2);
            //list.Adapter = arrayAdapter2;

            //Button button = FindViewById<Button>(Resource.Id.AdviseReturnBtn);
            //button.Click += delegate { Finish(); };
        }
    }
}