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

namespace NDMA.Resources.ZZZTestData
{
    public class CalculatedSubtance
    {
        public String MinPercentage;
        public String MaxPercentage;
        public String[] TopSources;

        public CalculatedSubtance(String MinPercentage, String MaxPercentage, String[] TopSources)
        {
            this.MinPercentage = MinPercentage;
            this.MaxPercentage = MaxPercentage;
            this.TopSources = TopSources;
        }

        public CalculatedSubtance(String Percentage,  String[] TopSources)
        {
            this.MinPercentage = "0";
            this.MaxPercentage = Percentage;
            this.TopSources = TopSources;
        }
    }
}