using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Dobre_Lucia_Corina_proiect.Models
{
    public class Product
    {
    public int ID { get; set; }

    [Display(Name = "Product Name")]
    public int? DistributorProductName { get; set; } 

    [StringLength(500, ErrorMessage = "Description is too long.")]
    [Display(Description = "Product Description")]
    public string Description { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be at least 0")]
    [Display(Name = "Quantity")]
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(6, 2)")]
    [Range(0, double.MaxValue, ErrorMessage = "Invalid price.")]
    public decimal BuyPrice { get; set; }

    [Column(TypeName = "decimal(6, 2)")]
    [Range(0, double.MaxValue, ErrorMessage = "Invalid price.")]
    public decimal SellPrice { get; set; }

    [DataType(DataType.Date)]
    public DateTime BuyDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime SellDate { get; set; }

    public int? DistributorID { get; set; }
    public Distributor? Distributor { get; set; }

    public int? DistributorProductID { get; set; }
    public DistributorProduct? DistributorProduct { get; set; }

    public ICollection<Sale>? Sale { get; set; }
    }

}
