using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Learner_Management_System.Data;
using Learner_Management_System.Models;

namespace Learner_Management_System.Pages_Venues
{
    public class DetailsModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public DetailsModel(Learner_Management_System.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Venue Venue { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _context.Venues.FirstOrDefaultAsync(m => m.VenueId == id);

            if (venue is not null)
            {
                Venue = venue;

                return Page();
            }

            return NotFound();
        }
    }
}
