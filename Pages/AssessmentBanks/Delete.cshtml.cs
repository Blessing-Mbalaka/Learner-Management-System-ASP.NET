using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Learner_Management_System.Data;
using Learner_Management_System.Models;

namespace Learner_Management_System.Pages_AssessmentBanks
{
    public class DeleteModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public DeleteModel(Learner_Management_System.Data.ApplicationDbContext context)
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

            var assessmentbank = await _context.AssessmentBanks.FirstOrDefaultAsync(m => m.AssessmentBankId == id);

            if (assessmentbank is not null)
            {
                AssessmentBank = assessmentbank;

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

            var assessmentbank = await _context.AssessmentBanks.FindAsync(id);
            if (assessmentbank != null)
            {
                AssessmentBank = assessmentbank;
                _context.AssessmentBanks.Remove(AssessmentBank);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
