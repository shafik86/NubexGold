using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubexGold.Shared
{
    public class Order_Details
    {
        public Orders Orders { get; set; }
        public int OrderId { get; set; }
        public ProductInHand ProductInHand { get; set; }
        public int ProductInHandsId { get; set; }        
        public double Quantity { get; set; }
        public double LockPrice { get; set; }
        public double ComsPrice { get; set; }
        public double Discount { get; set; }
        public string Voucher { get; set; }
        

    }
}
