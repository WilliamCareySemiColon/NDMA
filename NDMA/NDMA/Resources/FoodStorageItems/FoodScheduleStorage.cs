using System;
using System.Collections.Generic;

namespace NDMA.Resources.FoodStorageItems
{
    /***********************************************************************************************************************
     * The schdeule part of the applocation used to track the food from the loggin perspective itself - the name and postion
     * of the food storage items are tracked here, as well as what aspect of the application is getting tracked itself
     **********************************************************************************************************************/
    public static class FoodScheduleStorage
    {
        public static String[] Template;

        public static Dictionary<String, int> ScheduleTrack;

        public static String[] FoodItemNamesStorage;

        public static String ScheduleID { get; set; }
        public static String SuccesfullyLogged { get; set; }
    }
}