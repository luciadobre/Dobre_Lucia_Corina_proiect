using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dobre_Lucia_Corina_proiect.Data;
using Dobre_Lucia_Corina_proiect.Models;

namespace Dobre_Lucia_Corina_proiect.Pages.Products
{
    public class ConfirmDeleteModel : PageModel
    {
        private readonly Dobre_Lucia_Corina_proiectContext _context;

        public ConfirmDeleteModel(Dobre_Lucia_Corina_proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Product = await _context.Product
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null) return NotFound();

            return RedirectToPage("./ConfirmDelete", new { id = id });
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            Product = await _context.Product.FindAsync(id);

            if (Product != null)
            {
                _context.Product.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
