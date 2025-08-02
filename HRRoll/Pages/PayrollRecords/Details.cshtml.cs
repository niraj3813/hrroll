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
    public class DetailsModel : PageModel
    {
        private readonly HRRoll.Data.AppDbContext _context;

        public DetailsModel(HRRoll.Data.AppDbContext context)
        {
            _context = context;
        }

        public PayrollRecord PayrollRecord { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payrollrecord = await _context.PayrollRecords.FirstOrDefaultAsync(m => m.PayrollRecordId == id);
            if (payrollrecord == null)
            {
                return NotFound();
            }
            else
            {
                PayrollRecord = payrollrecord;
            }
            return Page();
        }
    }
}
