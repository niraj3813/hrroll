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
    public class DeleteModel : PageModel
    {
        private readonly HRRoll.Data.AppDbContext _context;

        public DeleteModel(HRRoll.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payrollrecord = await _context.PayrollRecords.FindAsync(id);
            if (payrollrecord != null)
            {
                PayrollRecord = payrollrecord;
                _context.PayrollRecords.Remove(PayrollRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
