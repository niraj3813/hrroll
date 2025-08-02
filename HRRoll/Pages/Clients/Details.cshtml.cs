using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRRoll.Models;
using HRRoll.Data;

namespace HRRoll.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public ClientMaster ClientMaster { get; set; }
        public List<Employee> Employees { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ClientMaster = await _context.ClientMasters
                .FirstOrDefaultAsync(c => c.ClientMasterId == id);

            if (ClientMaster == null)
            {
                return NotFound();
            }

            Employees = await _context.Employees
                .Where(e => e.ClientMasterId == id)
                .ToListAsync();

            return Page();
        }
    }
}
