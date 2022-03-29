using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace NubexGold.Shared
{
    public class AddEditModel
    {
        public int ProductId { get; set; }
        [Required]
        public string SKU { get; set; } = "SKU";
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        [Required]
        public Types Type { get; set; }
        [Required]
        public Metal Metal { get; set; }
        [Required]
        public double MetalWeight { get; set; } 
        public string? MetalBrand { get; set; }
        [Required]
        public double Weight { get; set; } = 1;
        [Required]
        public string Condition { get; set; }
        public double Purify { get; set; }
        public string Manufacture { get; set; }
        public string? Certificate { get; set; } = "N/A";
        public bool IsTax { get; set; } = false;
        public string? Featured { get; set; }
        public double? Price { get; set; }
        //public string Sex { get; set; }
        public string? Color { get; set; }
        public double? Size { get; set; }
        [Required]
        public string? ProductTag { get; set; } = "Highlights";
        [Required]
        public string Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "Administrators";
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = "Admin";
    }
}
