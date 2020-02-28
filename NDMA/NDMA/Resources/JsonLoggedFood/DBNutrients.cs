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
    class DBNutrients
    {
        //public float ENERC_KCAL { get; set; }
        //public float PROCNT { get; set;}
        //public float Fat { get; set; }
        //public float CHOCDF { get; set; }
        //public float FIBTG { get; set; }

        public String label { get; set; }
        public String Image { get; set; }
        public String Source { get; set; }
        public String Url { get; set; }
        public List<String> DietLabels { get; set; }
        public List<String> HealthLabels { get; set; }
        public float Calories { get; set; }
        public float TotalWeight { get; set; }
        public List<Ingredient> Ingredients { get; set; }

    }
}