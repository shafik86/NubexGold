using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubexGold.Shared
{
    public class ProductInHand
    {
        
        public int Id { get; set; }
        [Required]


        //Navigation
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SellerId { get; set; }
        public Seller Seller { get; set; }

        public double? QtyInHand { get; set; }
        
    }
}
