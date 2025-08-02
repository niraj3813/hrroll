using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRRoll.Data;
using HRRoll.Models;

namespace HRRoll.Pages.PayrollRecords
{
    public class EditModel : PageModel
    {
        private readonly HRRoll.Data.AppDbContext _context;

        public EditModel(HRRoll.Data.AppDbContext context)
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

            var payrollrecord =  await _context.PayrollRecords.FirstOrDefaultAsync(m => m.PayrollRecordId == id);
            if (payrollrecord == null)
            {
                return NotFound();
            }
            PayrollRecord = payrollrecord;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PayrollRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayrollRecordExists(PayrollRecord.PayrollRecordId))
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

        private bool PayrollRecordExists(int id)
        {
            return _context.PayrollRecords.Any(e => e.PayrollRecordId == id);
        }
    }
}
