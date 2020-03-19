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

        public static Substance Carbohydrates = new Substance("130g", 
                new string[] { "milk", "grains", "fruits", "vegetables" });

        public static Substance Protein =  new Substance("56g", "46g", 
            new string[] { "meats", "fish", "legumes (pulses and lentils)", "nuts", "milk", "cheeses", "eggs" });

        public static Substance Fiber = new Substance("38g", "25g", 
            new string[] { "barley", "bulgur", "rolled oats", "legumes", "nuts", "beans", "apples" });

        public static Substance Cholesterol = new Substance("300mg", 
            new string[] { "chicken giblets", "turkey giblets", "beef liver", "egg yolk" });

        public static CalculatedSubtance Fat = new CalculatedSubtance("20", "35", 
            new string[] { "oils", "butter", "lard", "nuts", "seeds", "fatty meat cuts", "egg yolk", "cheeses" });

        public static CalculatedSubtance Sugar = new CalculatedSubtance("25",  
            new string[] { "sweets", "cookies", "cakes", "jams", "energy and soda drinks" });

    }
}