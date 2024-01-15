using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dobre_Lucia_Corina_proiect.Models
{
    public class Sale
    {
        public int ID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        [Display(Name = "Quantity Sold")]
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Sale Date")]
        public DateTime SaleDate { get; set; }

        public int? ProductID { get; set; }
        public Product? Product { get; set; }
        public int? BuyerID { get; set; }
        public Buyer? Buyer { get; set; }

        [Display(Name = "Profit")]
        [DataType(DataType.Currency)]
        public decimal Profit { get; private set; }

        public void CalculateProfit()
        {
            if (Product != null)
            {
                Profit = Quantity * (Product.SellPrice - Product.BuyPrice);
            }
        }
    }
}
