using System;
using System.Collections.Generic;

using Android.App;
using NDMA.Resources.JsonLoggedFood;
using NDMA.Resources.ZZZTestData;
using NDMA.TestStaticData;

namespace NDMA.Resources.NutritionalAdvisors
{
    /***************************************************************************************************************
     * The static class to provide the feedback to the user by getting the food data and analysising
     * 
     * This version of the application is analysising the macnutrients and calories section
     ***************************************************************************************************************/
    public static class NutrionalAdvisor
    {
        //the calorie count
        private static double calAmount = 0;
        //the macronutrients variables
        private static double carbAmount = 0;
        private static double waterAmount = 0;
        private static double fatAmount = 0;
        private static double proteinAmount = 0;
        private static double fiberAmount = 0;

        //getting the static contents and assigning them to their variables
        public static double GetCalorieCount(List<DBFood> dBFoodCollection) {
            double cal = 0;

            foreach (DBFood food in dBFoodCollection) {
                var nutritionCollection = food.Recipe.TotalNutrients;
                //capture the calorie amount
                cal += nutritionCollection.ENERC_KCAL.quantity;
                //capture the carb amount
                carbAmount += nutritionCollection.CHOCDF.quantity;
                //capture the water amount 
                waterAmount += nutritionCollection.WATER.quantity;
                //capture the fat amount
                fatAmount += nutritionCollection.FAT.quantity;
                //capture the protein amount
                proteinAmount += nutritionCollection.PROCNT.quantity;
                //capture the fiberAmount
                fiberAmount += nutritionCollection.FIBTG.quantity;
            }

            calAmount = cal;

            return cal;
        }

        //getting access to each static content from the advisor
        public static double GetStaticCalories(){
            return calAmount;
        }

        public static double GetStaticCarbs(){
            return carbAmount;
        }

        public static double GetStaticWater(){
            return waterAmount;
        }

        public static double GetStaticFat(){
            return fatAmount;
        }

        public static double GetStaticProtein(){
            return proteinAmount;
        }

        public static double GetStaticFiber(){
            return fiberAmount;
        }

        //getting the recommended amount of contents from the user
        public static float GetRecommendedAmount(){
            return TestSampleData.Calories;
        }

        public static float GetRecommendedWaterAmount() {
            var waterString = TestRecAmoDBData.Water.AmountMale;

            var newWaterString = waterString.Remove(waterString.Length - 1, 1);

            return ((float.Parse(newWaterString)) * 1000);
        }

        public static float GetRecommendedCarbAmount(){
            var carbString = TestRecAmoDBData.Carbohydrates.AmountMale;

            var parsedcarbString = carbString.Remove(carbString.Length - 1, 1);

            return float.Parse(parsedcarbString);
        }

        public static float GetRecommendedProteinAmount(){
            var proteinString = TestRecAmoDBData.Protein.AmountMale;

            var parseProteinString = proteinString.Remove(proteinString.Length - 1, 1);

            return float.Parse(parseProteinString);
        }

        public static float GetRecommendedFatAmount(){
            float FatPercentage = float.Parse(TestRecAmoDBData.Fat.MaxPercentage);

            return (TestSampleData.Calories * (FatPercentage / 100));
        }

        public static float GetRecommendedFiberAmount(){
            var fiberString = TestRecAmoDBData.Fiber.AmountMale;

            var parseFiberString = fiberString.Remove(fiberString.Length - 1, 1);

            return float.Parse(parseFiberString);
        }

        //methods to get the calorie advise - connects to test data itself
        public static String [] GetCalorieAdvise(double cal){
            String[] message;
            if (cal > TestSampleData.Calories)
            {
                var modelspec = StaticDataModel.Obesity;

                message = new string[]
                {
                    modelspec.GetName(),
                    modelspec.GetDescription(),
                    modelspec.GetImage().ToString()
                };

                return message;
            }
            else if (cal < TestSampleData.MinCalories)
            {
                var modelspec = StaticDataModel.Underweight;

                message = new string[]
                {
                    modelspec.GetName(),
                    modelspec.GetDescription(),
                    modelspec.GetImage().ToString()
                };

                return message;
            }
            else
            {
                return new string[] { "Amount of calories comsuned within acceptable paramters" };
            }
        }
        //test method to connect the advisor page to the actual advisor
        public static String [] GetCaloriesAdvise(List<DBFood> dBFoodCollection, Activity context)
        {
            double cal = GetCalorieCount(dBFoodCollection);

            var message = GetCalorieAdvise(cal);

            return message;
           
        }

        /***********************************************************************************************************
         * If time permits, construct advice for all the macronutrients itself
         ***********************************************************************************************************/

        public static string[] GetWaterAdvice()
        {
            if(GetStaticWater() > GetRecommendedAmount())
            {
                var element = StaticDataModel.WaterToxication;

                return new string[]
                {
                   element.GetName(),
                    element.GetDescription()
                };
            }
            else if (GetStaticWater() < GetRecommendedAmount())
            {
                var element = StaticDataModel.WaterDefieicent;

                return new string[]
                {
                   element.GetName(),
                    element.GetDescription()
                };
            } else {
                return new string[] { "Water amount is in the correct amount" };
            }
        }

        public static string [] GetCarb()
        {
            if(GetStaticCarbs() < GetRecommendedCarbAmount())
            {
                var element = StaticDataModel.Carbs;
                return new string[]
                {
                    element.GetName(),
                    element.GetDescription()
                };
            }
            else {
                return null;
            }
        }

