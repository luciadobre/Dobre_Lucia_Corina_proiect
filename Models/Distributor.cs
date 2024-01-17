using System.ComponentModel.DataAnnotations;

namespace Dobre_Lucia_Corina_proiect.Models
{
    public class Distributor
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Distributor name is required.")]
        [Display(Name = "Distributor Name")]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        public string DistributorName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address is too long.")]
        public string Address { get; set; }

        public ICollection<DistributorProduct>? DistributorProduct { get; set; }
    }
}
