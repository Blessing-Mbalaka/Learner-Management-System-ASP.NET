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
    public class DeleteModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public DeleteModel(Learner_Management_System.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AdminUpload AdminUpload { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminupload = await _context.AdminUploads.FirstOrDefaultAsync(m => m.UploadId == id);

            if (adminupload is not null)
            {
                AdminUpload = adminupload;

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

            var adminupload = await _context.AdminUploads.FindAsync(id);
            if (adminupload != null)
            {
                AdminUpload = adminupload;
                _context.AdminUploads.Remove(AdminUpload);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
