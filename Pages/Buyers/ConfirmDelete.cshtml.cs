using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dobre_Lucia_Corina_proiect.Data;
using Dobre_Lucia_Corina_proiect.Models;

namespace Dobre_Lucia_Corina_proiect.Pages.Buyers
{
    public class ConfirmDeleteModel : PageModel
    {
        private readonly Dobre_Lucia_Corina_proiectContext _context;

        public ConfirmDeleteModel(Dobre_Lucia_Corina_proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Buyer Buyer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Buyer = await _context.Buyer
                .Include(b => b.Sale)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Buyer == null)
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

            Buyer = await _context.Buyer
                .Include(b => b.Sale)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Buyer == null)
            {
                return NotFound();
            }

            foreach (var sale in Buyer.Sale.ToList())
            {
                _context.Sale.Remove(sale);
            }

            _context.Buyer.Remove(Buyer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
