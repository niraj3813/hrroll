using HRRoll.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace HRRoll.Pages.Account
{
    public class LoginClientModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly ILogger<LoginClientModel> _logger;

        public LoginClientModel(
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            AppDbContext context,
            ILogger<LoginClientModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string ClientCode { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // 1. Find client master by client code (can be master or child)
            var client = await _context.ClientMasters
                .FirstOrDefaultAsync(c => c.ClientCode == Input.ClientCode);

            if (client == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid client code.");
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials.");
                return Page();
            }

            // 2. Check if this user belongs to this client
            if (user.ClientMasterId != client.ClientMasterId)
            {
                ModelState.AddModelError(string.Empty, "Client-user mismatch.");
                return Page();
            }

            // 3. Validate login
            var result = await _signInManager.PasswordSignInAsync(user.UserName, Input.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("Client user logged in.");
                return RedirectToPage("/Clients/Index"); // or redirect to client-specific dashboard
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}
