using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRRoll.Data;
using Microsoft.EntityFrameworkCore;

namespace HRRoll.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class DashboardModel : PageModel
    {
        private readonly AppDbContext _context;

        public DashboardModel(AppDbContext context)
        {
            _context = context;
        }

        public int EmployeeCount { get; set; }
        public int PayrollCount { get; set; }

        public async Task OnGetAsync()
        {
            EmployeeCount = await _context.Employees.CountAsync();
            PayrollCount = await _context.PayrollRecords.CountAsync();
        }
    }
}

