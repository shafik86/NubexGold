using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubexGold.Shared
{
    public class UserCart
    {
        [Key]
        public int UserCartId { get; set; }
        //public Seller Seller { get; set; }
        //public int SellerId { get; set; }
        //public ProductInHand product { get; set; }
        //public int ProductId { get; set; }
        //public Condition condition { get; set; }
        //public int ConditionId { get; set; }

        public ProductInHand ProductInHand { get; set; }
        public int ProductInHandId { get; set; }
        public double Qty { get; set; }
        public ItemCart item { get; set; }
        public int itemCartId { get; set; }

    }

    
}
