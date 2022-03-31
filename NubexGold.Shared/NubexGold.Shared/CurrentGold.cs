using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubexGold.Shared
{
    public class CurrentGold
    {
        public DateTime date { get; set; }
        public long timestamp { get; set; }
        public string metal { get; set; }
        public string exchange { get; set; }
        public string currency { get; set; }
        public float price { get; set; }
        public float prev_close_price { get; set; }
        public float ch { get; set; }
        public float chp { get; set; }
        public float price_gram_24k { get; set; }
        public float price_gram_22k { get; set; }
        public float price_gram_21k { get; set; }
        public float price_gram_20k { get; set; }
        public float price_gram_18k { get; set; }
    }

}
