﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NDMA.Resources.FoodStorageItems
{
    public static class FoodScheduleStorage
    {
        public static String[] Template;
        public static List<String> FoodItemNamesStorage { get; set; }
        public static String ScheduleID { get; set; }
        public static String SuccesfullyLogged { get; set; }
    }
}