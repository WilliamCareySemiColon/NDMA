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

namespace NDMA.Resources.Adapter
{
    class FoodLayoutSpecArrayAdapter : BaseAdapter
    {

        Activity context;
        public String[] FoodItemsName, FoodItemsAmount;

        public FoodLayoutSpecArrayAdapter(Activity context, String [] FoodItemsName, String [] FoodItemsAmount) : base()
        {
            this.context = context;
            this.FoodItemsName = FoodItemsName;
            this.FoodItemsAmount = FoodItemsAmount;
        }
        public override int Count
        {
            get { return FoodItemsName.Length; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //Get our object for this position
            var itemName = FoodItemsName[position];
            var itemAmount = FoodItemsAmount[position];

            var view = (convertView ?? context.LayoutInflater.Inflate(Resource.Layout.FoodLayoutSpecListViewContents, parent, false)) as LinearLayout;

            //Find references to each subview in the list item's view
            var foodItem = view.FindViewById(Resource.Id.FoodSpecListViewItemName) as TextView;
            var foodAmount = view.FindViewById(Resource.Id.FoodSpecListViewItemAmount) as TextView;

            foodItem.Text = itemName ; 
            foodAmount.Text = itemAmount + "g";

            //Finally return the view 
            return view;
        }
        
        public String GetItemAtPosition(int position)
        {
            return FoodItemsName[position];
        }
    }
}