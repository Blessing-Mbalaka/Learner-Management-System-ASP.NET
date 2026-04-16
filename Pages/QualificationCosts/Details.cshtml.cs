using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Learner_Management_System.Data;
using Learner_Management_System.Models;

namespace Learner_Management_System.Pages_QualificationCosts
{
    public class DetailsModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public DetailsModel(Learner_Management_System.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Qualification_cost Qualification_cost { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualification_cost = await _context.QualificationCosts.FirstOrDefaultAsync(m => m.QualificationCostId == id);

            if (qualification_cost is not null)
            {
                Qualification_cost = qualification_cost;

                return Page();
            }

            return NotFound();
        }
    }
}
