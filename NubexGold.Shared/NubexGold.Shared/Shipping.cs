using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubexGold.Shared
{
    public class Shipping
    {
        [Key]
        public int CourierId { get; set; }
        public string Name { get; set; }
        public double RatePrice { get; set; }
        public double ServiceTax { get; set; }
        public string CourierLink { get; set; }
        public string Contact { get; set; }
        public string ServiceType { get; set; }
        public double QtySent { get; set; }
        public string remark_1 { get; set; }
        public string remark_2 { get; set; }
        public string remark_3 { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "Administrator";
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; } = "Admin";

    }
}
