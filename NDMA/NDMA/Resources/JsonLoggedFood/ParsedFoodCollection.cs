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
using Newtonsoft.Json;

namespace NDMA.Resources.JsonLoggedFood
{
    public class ParsedFoodCollection
    {
        /******************************************************************************************************************************
         * The class to actually parse the data from the ednaman api searched, store it and use it for the application analysis purpose
         ******************************************************************************************************************************/

        [JsonProperty("q")]
        public String Q { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("hits")]
        internal List<DBFood> Hits { get; set; }

        public ParsedFoodCollection()
        {
            Hits = new List<DBFood>();
        }
        public List<DBFood> GetList()
        {
            return Hits;
        }

    }
}