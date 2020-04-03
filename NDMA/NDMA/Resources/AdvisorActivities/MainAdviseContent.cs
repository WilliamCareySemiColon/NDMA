using System;

using Android.App;
using Android.OS;
using Android.Widget;
using NDMA.Resources.NutritionalAdvisors;
using NDMA.TestStaticData;

namespace NDMA.Resources.AdvisorActivities
{
    [Activity(Label = "MainAdviseContent")]
    public class MainAdviseContent : Activity
    {
        /****************************************************************************************************
         * The activity that is used to display the advise of the user regarding their calorie intake
         ***************************************************************************************************/
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.UserAdviseMainLayout);

            TextView header = FindViewById<TextView>(Resource.Id.HeaderMainAdvise);
            header.Text = "Main advise contents";

            //used test sample data
            //string[] Sm = new string[] { "Sample", "Sample",
            //    "Sample", "Sample","Sample"};

            //string[] Sm2 = new string[] {"Sample","Sample",
            //    "Sample","Sample","Sample"};

            //ListView list = FindViewById<ListView>(Resource.Id.AdviseFoodListView);
            //AdvisorAdapter arrayAdapter2 = new AdvisorAdapter(this, Sm, Sm2);
            //list.Adapter = arrayAdapter2;

            TextView adviseText = FindViewById<TextView>(Resource.Id.AdviseParagraph);

            if (FoodStorageItems.StaticFoodCollection.StoredFood.Count != 0) {

                var elements = NutrionalAdvisor.GetCaloriesAdvise(FoodStorageItems.StaticFoodCollection.StoredFood, this);
                var WaterElement = NutrionalAdvisor.GetWaterAdvice();
                var FatElement = NutrionalAdvisor.GetFatAdvice();
                var ProteinElement = NutrionalAdvisor.GetProteinAdvice();
                var CarbElement = NutrionalAdvisor.GetCarb();

                //appending the calorie contents
                if (elements.Length == 1){
                    adviseText.Text += elements[0] + "\n\n";
                } else {
                    adviseText.Text += elements[0] + "\n\n Amount Comsumed: " + NutrionalAdvisor.GetStaticCalories() 
                        + "\n Amount recommended on personal status: " + NutrionalAdvisor.GetRecommendedAmount()
                        + "\n\nDescription \n" + elements[1];
                    if (String.Equals(elements[0], "Obesity"))
                    {
                        ImageView image = FindViewById<ImageView>(Resource.Id.AdvisePhoto);
                        image.SetImageBitmap(StaticDataModel.Obesity.GetImage());
                    } else {
                        ImageView image = FindViewById<ImageView>(Resource.Id.AdvisePhoto);
                        image.SetImageBitmap(StaticDataModel.Underweight.GetImage());
                    }
                }
                //appending the water content
                if(WaterElement.Length == 1){
                    adviseText.Text += "\n\n" + WaterElement[0] + "\n\n";
                } else {
                    adviseText.Text +="\n\n" + WaterElement[0] + "\n\n Amount Comsumed: " + NutrionalAdvisor.GetStaticWater()
                        + "\n Amount recommended on personal status: " + NutrionalAdvisor.GetRecommendedWaterAmount()
                        + "\n\n" + WaterElement[1];
                }
                //appending the fat content
                if(FatElement != null)
                {
                    adviseText.Text += "\n\n" + FatElement[0] + "\n\n Amount Comsumed: " + NutrionalAdvisor.GetStaticFat()
                       + "\n Amount recommended on personal status: " + NutrionalAdvisor.GetRecommendedFatAmount()
                       + "\n\nDescription \n" + FatElement[1];
                } else {

                    adviseText.Text += "\n\n Fat Amount\n\n Amount Comsumed: " + NutrionalAdvisor.GetStaticFat()
                       + "\n Amount recommended on personal status: " + NutrionalAdvisor.GetRecommendedFatAmount()
                       + "\n\n";
                }

                //appending the protein
                if (ProteinElement != null)
                {
                    adviseText.Text += "\n\n" + ProteinElement[0] + "\n\n Amount Comsumed: " + NutrionalAdvisor.GetStaticProtein()
                       + "\n Amount recommended on personal status: " + NutrionalAdvisor.GetRecommendedProteinAmount()
                       + "\n\nDescription \n" + ProteinElement[1];
                } else {

                    adviseText.Text += "\n\n Protein Amount\n\n Amount Comsumed: " + NutrionalAdvisor.GetStaticProtein()
                       + "\n Amount recommended on personal status: " + NutrionalAdvisor.GetRecommendedProteinAmount()
                       + "\n\n";
                }
                if(CarbElement != null)
                {
                    adviseText.Text += "\n\n" + CarbElement[0] + "\n\n Amount Comsumed: " + NutrionalAdvisor.GetStaticCarbs()
                       + "\n Amount recommended on personal status: " + NutrionalAdvisor.GetRecommendedCarbAmount()
                       + "\n\nDescription \n" + CarbElement[1];
                } else {

                    adviseText.Text += "\n\n Carb Amount\n\n Amount Comsumed: " + NutrionalAdvisor.GetStaticCarbs()
                       + "\n Amount recommended on personal status: " + NutrionalAdvisor.GetRecommendedCarbAmount()
                       + "\n\n";
                }
            }
            else {
                adviseText.Text = "There is no advise to be made at this current of time as no food has been current logged for the application";
            }

            Button button = FindViewById<Button>(Resource.Id.AdviseReturnBtn);
            button.Click += delegate { Finish(); };
        }//end onCreate
    }
}