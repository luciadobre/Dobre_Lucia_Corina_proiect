using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dobre_Lucia_Corina_proiect.Data;
using Dobre_Lucia_Corina_proiect.Models;

namespace Dobre_Lucia_Corina_proiect.Pages.Sales
{
    public class ConfirmDeleteModel : PageModel
    {
        private readonly Dobre_Lucia_Corina_proiectContext _context;

        public ConfirmDeleteModel(Dobre_Lucia_Corina_proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sale Sale { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Sale = await _context.Sale
                .Include(s => s.Product)
                .Include(s => s.Buyer)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Sale == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            Sale = await _context.Sale.FindAsync(id);

            if (Sale != null)
            {
                _context.Sale.Remove(Sale);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
