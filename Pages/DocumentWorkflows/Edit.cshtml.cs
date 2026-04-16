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

namespace Learner_Management_System.Pages_DocumentWorkflows
{
    public class EditModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public EditModel(Learner_Management_System.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DocumentWorkflow DocumentWorkflow { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentworkflow =  await _context.DocumentWorkflows.FirstOrDefaultAsync(m => m.WorkflowId == id);
            if (documentworkflow == null)
            {
                return NotFound();
            }
            DocumentWorkflow = documentworkflow;
           ViewData["ActionByUserId"] = new SelectList(_context.Users, "UserId", "Email");
           ViewData["AdminUploadId"] = new SelectList(_context.AdminUploads, "UploadId", "FileName");
           ViewData["AssessmentId"] = new SelectList(_context.Assessments, "AssessmentId", "AssessmentName");
           ViewData["AssessmentBankId"] = new SelectList(_context.AssessmentBanks, "AssessmentBankId", "BankName");
           ViewData["RandomizedPaperId"] = new SelectList(_context.RandomizedPapers, "RandomizedPaperId", "FileName");
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

            _context.Attach(DocumentWorkflow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentWorkflowExists(DocumentWorkflow.WorkflowId))
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

        private bool DocumentWorkflowExists(int id)
        {
            return _context.DocumentWorkflows.Any(e => e.WorkflowId == id);
        }
    }
}
