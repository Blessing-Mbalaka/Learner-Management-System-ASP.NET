using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Learner_Management_System.Data;
using Learner_Management_System.Models;

namespace Learner_Management_System.Pages_AdminUploads
{
    public class IndexModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public IndexModel(Learner_Management_System.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AdminUpload> AdminUpload { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AdminUpload = await _context.AdminUploads
                .Include(a => a.Admin)
                .Include(a => a.Qualification)
                .Include(a => a.UploadedBy).ToListAsync();
        }
    }
}
