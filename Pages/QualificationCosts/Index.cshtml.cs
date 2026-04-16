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
    public class IndexModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public IndexModel(Learner_Management_System.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Qualification_cost> Qualification_cost { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Qualification_cost = await _context.QualificationCosts
                .Include(q => q.Cost)
                .Include(q => q.Qualification).ToListAsync();
        }
    }
}
