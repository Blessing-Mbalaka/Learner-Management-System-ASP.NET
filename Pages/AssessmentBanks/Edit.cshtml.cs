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

namespace Learner_Management_System.Pages_AssessmentBanks
{
    public class EditModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public EditModel(Learner_Management_System.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AssessmentBank AssessmentBank { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessmentbank =  await _context.AssessmentBanks.FirstOrDefaultAsync(m => m.AssessmentBankId == id);
            if (assessmentbank == null)
            {
                return NotFound();
            }
            AssessmentBank = assessmentbank;
           ViewData["AssessorDeveloperId"] = new SelectList(_context.Users, "UserId", "Email");
           ViewData["CreatedByUserId"] = new SelectList(_context.Users, "UserId", "Email");
           ViewData["QualificationId"] = new SelectList(_context.Qualifications, "QualificationId", "QualificationName");
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

            _context.Attach(AssessmentBank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentBankExists(AssessmentBank.AssessmentBankId))
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

        private bool AssessmentBankExists(int id)
        {
            return _context.AssessmentBanks.Any(e => e.AssessmentBankId == id);
        }
    }
}
