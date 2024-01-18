using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dobre_Lucia_Corina_proiect.Data;
using Dobre_Lucia_Corina_proiect.Models;

namespace Dobre_Lucia_Corina_proiect.Pages.Distributors
{
    public class ConfirmDeleteModel : PageModel
    {
        private readonly Dobre_Lucia_Corina_proiectContext _context;

        public ConfirmDeleteModel(Dobre_Lucia_Corina_proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Distributor Distributor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Distributor = await _context.Distributor
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Distributor == null) return NotFound();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            Distributor = await _context.Distributor
                .Include(d => d.DistributorProduct)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Distributor == null) return NotFound();

            ViewData["WarningMessage"] = "Deleting this distributor will also permanently delete all associated products.";

            foreach (var product in Distributor.DistributorProduct.ToList())
            {
                _context.DistributorProduct.Remove(product);
            }

            _context.Distributor.Remove(Distributor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
