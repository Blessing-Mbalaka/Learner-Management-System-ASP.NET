using Learner_Management_System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Learner_Management_System.Pages.Student
{
    [Authorize]
    public class StudentDashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public StudentDashboardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int ActiveEnrollments { get; set; }
        public int PendingAssignments { get; set; }
        public decimal AverageGrade { get; set; }
        public decimal AttendanceRate { get; set; }
        public List<CourseInfo> MyCourses { get; set; } = new();

        public async Task OnGetAsync()
        {
            var userEmail = User.Identity?.Name;
            var learner = await _context.Learners.FirstOrDefaultAsync(l => l.Email == userEmail);

            if (learner != null)
            {
                // Get active enrollments
                var enrollments = await _context.Enrollments
                    .Include(e => e.Qualification)
                    .Where(e => e.LearnerId == learner.LearnerId)
                    .ToListAsync();

                ActiveEnrollments = enrollments.Count(e => e.Status == "Active");

                // Get grades
                var grades = await _context.Grades
                    .Where(g => g.LearnerId == learner.LearnerId)
                    .ToListAsync();

                AverageGrade = grades.Any() ? grades.Average(g => g.Score) : 0;

                // Get attendance
                var totalClasses = await _context.Attendances.CountAsync(a => a.LearnerId == learner.LearnerId);
                var presentClasses = await _context.Attendances
                    .CountAsync(a => a.LearnerId == learner.LearnerId && a.Status == "Present");
                
                AttendanceRate = totalClasses > 0 ? (decimal)presentClasses / totalClasses * 100 : 0;

                // Get pending assignments
                PendingAssignments = await _context.Assessments
                    .Where(a => enrollments.Select(e => e.QualificationId).Contains(a.QualificationId))
                    .Where(a => !grades.Select(g => g.AssessmentId).Contains(a.AssessmentId))
                    .CountAsync();

                // Get course list
                MyCourses = enrollments.Select(e => new CourseInfo
                {
                    EnrollmentId = e.EnrollmentId,
                    CourseName = e.Qualification?.QualificationName ?? "Unknown",
                    Status = e.Status,
                    Grade = e.FinalGrade
                }).ToList();
            }
        }

        public class CourseInfo
        {
            public int EnrollmentId { get; set; }
            public string CourseName { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
            public decimal? Grade { get; set; }
        }
    }
}
