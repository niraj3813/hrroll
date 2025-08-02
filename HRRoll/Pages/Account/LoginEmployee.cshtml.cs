using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HRRoll.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HRRoll.Pages.Account
{
    public class LoginEmployeeModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<LoginEmployeeModel> _logger;

        public LoginEmployeeModel(
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            ILogger<LoginEmployeeModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [StringLength(4, MinimumLength = 4)]
            [Display(Name = "Last 4 digits of SSN")]
            public string Last4SSN { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = await _userManager.FindByEmailAsync(Input.Email);

            if (user == null || user.SSN?.Length < 4 || user.SSN[^4..] != Input.Last4SSN)
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials or SSN mismatch.");
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation("Employee logged in.");
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
        }
    }
}