using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Learner_Management_System.Data;
using Learner_Management_System.Models;

namespace Learner_Management_System.Pages_ClassSessions
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
        ViewData["QualificationId"] = new SelectList(_context.Qualifications, "QualificationId", "QualificationName");
        ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Email");
        ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "VenueName");
            return Page();
        }

        [BindProperty]
        public ClassSession ClassSession { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ClassSessions.Add(ClassSession);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
