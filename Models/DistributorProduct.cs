using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Dobre_Lucia_Corina_proiect.Models
{
    public class DistributorProduct
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [Display(Name = "Distributor Product Name")]
        [StringLength(100, ErrorMessage = "Product name is too long.")]
        public string DistributorProductName { get; set; }
        [Required(ErrorMessage = "Type is required.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid quantity.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Buy price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Invalid price.")]
        public decimal BuyPrice { get; set; }

        public int? DistributorID { get; set; }
        public Distributor? Distributor { get; set; }
    }
}