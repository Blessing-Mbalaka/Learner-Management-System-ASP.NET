using Learner_Management_System.Data;
using Learner_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Learner_Management_System.Pages.QCTO
{
    [Authorize]
    public class QCTODashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public QCTODashboardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int PendingReviewCount { get; set; }
        public int ApprovedCount { get; set; }
        public int RejectedCount { get; set; }
        public List<PendingDocument> PendingDocuments { get; set; } = new();

        public async Task OnGetAsync()
        {
            // Get documents awaiting QCTO review
            var workflows = await _context.DocumentWorkflows
                .Where(w => w.Status == DocumentWorkflowStatus.SubmittedToQCTO || 
                           w.Status == DocumentWorkflowStatus.UnderReviewByQCTO)
                .Include(w => w.AssessmentBank)
                    .ThenInclude(ab => ab!.Qualification)
                .Include(w => w.RandomizedPaper)
                    .ThenInclude(rp => rp!.Qualification)
                .Include(w => w.AdminUpload)
                    .ThenInclude(au => au!.Qualification)
                .ToListAsync();

            PendingReviewCount = workflows.Count(w => w.Status == DocumentWorkflowStatus.SubmittedToQCTO);
            
            ApprovedCount = await _context.DocumentWorkflows
                .CountAsync(w => w.Status == DocumentWorkflowStatus.ApprovedByQCTO);
            
            RejectedCount = await _context.DocumentWorkflows
                .CountAsync(w => w.Status == DocumentWorkflowStatus.RejectedByQCTO);

            PendingDocuments = workflows.Select(w => new PendingDocument
            {
                DocumentType = w.AssessmentBank != null ? "Assessment Bank" :
                              w.RandomizedPaper != null ? "Randomized Paper" : "Admin Upload",
                Title = w.AssessmentBank?.BankName ?? 
                       w.RandomizedPaper?.PaperName ?? 
                       w.AdminUpload?.FileName ?? "Unknown",
                QualificationName = w.AssessmentBank?.Qualification?.QualificationName ??
                                   w.RandomizedPaper?.Qualification?.QualificationName ??
                                   w.AdminUpload?.Qualification?.QualificationName ?? "N/A",
                SubmittedDate = w.ActionDate,
                ReviewUrl = w.AssessmentBank != null ? $"/AssessmentBanks/Details?id={w.AssessmentBankId}" :
                           w.RandomizedPaper != null ? $"/RandomizedPapers/Details?id={w.RandomizedPaperId}" :
                           $"/AdminUploads/Details?id={w.AdminUploadId}"
            }).ToList();
        }

        public class PendingDocument
        {
            public string DocumentType { get; set; } = string.Empty;
            public string Title { get; set; } = string.Empty;
            public string QualificationName { get; set; } = string.Empty;
            public DateTime SubmittedDate { get; set; }
            public string ReviewUrl { get; set; } = string.Empty;
        }
    }
}
