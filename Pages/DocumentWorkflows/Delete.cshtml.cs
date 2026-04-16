using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Learner_Management_System.Data;
using Learner_Management_System.Models;

namespace Learner_Management_System.Pages_DocumentWorkflows
{
    public class DeleteModel : PageModel
    {
        private readonly Learner_Management_System.Data.ApplicationDbContext _context;

        public DeleteModel(Learner_Management_System.Data.ApplicationDbContext context)
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

            var documentworkflow = await _context.DocumentWorkflows.FirstOrDefaultAsync(m => m.WorkflowId == id);

            if (documentworkflow is not null)
            {
                DocumentWorkflow = documentworkflow;

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

            var documentworkflow = await _context.DocumentWorkflows.FindAsync(id);
            if (documentworkflow != null)
            {
                DocumentWorkflow = documentworkflow;
                _context.DocumentWorkflows.Remove(DocumentWorkflow);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
