﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
    class CustomDefaultListAdapter : BaseAdapter
    {
        Activity context;
        String [] headerCollection;
        public CustomDefaultListAdapter(Activity context, String [] headerCollection) : base()
        {
            this.context = context;
            this.headerCollection = headerCollection;
        }
        public override int Count
        {
            get {return headerCollection.Length; }
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
            var item = headerCollection[position];

            var view = (convertView ?? context.LayoutInflater.Inflate(Resource.Layout.CustomSimpleListLayout, parent, false)) as LinearLayout;

            //Find references to each subview in the list item's view
            var textTop = view.FindViewById(Resource.Id.SimpleListViewTextView) as TextView;

            //Assign this item's values to the various subviews 
            textTop.Text = item;

            //Finally return the view 
            return view;
        }
    }
}