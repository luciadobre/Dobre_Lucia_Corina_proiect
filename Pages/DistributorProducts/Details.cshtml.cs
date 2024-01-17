using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dobre_Lucia_Corina_proiect.Data;
using Dobre_Lucia_Corina_proiect.Models;

namespace Dobre_Lucia_Corina_proiect.Pages.DistributorProducts
{
    public class DetailsModel : PageModel
    {
        private readonly Dobre_Lucia_Corina_proiect.Data.Dobre_Lucia_Corina_proiectContext _context;

        public DetailsModel(Dobre_Lucia_Corina_proiect.Data.Dobre_Lucia_Corina_proiectContext context)
        {
            _context = context;
        }

        public DistributorProduct DistributorProduct { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distributorproduct = await _context.DistributorProduct.FirstOrDefaultAsync(m => m.ID == id);
            if (distributorproduct == null)
            {
                return NotFound();
            }
            else
            {
                DistributorProduct = distributorproduct;
            }
            return Page();
        }
    }
}
