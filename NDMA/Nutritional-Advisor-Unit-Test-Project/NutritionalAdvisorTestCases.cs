using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDMA.Resources.JsonLoggedFood;
using NDMA.Resources.NutritionalAdvisors;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;

namespace Nutritional_Advisor_Unit_Test_Project
{
    /**************************************************************************************************************************
     * The unit tests that takes inout from the search api and runs it against the nutritional advisor system itself
     **************************************************************************************************************************/
    [TestClass]
    public class NutritionalAdvisorTestCases
    {
        //Recipe search api - to allow the test 
        private readonly string[] RecipeSearchApCreds = new string[] {
                "c570405e", "14793a0482c121e16b365ac4ff89cb1e" };

        ParsedFoodCollection items;
        [TestMethod]
        public void TestNutrionalAdvisor_TestItemsCollectionInitally_Pass()
        {
            //arrange
            items = null;

            //act
            GetSampleItems();

            while (items == null) ;

            var ListCollection = items.GetList();

            //assert
            Assert.IsNotNull(ListCollection, "Method is taking too long to complie and return result");
        }

        [TestMethod]
        public void TestNutrionalAdvisor_TestFoodCollectionCaloriesVsRecommendedAreDifferent_Pass()
        {
            //arrange
            items = null;

            //act
            GetSampleItems();

            while (items == null) ;

            var ListCollection = items.GetList();
            var amount = NutrionalAdvisor.GetCalorieCount(ListCollection);

            var amount2 = NutrionalAdvisor.GetRecommendedAmount();

            //assert
            Assert.AreNotEqual(amount, amount2, "The recommendation system cannot analyise the system properly due to internal errors");
        }

        [TestMethod]
        public void TestNutrionalAdvisor_TestFoodCollectionCaloriesToEnsureTheContentPassThrough_Pass()
        {
            items = null;

            //arrange
            GetSampleItems();

            while (items == null) ;

            //act
            var ListCollection = items.GetList();
            var amount = NutrionalAdvisor.GetCalorieCount(ListCollection);

            var amount2 = NutrionalAdvisor.GetStaticCalories();

            //assert
            Assert.AreEqual(amount, amount2, "The recommendation system could not process the calories properly due to internal errors");
        }

        //method to assist the tester methods
        private async void GetSampleItems()
        {
            //Recipe search api - using apple as a example
            var client = new HttpClient();
            int from = 0, to = 10;
            string url = "https://api.edamam.com/search?q=apple&app_id=" + RecipeSearchApCreds[0] + "&app_key="
                + RecipeSearchApCreds[1] + "&from=" + from + "&to=" + to;
            try
            {
                var uri = new Uri(url);
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();

                items = JsonConvert.DeserializeObject<ParsedFoodCollection>(json);
            }
            catch (Exception)
            { //
            }
        }
    }
}
