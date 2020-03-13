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

namespace NDMA.Resources.JsonLoggedFood
{
    public class DBNutrients
    {
        public String label { get; set; }
        public String Image { get; set; }
        public String Source { get; set; }
        public String Url { get; set; }
        public List<String> DietLabels { get; set; }
        public List<String> HealthLabels { get; set; }
        public float Calories { get; set; }
        public float TotalWeight { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public TotalOverallNutrients TotalNutrients { get; set; }

    }
}