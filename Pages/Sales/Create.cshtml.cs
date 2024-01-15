using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dobre_Lucia_Corina_proiect.Data;
using Dobre_Lucia_Corina_proiect.Models;
using Microsoft.EntityFrameworkCore;

namespace Dobre_Lucia_Corina_proiect.Pages.Sales
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
            PopulateProductData();
            return Page();
        }

        private void PopulateProductData()
        {
            var productOptions = _context.Product
                .Include(p => p.DistributorProduct)
                .ToList()
                .Select(p => new
                {
                    ID = p.ID,
                    Description = p.DistributorProduct == null ? "Unknown" : $"{p.DistributorProduct.DistributorProductName} (Available: {p.Quantity})"
                });

            ViewData["ProductID"] = new SelectList(productOptions, "ID", "Description");
            ViewData["BuyerID"] = new SelectList(_context.Buyer, "ID", "Name");
        }

        [BindProperty]
        public Sale Sale { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateProductData();
                return Page();
            }

            var product = _context.Product.FirstOrDefault(p => p.ID == Sale.ProductID);

            if (product == null)
            {
                ModelState.AddModelError("Sale.ProductID", "Invalid product.");
                PopulateProductData();
                return Page();
            }

            if (Sale.Quantity > product.Quantity)
            {
                ModelState.AddModelError("Sale.Quantity", "Quantity exceeds available stock.");
                PopulateProductData();
                return Page();
            }

            product.Quantity -= Sale.Quantity;

            _context.Sale.Add(Sale);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
