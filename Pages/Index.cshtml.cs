using Dobre_Lucia_Corina_proiect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dobre_Lucia_Corina_proiect.Pages
{
    public class SalesProductsModel : PageModel
    {
        private readonly Dobre_Lucia_Corina_proiect.Data.Dobre_Lucia_Corina_proiectContext _context;

        public SalesProductsModel(Dobre_Lucia_Corina_proiect.Data.Dobre_Lucia_Corina_proiectContext context)
        {
            _context = context;
        }

        public IList<Sale> Sales { get; private set; }
        public IList<Product> Products { get; private set; }

        public async Task OnGetAsync()
        {
            Sales = await _context.Sale
                .Include(s => s.Product)
                .ThenInclude(p => p.DistributorProduct)
                .ToListAsync();

            Products = await _context.Product
                .Include(p => p.Distributor)
                .ToListAsync();
        }
    }
}
