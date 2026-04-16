using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Learner_Management_System.Data;
using Learner_Management_System.Models;

namespace Learner_Management_System.Pages_LearnerUploads
{
    public class EditModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public EditModel(Learner_Management_System.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LearnerUpload LearnerUpload { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learnerupload =  await _context.LearnerUploads.FirstOrDefaultAsync(m => m.UploadId == id);
            if (learnerupload == null)
            {
                return NotFound();
            }
            LearnerUpload = learnerupload;
           ViewData["AssessmentId"] = new SelectList(_context.Assessments, "AssessmentId", "AssessmentName");
           ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LearnerUpload).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearnerUploadExists(LearnerUpload.UploadId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LearnerUploadExists(int id)
        {
            return _context.LearnerUploads.Any(e => e.UploadId == id);
        }
    }
}
