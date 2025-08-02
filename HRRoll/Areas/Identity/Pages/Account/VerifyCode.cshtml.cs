using HRRoll.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace HRRoll.Areas.Identity.Pages.Account
{
    public class VerifyCodeModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;

        public VerifyCodeModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Code { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Code))
            {
                ErrorMessage = "Email and code are required.";
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                ErrorMessage = "User not found.";
                return Page();
            }

            var isExpired = user.CodeGeneratedAt == null || DateTime.UtcNow > user.CodeGeneratedAt.Value.AddMinutes(1);
            var isInvalid = user.EmailVerificationCode != Code;

            if (isInvalid || isExpired)
            {
                ErrorMessage = isInvalid ? "Invalid code." : "Code expired. Please register again.";
                return Page();
            }

            user.EmailConfirmed = true;
            user.EmailVerificationCode = null;
            user.CodeGeneratedAt = null;
            await _userManager.UpdateAsync(user);

            return RedirectToPage("/Account/Login");
        }

        public void OnGet(string email)
        {
            Email = email;
        }
    }
}
