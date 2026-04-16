using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Learner_Management_System.Data;
using Learner_Management_System.Models;

namespace Learner_Management_System.Pages_DocumentWorkflows
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
        ViewData["ActionByUserId"] = new SelectList(_context.Users, "UserId", "Email");
        ViewData["AdminUploadId"] = new SelectList(_context.AdminUploads, "UploadId", "FileName");
        ViewData["AssessmentId"] = new SelectList(_context.Assessments, "AssessmentId", "AssessmentName");
        ViewData["AssessmentBankId"] = new SelectList(_context.AssessmentBanks, "AssessmentBankId", "BankName");
        ViewData["RandomizedPaperId"] = new SelectList(_context.RandomizedPapers, "RandomizedPaperId", "FileName");
            return Page();
        }

        [BindProperty]
        public DocumentWorkflow DocumentWorkflow { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DocumentWorkflows.Add(DocumentWorkflow);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
