using Microsoft.AspNetCore.Mvc.RazorPages;
using Dobre_Lucia_Corina_proiect.Data;
using Dobre_Lucia_Corina_proiect.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ProfitSummaryModel : PageModel
{
    private readonly Dobre_Lucia_Corina_proiectContext _context;

    public ProfitSummaryModel(Dobre_Lucia_Corina_proiectContext context)
    {
        _context = context;
    }

    public IList<Sale> Sales { get; set; }
    public decimal TotalProfit { get; set; }

    public async Task OnGetAsync()
    {
        Sales = await _context.Sale
            .Include(s => s.Product)
            .ToListAsync();

        TotalProfit = Sales.Sum(s => s.Profit);
    }

}
