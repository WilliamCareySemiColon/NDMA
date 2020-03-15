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

namespace NDMA.Resources.FoodStorageItems
{
    public static class StaticFoodCollection
    {
        public static List<DBFood> StoredFood { get; set; }
    }
}