using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRRoll.Data;
using HRRoll.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRRoll.Pages.Clients
{
    public class ViewEmployeesModel : PageModel
    {
        private readonly AppDbContext _context;

        public ViewEmployeesModel(AppDbContext context)
        {
            _context = context;
        }

        public ClientMaster Client { get; set; }

        public List<Employee> Employees { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Client = await _context.ClientMasters
                .Include(c => c.Employees)
                .FirstOrDefaultAsync(c => c.ClientMasterId == id);

            if (Client == null)
            {
                return NotFound();
            }

            Employees = Client.Employees != null ? new List<Employee>(Client.Employees) : new List<Employee>();

            return Page();
        }
    }
}
