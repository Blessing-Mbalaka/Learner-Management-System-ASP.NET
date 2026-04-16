using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Learner_Management_System.Data;
using Learner_Management_System.Models;

namespace Learner_Management_System.Pages_RandomizedPapers
{
    public class DeleteModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public DeleteModel(Learner_Management_System.Data.ApplicationDbContext context)
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

            var randomizedpaper = await _context.RandomizedPapers.FirstOrDefaultAsync(m => m.RandomizedPaperId == id);

            if (randomizedpaper is not null)
            {
                RandomizedPaper = randomizedpaper;

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

            var randomizedpaper = await _context.RandomizedPapers.FindAsync(id);
            if (randomizedpaper != null)
            {
                RandomizedPaper = randomizedpaper;
                _context.RandomizedPapers.Remove(RandomizedPaper);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
