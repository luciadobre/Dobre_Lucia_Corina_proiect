using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dobre_Lucia_Corina_proiect.Data;
using Dobre_Lucia_Corina_proiect.Models;

namespace Dobre_Lucia_Corina_proiect.Pages.Distributors
{
    public class DetailsModel : PageModel
    {
        private readonly Dobre_Lucia_Corina_proiect.Data.Dobre_Lucia_Corina_proiectContext _context;

        public DetailsModel(Dobre_Lucia_Corina_proiect.Data.Dobre_Lucia_Corina_proiectContext context)
        {
            _context = context;
        }

        public Distributor Distributor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distributor = await _context.Distributor.FirstOrDefaultAsync(m => m.ID == id);
            if (distributor == null)
            {
                return NotFound();
            }
            else
            {
                Distributor = distributor;
            }
            return Page();
        }
    }
}
