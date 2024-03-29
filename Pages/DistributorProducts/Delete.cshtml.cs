﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly Dobre_Lucia_Corina_proiect.Data.Dobre_Lucia_Corina_proiectContext _context;

        public DeleteModel(Dobre_Lucia_Corina_proiect.Data.Dobre_Lucia_Corina_proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DistributorProduct DistributorProduct { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distributorproduct = await _context.DistributorProduct.Include(dp => dp.Distributor).FirstOrDefaultAsync(m => m.ID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distributorproduct = await _context.DistributorProduct.FindAsync(id);
            if (distributorproduct != null)
            {
                return RedirectToPage("./ConfirmDelete", new { id = DistributorProduct.ID });
            }

            return RedirectToPage("./Index");
        }
    }
}