using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRRoll.Data;

namespace HRRoll.Pages.Clients
{
    public class DeleteModel : PageModel
    {
        private readonly HRRoll.Data.AppDbContext _context;

        public DeleteModel(HRRoll.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClientMaster ClientMaster { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientmaster = await _context.ClientMasters.FirstOrDefaultAsync(m => m.ClientMasterId == id);

            if (clientmaster == null)
            {
                return NotFound();
            }
            else
            {
                ClientMaster = clientmaster;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientmaster = await _context.ClientMasters.FindAsync(id);
            if (clientmaster != null)
            {
                ClientMaster = clientmaster;
                _context.ClientMasters.Remove(ClientMaster);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
