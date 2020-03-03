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

namespace NDMA.Resources.Adapter
{
    class CustomSearchedAPIListAdapter : BaseAdapter
    {
        Activity context;
        public ParsedFoodCollection foods;

        public CustomSearchedAPIListAdapter(Activity context, ParsedFoodCollection food) //We need a context to inflate our row view from 
            : base()
        {
            this.context = context;
            this.foods = food;
           
        }
        public override int Count
        {
            get { return foods.Count; }
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
            var item = foods.Hits.ToArray()[position];

            //Try to reuse convertView if it's not null, otherwise inflate it from our item layout
            // This gives us some performance gains by not always inflating a new view
            // This will sound familiar to MonoTouch developers with UITableViewCell.DequeueReusableCell()
            var view = (convertView ?? context.LayoutInflater.Inflate(Resource.Layout.DisplaySearchedAPIListLayout, parent, false)) as LinearLayout;

            //Find references to each subview in the list item's view
            var textTop = view.FindViewById(Resource.Id.TestTextView) as TextView;
            var imageItem = view.FindViewById(Resource.Id.TestImageView) as ImageView;

            //Assign this item's values to the various subviews 
            imageItem.SetImageBitmap(GetImageBitmapFromUrl(item.Recipe.Image));
            textTop.Text = item.Recipe.label;

            //Finally return the view 
            return view;
        }

        private Android.Graphics.Bitmap GetImageBitmapFromUrl(string url)
        {
            Android.Graphics.Bitmap imageBitmap = null;

            using (var webClient = new System.Net.WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = Android.Graphics.BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }


            }

            return imageBitmap;
        }

        public String GetItemAtPosition(int position)
        {
            return foods.Hits.ToArray()[position].Recipe.label;
        }
    }
}