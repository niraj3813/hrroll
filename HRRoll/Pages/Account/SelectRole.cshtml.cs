using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HRRoll.Pages.Account
{
    public class SelectRoleModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Please select a role.")]
        public string SelectedRole { get; set; }

        public IActionResult OnPost()
        {
            return SelectedRole switch
            {
                "Client" => RedirectToPage("/Account/LoginClient"),
                "Employee" => RedirectToPage("/Account/LoginEmployee"),
                "Accountant" => RedirectToPage("/Account/LoginAccountant"),
                _ => Page()
            };
        }
    }
}
