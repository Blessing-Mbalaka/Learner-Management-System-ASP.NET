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

namespace Learner_Management_System.Pages_RandomizedPapers
{
    public class EditModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public EditModel(Learner_Management_System.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RandomizedPaper RandomizedPaper { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randomizedpaper =  await _context.RandomizedPapers.FirstOrDefaultAsync(m => m.RandomizedPaperId == id);
            if (randomizedpaper == null)
            {
                return NotFound();
            }
            RandomizedPaper = randomizedpaper;
           ViewData["AssessmentBankId"] = new SelectList(_context.AssessmentBanks, "AssessmentBankId", "BankName");
           ViewData["QualificationId"] = new SelectList(_context.Qualifications, "QualificationId", "QualificationName");
           ViewData["UploadedByUserId"] = new SelectList(_context.Users, "UserId", "Email");
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

            _context.Attach(RandomizedPaper).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RandomizedPaperExists(RandomizedPaper.RandomizedPaperId))
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

        private bool RandomizedPaperExists(int id)
        {
            return _context.RandomizedPapers.Any(e => e.RandomizedPaperId == id);
        }
    }
}
