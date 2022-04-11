using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NubexGold.Shared
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductSKU { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public Types Type { get; set; }
        public Metal Metal { get; set; }
        public double MetalWeight { get; set; }
        public string? MetalBrand { get; set; }

        public double Weight { get; set; }
        public double Purify { get; set; }
        public string? Manufacture { get; set; }
        public string? Certificate { get; set; }
        public bool IsTax { get; set; } = false;
        public string? Featured { get; set; }
        public double? Price { get; set; }
        public string? Color { get; set; }
        public double? Size { get; set; }
        public string? ProductTag { get; set; }
        public string Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? remark_1 { get; set; }
        public string? remark_2 { get; set; }
        public string? remark_3 { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "Administrators";
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; } = "Admin";
 
        //Navigation Properties

        public List<ProductInHand>? productInHands { get; set; }
        public Condition? Condition { get; set; }
        public int ConditionId { get; set; }
    }
}