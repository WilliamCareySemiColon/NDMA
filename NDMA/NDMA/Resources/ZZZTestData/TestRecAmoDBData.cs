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

namespace NDMA.Resources.ZZZTestData
{
    public static class TestRecAmoDBData
    {
        public static Substance Water = new Substance("3.7L", "2.7L",
                new string[] { "water", "watermelon", "iceberg lettuce" });

        /*******************************************************************************
         * The Dietary Guidelines for Americans recommends that carbohydrates 
         * make up 45 to 65 percent of your total daily calories. 
         * So, if you get 2,000 calories a day, between 900 and 1,300 calories should be 
         * from carbohydrates. 
         * That translates to between 225 and 325 grams of carbohydrates a day
         *******************************************************************************/

        public static Substance Carbohydrates = new Substance("325g", 
                new string[] { "milk", "grains", "fruits", "vegetables" });

        /*************************************************************************************************
         * In a healthy diet, about 12 to 20 percent of your total daily calories should come from protein. 
         * Your body needs protein for growth, maintenance, and energy. Protein can also be stored and is 
         * used mostly by your muscles. Your body changes about 60 percent of protein into glucose.
         ******************************************************************************************* */

        public static Substance Protein =  new Substance("56g", "46g", 
            new string[] { "meats", "fish", "legumes (pulses and lentils)", "nuts", "milk", "cheeses", "eggs" });

        public static Substance Fiber = new Substance("38g", "25g", 
            new string[] { "barley", "bulgur", "rolled oats", "legumes", "nuts", "beans", "apples" });

        public static Substance Cholesterol = new Substance("300mg", 
            new string[] { "chicken giblets", "turkey giblets", "beef liver", "egg yolk" });

        /***********************************************************************************
         *Fat has the most calories of all the nutrients: 9 calories per gram. 
         * In a healthy diet, about 30 percent of total daily calories should come from fat. 
         * This means eating about 50 to 80 grams of fat each day. 
         *********************************************************************************/

        public static CalculatedSubtance Fat = new CalculatedSubtance("20", "35", 
            new string[] { "oils", "butter", "lard", "nuts", "seeds", "fatty meat cuts", "egg yolk", "cheeses" });

        public static CalculatedSubtance Sugar = new CalculatedSubtance("25",  
            new string[] { "sweets", "cookies", "cakes", "jams", "energy and soda drinks" });

    }
}