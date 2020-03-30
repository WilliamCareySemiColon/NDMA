using NDMA.Resources.JsonLoggedFood;

namespace NDMA.Resources.FoodStorage
{
    public static class FoodStorageItems
    {
        /******************************************************************************************************
         * The static class to actually store the food contents itself that is fetched from the Ednamam Api
         ****************************************************************************************************/
        public static ParsedFoodCollection food { get; set; }
        public static DBFood DBFood { get; set; }
    }
}