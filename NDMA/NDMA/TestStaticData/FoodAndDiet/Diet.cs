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

namespace NDMA.TestStaticData.NutitionalDifficulty
{
    public class Diet
    {
        private String name;
        private String description;
        private Android.Graphics.Bitmap image;

        public Diet(String name, String description, Android.Graphics.Bitmap image)
        {
            this.name = name;
            this.description = description;
            this.image = image;
        }

        public String GetName()
        {
            return this.name;
        }

        public String GetDescription()
        {
            return this.description;
        }

        public Android.Graphics.Bitmap GetImage()
        {
            return this.image;
        }
    }
}