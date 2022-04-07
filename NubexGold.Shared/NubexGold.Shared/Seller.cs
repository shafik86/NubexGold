using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubexGold.Shared
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string SellerContact { get; set; }
        public string SellerAddress { get; set; }
        public string SellerEmail { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string SellerCompany { get; set; }
        public string License { get; set; }
        public string AccNumber { get; set; }
        public string BankName { get; set; }
        public string BankHolder { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }

    }
}
