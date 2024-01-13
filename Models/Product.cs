using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Dobre_Lucia_Corina_proiect.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Description = "Product Description")]
        public string Description { get; set; }

        public string DistributorName { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal BuyPrice { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal SellPrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime BuyDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime SellDate { get; set; }

        public int? DistributorID { get; set; }
        public Distributor? Distributor { get; set; }
    }

}
