using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Learner_Management_System.Data;
using Learner_Management_System.Models;

namespace Learner_Management_System.Pages_Costs
{
    public class DeleteModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public DeleteModel(Learner_Management_System.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cost Cost { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cost = await _context.Costs.FirstOrDefaultAsync(m => m.CostId == id);

            if (cost is not null)
            {
                Cost = cost;

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

            var cost = await _context.Costs.FindAsync(id);
            if (cost != null)
            {
                Cost = cost;
                _context.Costs.Remove(Cost);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
