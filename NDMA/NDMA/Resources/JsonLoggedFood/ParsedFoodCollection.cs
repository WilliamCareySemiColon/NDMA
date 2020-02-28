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

    }
}