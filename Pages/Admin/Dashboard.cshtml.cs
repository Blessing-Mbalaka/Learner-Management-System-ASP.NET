using Learner_Management_System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Learner_Management_System.Pages.Admin
{
    [Authorize]
    public class AdminDashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdminDashboardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int TotalAssessmentBanks { get; set; }
        public int PendingApproval { get; set; }
        public int Published { get; set; }
        public int TotalUploads { get; set; }
        public List<BankInfo> RecentBanks { get; set; } = new();

        public async Task OnGetAsync()
        {
            TotalAssessmentBanks = await _context.AssessmentBanks.CountAsync();
            
            PendingApproval = await _context.AssessmentBanks
                .CountAsync(ab => ab.Status == Models.DocumentWorkflowStatus.SubmittedByAdmin ||
                                 ab.Status == Models.DocumentWorkflowStatus.UnderReviewByAssessorDeveloper);
            
            Published = await _context.AssessmentBanks
                .CountAsync(ab => ab.Status == Models.DocumentWorkflowStatus.PublishedToStudents);
            
            TotalUploads = await _context.AdminUploads.CountAsync();

            RecentBanks = await _context.AssessmentBanks
                .Include(ab => ab.Qualification)
                .OrderByDescending(ab => ab.CreatedDate)
                .Take(10)
                .Select(ab => new BankInfo
                {
                    BankId = ab.AssessmentBankId,
                    BankName = ab.BankName,
                    QualificationName = ab.Qualification!.QualificationName,
                    Status = ab.Status.ToString()
                })
                .ToListAsync();
        }

        public class BankInfo
        {
            public int BankId { get; set; }
            public string BankName { get; set; } = string.Empty;
            public string QualificationName { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
        }
    }
}
