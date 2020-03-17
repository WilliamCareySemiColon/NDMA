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
using NDMA.Resources.JsonLoggedFood;

namespace NDMA.Resources.AdvisorActivities.FoodStorageForTestData
{
    public static class FoodStorage
    {
        public static ParsedFoodCollection food { get; set; }
        public static DBFood DBFood { get; set; }
    }
}