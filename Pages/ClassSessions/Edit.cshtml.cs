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

namespace Learner_Management_System.Pages_ClassSessions
{
    public class EditModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public EditModel(Learner_Management_System.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClassSession ClassSession { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classsession =  await _context.ClassSessions.FirstOrDefaultAsync(m => m.ClassSessionId == id);
            if (classsession == null)
            {
                return NotFound();
            }
            ClassSession = classsession;
           ViewData["QualificationId"] = new SelectList(_context.Qualifications, "QualificationId", "QualificationName");
           ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Email");
           ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "VenueName");
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

            _context.Attach(ClassSession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassSessionExists(ClassSession.ClassSessionId))
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

        private bool ClassSessionExists(int id)
        {
            return _context.ClassSessions.Any(e => e.ClassSessionId == id);
        }
    }
}
