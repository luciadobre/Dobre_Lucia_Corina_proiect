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
    public class IndexModel : PageModel
    {
        private readonly Dobre_Lucia_Corina_proiect.Data.Dobre_Lucia_Corina_proiectContext _context;

        public IndexModel(Dobre_Lucia_Corina_proiect.Data.Dobre_Lucia_Corina_proiectContext context)
        {
            _context = context;
        }

        public IList<DistributorProduct> DistributorProduct { get;set; } = default!;

        public async Task OnGetAsync()
        {
            DistributorProduct = await _context.DistributorProduct
                .Include(d => d.Distributor).ToListAsync();
        }
    }
}
