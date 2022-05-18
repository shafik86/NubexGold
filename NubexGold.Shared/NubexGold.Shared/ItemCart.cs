using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubexGold.Shared
{
    public class ItemCart
    {
        [Key]
        public int ItemCartId { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }
        public ProductInHand productInHand { get; set; }
        public User User { get; set; }
        



    }
}
