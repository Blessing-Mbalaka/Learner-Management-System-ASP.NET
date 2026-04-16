using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Learner_Management_System.Data;
using Learner_Management_System.Models;

namespace Learner_Management_System.Pages_Teachers
{
    public class DetailsModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public DetailsModel(Learner_Management_System.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Teacher Teacher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers.FirstOrDefaultAsync(m => m.TeacherId == id);

            if (teacher is not null)
            {
                Teacher = teacher;

                return Page();
            }

            return NotFound();
        }
    }
}
