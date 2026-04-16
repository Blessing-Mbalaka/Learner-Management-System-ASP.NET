using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Learner_Management_System.Data;
using Learner_Management_System.Models;

namespace Learner_Management_System.Pages_AssessmentBanks
{
    public class CreateModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public CreateModel(Learner_Management_System.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AssessorDeveloperId"] = new SelectList(_context.Users, "UserId", "Email");
        ViewData["CreatedByUserId"] = new SelectList(_context.Users, "UserId", "Email");
        ViewData["QualificationId"] = new SelectList(_context.Qualifications, "QualificationId", "QualificationName");
            return Page();
        }

        [BindProperty]
        public AssessmentBank AssessmentBank { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AssessmentBanks.Add(AssessmentBank);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
