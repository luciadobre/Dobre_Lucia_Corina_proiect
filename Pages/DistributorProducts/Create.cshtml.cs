using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dobre_Lucia_Corina_proiect.Data;
using Dobre_Lucia_Corina_proiect.Models;

namespace Dobre_Lucia_Corina_proiect.Pages.DistributorProducts
{
    public class CreateModel : PageModel
    {
        private readonly Dobre_Lucia_Corina_proiect.Data.Dobre_Lucia_Corina_proiectContext _context;

        public CreateModel(Dobre_Lucia_Corina_proiect.Data.Dobre_Lucia_Corina_proiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DistributorID"] = new SelectList(_context.Distributor, "ID", "DistributorName");
            return Page();
        }

        [BindProperty]
        public DistributorProduct DistributorProduct { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

        public SelectList DistributorNames { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingDistributorProduct = _context.DistributorProduct.FirstOrDefault(
                dp => dp.DistributorProductName == DistributorProduct.DistributorProductName &&
                      dp.DistributorID == DistributorProduct.DistributorID);

            if (existingDistributorProduct != null)
            {
                existingDistributorProduct.Quantity += DistributorProduct.Quantity;
                _context.DistributorProduct.Update(existingDistributorProduct);
            }
            else
            {
                _context.DistributorProduct.Add(DistributorProduct);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
