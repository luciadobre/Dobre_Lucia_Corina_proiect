using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Dobre_Lucia_Corina_proiect.Models
{
    public class Buyer
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Buyer name is required.")]
        [Display(Name = "Buyer Name")]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Contact Email")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Display(Name = "Contact Phone")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        public ICollection<Sale>? Sale { get; set; }

    }
}