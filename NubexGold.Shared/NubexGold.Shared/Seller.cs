using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubexGold.Shared
{
    public class Seller
    {
        public int SellerId { get; set; }
        public int UserId { get; set; }
        [Required]
        public string SellerName { get; set; }
        [Required]
        public string SellerContact { get; set; }
        public string SellerAddress { get; set; }
        public string SellerEmail { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string SellerCompany { get; set; }
        public string CompanyLicense { get; set; }
        //public int ProductInHandId { get; set; }7
        public double SellerWallet { get; set; }
        public ComsType ComsType { get; set; }
        public double? ComsPercent { get; set; }
        public double? ComsFix { get; set; }
        public double? ComsFixPer { get; set; }
        public string AccNumber { get; set; }
        public string BankName { get; set; }
        public string BankHolder { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }


        public Shipping Courier { get; set; }
        public List<ProductInHand> productInHands { get; set; }

    }
}