        public static string[] GetProteinAdvice()
        {
            if(GetStaticProtein() < GetRecommendedProteinAmount())
            {
                var element = StaticDataModel.ProteinDeficient;
                return new string[]
                {
                    element.GetName(),
                    element.GetDescription()
                };
            }
            else
            {
                return null;
            }
        }

        public static string [] GetFatAdvice()
        {
            if (GetStaticFat() < GetRecommendedFatAmount())
            {
                var element = StaticDataModel.FatDefieicent;
                return new string[]
                {
                    element.GetName(),
                    element.GetDescription()
                };
            }
            else
            {
                return null;
            }
        }

        /************************************************************************************************************
         * Part of the development process was to get the food list, find which prouducts are either overcomsumed
         * or underconsumed, append them to a list and return that list. Due to changes in development plans, these
         * methods are not used (the main reason for changes in development plans was lack of time alongside the 
         * need of a more clear layout)
         **********************************************************************************************************/
        public static int GetOverConsumedProducts(List<DBFood> dBFoodCollection) {
            double cal = 0, fat = 0, fasat = 0, chocdf = 0, fibig = 0, sugar = 0, protein = 0, water = 0;
            foreach (DBFood food in dBFoodCollection) {
                var foodIn = food.Recipe.TotalNutrients;

                cal += foodIn.ENERC_KCAL.quantity;
                fat += foodIn.FAT.quantity;
                fasat += foodIn.FASAT.quantity;
                chocdf += foodIn.CHOCDF.quantity;
                fibig += foodIn.FIBTG.quantity;
                sugar += foodIn.SUGAR.quantity;
                protein += foodIn.PROCNT.quantity;
                water += foodIn.WATER.quantity;
            }
            //going over each of the variables to find the over consumed food
            List<double> OverComsumedfood = new List<double>();

            //calories
            if(cal > TestSampleData.Calories) {
                OverComsumedfood.Add(cal);
            }
            //fat - going through percentage rather then direct value
            float FatPercentage = float.Parse(TestRecAmoDBData.Fat.MaxPercentage);
            if(fat > (TestSampleData.Calories * (FatPercentage / 100))){
                OverComsumedfood.Add(fat);
            }
            //carbs
            float Carb = float.Parse(
                TestRecAmoDBData.Carbohydrates.AmountMale.Remove(
                    TestRecAmoDBData.Carbohydrates.AmountMale.Length - 1,1
                    )
                );
            if (chocdf > Carb) {
                OverComsumedfood.Add(chocdf);
            }
            //protein
            float proteinInput = float.Parse(
                TestRecAmoDBData.Protein.AmountMale.Remove(
                    TestRecAmoDBData.Protein.AmountMale.Length - 1, 1
                    )
                );
            if (protein > proteinInput) {
                OverComsumedfood.Add(protein);
            }
            //water
            float waterInput = float.Parse(
                 TestRecAmoDBData.Water.AmountMale.Remove(
                     TestRecAmoDBData.Water.AmountMale.Length - 1, 1
                     )
                 );

            if(water > waterInput) {
                if (protein > proteinInput){
                    OverComsumedfood.Add(protein);
                }
            }

            //return data
            return OverComsumedfood.Count;
        }

        //actually methods for the three main pages
        public static int GetUnderConsumedProducts(List<DBFood> dBFoodCollection) {
            double cal = 0, fat = 0, fasat = 0, chocdf = 0, fibig = 0, sugar = 0, protein = 0, water = 0;
            foreach (DBFood food in dBFoodCollection) {
                var foodIn = food.Recipe.TotalNutrients;

                cal += foodIn.ENERC_KCAL.quantity;
                fat += foodIn.FAT.quantity;
                fasat += foodIn.FASAT.quantity;
                chocdf += foodIn.CHOCDF.quantity;
                fibig += foodIn.FIBTG.quantity;
                sugar += foodIn.SUGAR.quantity;
                protein += foodIn.PROCNT.quantity;
                water += foodIn.WATER.quantity;
            }
            //going over each of the variables to find the over consumed food
            List<double> UnderComsumedfood = new List<double>();
            //calories
            if (cal < TestSampleData.MinCalories){
                UnderComsumedfood.Add(cal);
            }
            //fat - going through percentage rather then direct value
            float FatPercentage = float.Parse(TestRecAmoDBData.Fat.MinPercentage);
            if (fat < (TestSampleData.Calories * (FatPercentage / 100))){
                UnderComsumedfood.Add(fat);
            }
            //carbs
            float Carb = float.Parse(
                TestRecAmoDBData.Carbohydrates.AmountMale.Remove(
                    TestRecAmoDBData.Carbohydrates.AmountMale.Length - 1, 1
                    )
                );
            if (chocdf < Carb){
                UnderComsumedfood.Add(chocdf);
            }
            //protein
            float proteinInput = float.Parse(
                TestRecAmoDBData.Protein.AmountMale.Remove(
                    TestRecAmoDBData.Protein.AmountMale.Length - 1, 1
                    )
                );
            if (protein < proteinInput){
                UnderComsumedfood.Add(protein);
            }
            //water
            float waterInput = float.Parse(
                 TestRecAmoDBData.Water.AmountMale.Remove(
                     TestRecAmoDBData.Water.AmountMale.Length - 1, 1
                     )
                 );

            if (water < waterInput){
                if (protein > proteinInput)
                {
                    UnderComsumedfood.Add(protein);
                }
            }

            //return data
            return UnderComsumedfood.Count;
        }//GetUnderConsumedProducts end

    }
}