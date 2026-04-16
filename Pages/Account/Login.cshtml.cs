using Learner_Management_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Learner_Management_System.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public string? ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }

                // Update last login date
                user.LastLoginDate = DateTime.Now;
                await _userManager.UpdateAsync(user);

                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    // Role-based redirect
                    return RedirectBasedOnRole(user.Role);
                }
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Account locked due to multiple failed login attempts.");
                    return Page();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            return Page();
        }

        private IActionResult RedirectBasedOnRole(UserRole role)
        {
            return role switch
            {
                UserRole.Student => RedirectToPage("/Student/Dashboard"),
                UserRole.Lecturer => RedirectToPage("/Lecturer/Dashboard"),
                UserRole.Admin => RedirectToPage("/Admin/Dashboard"),
                UserRole.AssessorDeveloper => RedirectToPage("/AssessorDeveloper/Dashboard"),
                UserRole.AssessmentCentreAdmin => RedirectToPage("/AssessmentCentre/Dashboard"),
                UserRole.ETQA => RedirectToPage("/ETQA/Dashboard"),
                UserRole.QCTO => RedirectToPage("/QCTO/Dashboard"),
                _ => RedirectToPage("/Index")
            };
        }
    }
}
