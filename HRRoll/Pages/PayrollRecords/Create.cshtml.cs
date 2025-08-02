using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HRRoll.Data;
using HRRoll.Models;

namespace HRRoll.Pages.PayrollRecords
{
    public class CreateModel : PageModel
    {
        private readonly HRRoll.Data.AppDbContext _context;

        public CreateModel(HRRoll.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PayrollRecord PayrollRecord { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PayrollRecords.Add(PayrollRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
