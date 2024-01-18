using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dobre_Lucia_Corina_proiect.Data;
using Dobre_Lucia_Corina_proiect.Models;

namespace Dobre_Lucia_Corina_proiect.Pages.Products
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
            PopulateDistributorProductData();
            return Page();
        }

        private void PopulateDistributorProductData()
        {
            var distributorProductOptions = _context.DistributorProduct
                .Select(dp => new
                {
                    ID = dp.ID,
                    Description = $"{dp.DistributorProductName} (Available: {dp.Quantity})",
                    BuyPrice = dp.BuyPrice
                })
                .ToList();

            ViewData["DistributorProductID"] = new SelectList(distributorProductOptions, "ID", "Description");

            var buyPriceOptions = distributorProductOptions
                .GroupBy(dp => dp.BuyPrice)
                .Select(g => new { BuyPrice = g.Key, Description = g.Key.ToString() })
                .ToList();

            ViewData["BuyPriceOptions"] = new SelectList(buyPriceOptions, "BuyPrice", "Description");
            ViewData["DistributorID"] = new SelectList(_context.Distributor, "ID", "DistributorName");
        }



        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            var distributorProduct = _context.DistributorProduct
                .FirstOrDefault(dp => dp.ID == Product.DistributorProductID);

            if (distributorProduct == null)
            {
                ModelState.AddModelError("Product.DistributorProductID", "Invalid distributor product.");
                PopulateDistributorProductData();
                return Page();
            }

            if (Product.Quantity > distributorProduct.Quantity)
            {
                ModelState.AddModelError("Product.Quantity", "Quantity exceeds available stock.");
                PopulateDistributorProductData();
                return Page();
            }

            distributorProduct.Quantity -= Product.Quantity;

            if (!ModelState.IsValid)
            {
                PopulateDistributorProductData();
                return Page();
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
