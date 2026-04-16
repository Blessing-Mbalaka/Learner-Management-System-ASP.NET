using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Learner_Management_System.Data;
using Learner_Management_System.Models;

namespace Learner_Management_System.Pages_Assessments
{
    public class DeleteModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public DeleteModel(Learner_Management_System.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assessment Assessment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments.FirstOrDefaultAsync(m => m.AssessmentId == id);

            if (assessment is not null)
            {
                Assessment = assessment;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment != null)
            {
                Assessment = assessment;
                _context.Assessments.Remove(Assessment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
