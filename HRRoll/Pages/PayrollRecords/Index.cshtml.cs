using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRRoll.Data;
using HRRoll.Models;

namespace HRRoll.Pages.PayrollRecords
{
    public class IndexModel : PageModel
    {
        private readonly HRRoll.Data.AppDbContext _context;

        public IndexModel(HRRoll.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<PayrollRecord> PayrollRecord { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PayrollRecord = await _context.PayrollRecords.ToListAsync();
        }
    }
}
