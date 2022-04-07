using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubexGold.Shared
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int SellerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PostDate { get; set; }
        public int CourierId { get; set; }
        //public int CourierId { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }


    }
}
