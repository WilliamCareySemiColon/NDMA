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
    //the amount per day consumtion
    public class Substance
    {
        public String AmountMale;
        public String AmountFemale;

        public String[] TopSources;

        public Substance(String AmountMale, String AmountFemale,String[] TopSources)
        {
            this.AmountMale = AmountMale;
            this.AmountFemale = AmountFemale;
            this.TopSources = TopSources;
        }

        public Substance(String Amount, String[] TopSources)
        {
            this.AmountMale = Amount;
            this.AmountFemale = Amount;
            this.TopSources = TopSources;
        }
    }
}