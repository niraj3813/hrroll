using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HRRoll.Data;
using HRRoll.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRRoll.Pages.Employees
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public IndexModel(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Employee> Employee { get; set; }

        public async Task OnGetAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var isAdmin = await _userManager.IsInRoleAsync(currentUser, "Admin");

            if (isAdmin)
            {
                Employee = await _context.Employees
                    .Include(e => e.ClientMaster)
                    .ToListAsync();
            }
            else
            {
                Employee = await _context.Employees
                    .Where(e => e.AppUserId == currentUser.Id)
                    .ToListAsync();
            }
        }
    }
}
