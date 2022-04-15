using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubexGold.Shared
{
    public class ProductDataResult
    {
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public int Count { get; set; }
    }
}
