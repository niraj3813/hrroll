using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HRRoll.Data;
using HRRoll.Models;
using Microsoft.EntityFrameworkCore;

namespace HRRoll.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = new Employee();

        public SelectList ClientMasterList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? clientId = null)
        {
            ClientMasterList = new SelectList(await _context.ClientMasters.ToListAsync(), "ClientMasterId", "ClientName");

            if (clientId.HasValue)
            {
                Employee = new Employee
                {
                    ClientMasterId = clientId
                };
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var clients = await _context.ClientMasters.ToListAsync();
                ClientMasterList = new SelectList(clients, "ClientMasterId", "ClientName");
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
