﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dobre_Lucia_Corina_proiect.Data;
using Dobre_Lucia_Corina_proiect.Models;

namespace Dobre_Lucia_Corina_proiect.Pages.Buyers
{
    public class EditModel : PageModel
    {
        private readonly Dobre_Lucia_Corina_proiect.Data.Dobre_Lucia_Corina_proiectContext _context;

        public EditModel(Dobre_Lucia_Corina_proiect.Data.Dobre_Lucia_Corina_proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Buyer Buyer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyer =  await _context.Buyer.FirstOrDefaultAsync(m => m.ID == id);
            if (buyer == null)
            {
                return NotFound();
            }
            Buyer = buyer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Buyer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerExists(Buyer.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BuyerExists(int id)
        {
            return _context.Buyer.Any(e => e.ID == id);
        }
    }
}
