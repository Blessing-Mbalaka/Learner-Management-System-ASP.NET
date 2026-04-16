using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Learner_Management_System.Data;
using Learner_Management_System.Models;

namespace Learner_Management_System.Pages_LearnerUploads
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
        ViewData["AssessmentId"] = new SelectList(_context.Assessments, "AssessmentId", "AssessmentName");
        ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "Email");
            return Page();
        }

        [BindProperty]
        public LearnerUpload LearnerUpload { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LearnerUploads.Add(LearnerUpload);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
