using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRRoll.Data;

namespace HRRoll.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class UsersModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;

        public UsersModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public List<AppUser> Users { get; set; } = new();

        public async Task OnGetAsync()
        {
            Users = _userManager.Users.ToList();
        }

        // ✅ This handles the delete action
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            return RedirectToPage(); // Refresh the page after deletion
        }
    }
}
