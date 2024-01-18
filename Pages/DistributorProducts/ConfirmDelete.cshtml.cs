using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dobre_Lucia_Corina_proiect.Data;
using Dobre_Lucia_Corina_proiect.Models;

namespace Dobre_Lucia_Corina_proiect.Pages.DistributorProducts
{
    public class ConfirmDeleteModel : PageModel
    {
        private readonly Dobre_Lucia_Corina_proiectContext _context;

        public ConfirmDeleteModel(Dobre_Lucia_Corina_proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DistributorProduct DistributorProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DistributorProduct = await _context.DistributorProduct
                .FirstOrDefaultAsync(m => m.ID == id);

            if (DistributorProduct == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DistributorProduct = await _context.DistributorProduct.FindAsync(id);

            if (DistributorProduct != null)
            {
                _context.DistributorProduct.Remove(DistributorProduct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
