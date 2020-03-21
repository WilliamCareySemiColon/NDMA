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
using NDMA.TestStaticData.FoodAndDiet;
using NDMA.TestStaticData.NutitionalDifficulty;

namespace NDMA.TestStaticData
{
    class StaticDataModel
    {
        //setting the nutrional disease
        public static NutritionslDifficulty Obesity =new NutritionslDifficulty("Obesity", 
            "Obesity is when a person is carrying too much body fat for their height and sex. " +
            "A person is considered obese if they have a body mass index (BMI) of 30 or greater. Today's way of life is less physically" +
            " active than it used to be. People travel on buses and cars, rather than walking, and many people work in offices, where they are " +
            "sitting still for most of the day. This means that the calories they eat are not getting burnt off as energy. Instead, the " +
            "extra calories are stored as fat. Over time, eating excess calories leads to weight gain.Without lifestyle changes to " +
            "increase the amount of physical activity done on a daily basis, or reduce the amount of calories consumed, people can become obese.",
            GetImageBitmapFromUrl("https://i2-prod.mirror.co.uk/incoming/article2036874.ece/ALTERNATES/s1200b/fat-overweight.jpg"));

        public static NutritionslDifficulty Underweight = new NutritionslDifficulty("Underweight",
           "For example, do veiny arms mean you're underweight? Some people who are very thin complain about veiny arms. " +
            "But bodybuilders have veiny arms, as well. So veiny arms, alone, aren't necessarily an indicator that you are too thin." +
            "Other people complain about joints that look too large.If you are underweight and carry very little muscle mass, your bones " +
            "and your joints may appear more prominent.But again, having large bones or a more noticeable joint doesn't mean that you are " +
            "definitely underweight. Other symptoms of being underweight may include problems due to malnutrition: Fragile bones " +
            "Irregular menstrual periods or problems getting pregnant Hair loss Weak immune system Dizziness or fatigue from anemia " +
            "Poor growth and development, especially in children who are underweight",
           GetImageBitmapFromUrl("https://www.naturalremedies.org/images/underweight-1.jpg"));

        public static Diet Vegetarian = new Diet("Vegetarian",
            "Vegetarianism is the practice of abstaining from the consumption of meat (red meat, poultry, seafood, and the flesh of any other animal)," +
            " and may also include abstention from by-products of animal slaughter. Vegetarianism may be adopted for various reasons.Many people " +
            "object to eating meat out of respect for sentient life.Such ethical motivations have been codified under various religious beliefs," +
            " as well as animal rights advocacy.Other motivations for vegetarianism are health - related, political, environmental, cultural, " +
            "aesthetic, economic, or personal preference.",
            GetImageBitmapFromUrl("https://i0.wp.com/images-prod.healthline.com/hlcmsresource/images/AN_images/vegetarian-diet-plan-1296x728-feature.jpg?w=1155&h=1528"));

        public static FoodCategory Carbs = new FoodCategory("Carbs",
            "Carbohydrates are the sugars, starches and fibers found in fruits, grains, vegetables and milk products. " +
            "'Though often maligned in trendy diets, carbohydrates — one of the basic food groups — are important to a healthy diet. " +
            "Carbohydrates are macronutrients, meaning they are one of the three main ways the body obtains energy, or calories,'" +
            " said Paige Smathers, a Utah - based registered dietitian.The American Diabetes Association notes that carbohydrates are " +
            "the body's main source of energy. They are called carbohydrates because, at the chemical level, they contain carbon, " +
            "hydrogen and oxygen.",
            GetImageBitmapFromUrl("https://cdn.mos.cms.futurecdn.net/WbQkEjHGfKjvjSSWBqumk7-970-80.jpg"));

        //converting the url to mitmap objects for the testing of the application
        private static Android.Graphics.Bitmap GetImageBitmapFromUrl(string url)
        {
            Android.Graphics.Bitmap imageBitmap = null;

            using (var webClient = new System.Net.WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0) {
                    imageBitmap = Android.Graphics.BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
            return imageBitmap;
        }
    }
}