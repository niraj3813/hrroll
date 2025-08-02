using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRRoll.Data;

namespace HRRoll.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly HRRoll.Data.AppDbContext _context;

        public EditModel(HRRoll.Data.AppDbContext context)
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

            var clientmaster =  await _context.ClientMasters.FirstOrDefaultAsync(m => m.ClientMasterId == id);
            if (clientmaster == null)
            {
                return NotFound();
            }
            ClientMaster = clientmaster;
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

            _context.Attach(ClientMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientMasterExists(ClientMaster.ClientMasterId))
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

        private bool ClientMasterExists(int id)
        {
            return _context.ClientMasters.Any(e => e.ClientMasterId == id);
        }
    }
}
