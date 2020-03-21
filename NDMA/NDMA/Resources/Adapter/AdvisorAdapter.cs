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
    //AdvisorListDisplayFoodContents
    class AdvisorAdapter : BaseAdapter
    {
        Activity context;
        String[] headerCollection;
        String[] foodNames;

        public AdvisorAdapter(Activity context, String[] headerCollection, String[] foodNames) : base()
        {
            this.context = context;
            this.headerCollection = headerCollection;
            this.foodNames = foodNames;
        }
        public override int Count
        {
            get { return headerCollection.Length; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return headerCollection[position];
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //Get our object for this position
            var item = headerCollection[position];

            var view = (convertView ?? context.LayoutInflater.Inflate(Resource.Layout.AdvisorListDisplayFoodContents, parent, false)) as LinearLayout;

            //Find references to each subview in the list item's view
            var textTop = view.FindViewById(Resource.Id.FoodNameDisplayAdvise) as TextView;
            //Assign this item's values to the various subviews 
            textTop.Text = item;

            var FoodNames = view.FindViewById(Resource.Id.FoodQuantityDisplayAdvise) as TextView;
            FoodNames.Text = foodNames[position];

            //Finally return the view 
            return view;
        }
    }
}