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
    public static class StaticDataModel
    {
        //setting the nutrional disease items

        //calories items
        public static NutritionslDifficulty Obesity =new NutritionslDifficulty("Obesity", 
            "Obesity is when a person is carrying too much body fat for their height and sex. " +
            "A person is considered obese if they have a body mass index (BMI) of 30 or greater. " +
            "The best thing to do would be to cut down on the high carb, high fat contents by switching to fruits",
            //"Today's way of life is less physically" +
            //" active than it used to be. People travel on buses and cars, rather than walking, and many people work in offices, where they are " +
            //"sitting still for most of the day. This means that the calories they eat are not getting burnt off as energy. Instead, the " +
            //"extra calories are stored as fat. Over time, eating excess calories leads to weight gain.Without lifestyle changes to " +
            //"increase the amount of physical activity done on a daily basis, or reduce the amount of calories consumed, people can become obese.",
            GetImageBitmapFromUrl("https://i2-prod.mirror.co.uk/incoming/article2036874.ece/ALTERNATES/s1200b/fat-overweight.jpg"));

        public static NutritionslDifficulty Underweight = new NutritionslDifficulty("Underweight",
           "For example, do veiny arms mean you're underweight? Some people who are very thin complain about veiny arms. " +
            "But bodybuilders have veiny arms, as well. So veiny arms, alone, aren't necessarily an indicator that you are too thin." +
            "Other people complain about joints that look too large.If you are underweight and carry very little muscle mass, your bones " +
            "and your joints may appear more prominent. The best thing to do is to increase the grains and fruit comsumption to" +
            " increase the daily reccoemnded amount of calories per day",
           //+
           // "But again, having large bones or a more noticeable joint doesn't mean that you are " +
           // "definitely underweight. Other symptoms of being underweight may include problems due to malnutrition: Fragile bones " +
           // "Irregular menstrual periods or problems getting pregnant Hair loss Weak immune system Dizziness or fatigue from anemia " +
           // "Poor growth and development, especially in children who are underweight",
           GetImageBitmapFromUrl("https://www.naturalremedies.org/images/underweight-1.jpg"));

        //carbs - undercomsuming
        public static NutritionslDifficulty Ketosis = new NutritionslDifficulty("NutritionslDifficulty",
            "Severely restricting carbohydrates to less than 0.7 ounces (20 grams) a day can result in a process called ketosis." +
            " Ketosis occurs when you don't have enough sugar (glucose) for energy, so your body breaks down stored fat, causing " +
            "ketones to build up in your body. Side effects from ketosis can include nausea, headache, mental and physical fatigue, " +
            "and bad breath.",
            GetImageBitmapFromUrl("https://dietmesh.com/wp-content/uploads/2019/02/How-to-Know-If-You-Are-In-Ketosis.jpg"));

        //protein
        public static NutritionslDifficulty ProteinDeficient = new NutritionslDifficulty("Protein Deficiency",
            "When protein is lacking in your diet, especially for long periods of time, it can cause you to be deficient and " +
            "potentially lead to adverse effects. Caroline Passerrello, MS, RDN, LDN, indicates inadequate protein can lead to the following:\n" +
            "Muscle Wasting – Protein is essential for muscle growth, strength, and repair.Insufficient protein in your diet reduces lean body mass, " +
            "muscle strength, and function.\n" +
            "Poor Wound Healing – Wound healing is dependent on good nutrition, including protein intake. " +
            "Protein deficiency has shown to contribute to low wound healing rates and reduced collagen formation\n" +
            "Infections – Your immune system functions best with adequate protein intake.Protein deficiency is indicated to impair " +
            "your immune system.Without a healthy immune system, your risk of infection is increased and the ability to fight off infection is decreased.",
            GetImageBitmapFromUrl("https://i.pinimg.com/originals/52/97/63/52976333d9077ab62e0346ccbf9551eb.jpg"));

        //fat
        public static NutritionslDifficulty FatDefieicent = new NutritionslDifficulty("Fat Defienct",
            "1) Heart Problems - healthy fats promote positive cardiovascular health. " +
            "Omega-3 fatty acids provide protection from hypertension, cholesterol problems and heart disease. " +
            "The lack these heart healthy fats, which raises risks for heart-related problems. " +
            "To lower your risk for heart disease, eat fatty fish, such as salmon, albacore tuna, mackerel or sardines," +
            " at least twice per week. Vegetarian omega-3 sources include flaxseeds, flaxseed oil and walnuts.\n" +
            "2) - Vitamin Deficiencies.Because fats help your body absorb and utilize the fat-soluble vitamins A, D, E and K, consuming " +
            "too little fat makes way for vitamin deficiencies. To avoid these risks, consume fat as part of a balanced diet containing a variety of healthy foods," +
            " such as fruits, vegetables, lean protein sources and whole grains. \n" +
            "3) - Excessive Appetite. Harmful effects of too little fat can also interfere with appetite control." +
            "To better manage your appetite, incorporate fat into balanced meals and snacks. Because fat sources are dense in calories, " +
            "modest portions per meal, such as 1 to 2 tablespoons of nuts or full-fat salad dressing, are typically enough.",
            GetImageBitmapFromUrl("https://www.brainkart.com/media/extra2/xdmosH3.jpg"));

        //water
        public static NutritionslDifficulty WaterDefieicent = new NutritionslDifficulty("Water Defienct",
            "Symptoms of mild to moderate dehydration include\nThirst\nReduced sweating\nReduced skin elasticity\nReduced urine production"+
            "\nDry mouth\nFor treating mild dehydration, drinking plenty of water may be all that is needed.",
            GetImageBitmapFromUrl("https://image3.slideserve.com/5649576/water-deficiency-symptoms-l.jpg"));

        public static NutritionslDifficulty WaterToxication = new NutritionslDifficulty("Water Toxication",
            "Symptoms of water intoxication tend to start appearing after you consume more than 3 to 4 L of water in a few hours.\n" +
            "Potential symptoms include:\nhead pain\ncramping, spasms, or weakness in your muscles\nnausea or vomiting\ndrowsiness and fatigue" +
            "The best action to take is reduce the amount of water consumed from the daily basis",
            GetImageBitmapFromUrl("https://images.medicaldaily.com/sites/medicaldaily.com/files/styles/full/public/2014/12/03/water_0.png"));

        //setting the diet items
        public static Diet Vegetarian = new Diet("Vegetarian",
            "Vegetarianism is the practice of abstaining from the consumption of meat (red meat, poultry, seafood, and the flesh of any other animal)," +
            " and may also include abstention from by-products of animal slaughter. Vegetarianism may be adopted for various reasons.Many people " +
            "object to eating meat out of respect for sentient life.Such ethical motivations have been codified under various religious beliefs," +
            " as well as animal rights advocacy.Other motivations for vegetarianism are health - related, political, environmental, cultural, " +
            "aesthetic, economic, or personal preference.",
            GetImageBitmapFromUrl("https://i0.wp.com/images-prod.healthline.com/hlcmsresource/images/AN_images/vegetarian-diet-plan-1296x728-feature.jpg?w=1155&h=1528"));

        //the differemt food categories
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