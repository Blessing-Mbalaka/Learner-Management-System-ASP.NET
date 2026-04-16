using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Learner_Management_System.Models;

namespace Learner_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Core Entities
        public DbSet<Learners> Learners { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Venue> Venues { get; set; }

        // Academic Management
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<ClassSession> ClassSessions { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        // Financial
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Qualification_cost> QualificationCosts { get; set; }

        // File Uploads
        public DbSet<LearnerUpload> LearnerUploads { get; set; }
        public DbSet<AdminUpload> AdminUploads { get; set; }
        public DbSet<RandomizedPaper> RandomizedPapers { get; set; }

        // User & Roles
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }

        // Workflow System
        public DbSet<DocumentWorkflow> DocumentWorkflows { get; set; }
        public DbSet<AssessmentBank> AssessmentBanks { get; set; }

        // Engagement
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure table names (optional - using singular names)
            modelBuilder.Entity<Learners>().ToTable("Learners");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Qualification>().ToTable("Qualifications");
            modelBuilder.Entity<Venue>().ToTable("Venues");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollments");
            modelBuilder.Entity<ClassSession>().ToTable("ClassSessions");
            modelBuilder.Entity<Assessment>().ToTable("Assessments");
            modelBuilder.Entity<Grades>().ToTable("Grades");
            modelBuilder.Entity<Attendance>().ToTable("Attendances");
            modelBuilder.Entity<Cost>().ToTable("Costs");
            modelBuilder.Entity<Qualification_cost>().ToTable("QualificationCosts");
            modelBuilder.Entity<LearnerUpload>().ToTable("LearnerUploads");
            modelBuilder.Entity<AdminUpload>().ToTable("AdminUploads");
            modelBuilder.Entity<RandomizedPaper>().ToTable("RandomizedPapers");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<DocumentWorkflow>().ToTable("DocumentWorkflows");
            modelBuilder.Entity<AssessmentBank>().ToTable("AssessmentBanks");
            modelBuilder.Entity<Feedback>().ToTable("Feedbacks");

            // Configure relationships and constraints
            
            // Learners relationships
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Learner)
                .WithMany(l => l.Enrollments)
                .HasForeignKey(e => e.LearnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grades>()
                .HasOne(g => g.Learner)
                .WithMany(l => l.Grades)
                .HasForeignKey(g => g.LearnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Learner)
                .WithMany(l => l.Attendances)
                .HasForeignKey(a => a.LearnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LearnerUpload>()
                .HasOne(lu => lu.Learner)
                .WithMany(l => l.Uploads)
                .HasForeignKey(lu => lu.LearnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Qualification relationships
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Qualification)
                .WithMany(q => q.Enrollments)
                .HasForeignKey(e => e.QualificationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClassSession>()
                .HasOne(cs => cs.Qualification)
                .WithMany(q => q.ClassSessions)
                .HasForeignKey(cs => cs.QualificationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Assessment>()
                .HasOne(a => a.Qualification)
                .WithMany(q => q.Assessments)
                .HasForeignKey(a => a.QualificationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Teacher relationships
            modelBuilder.Entity<ClassSession>()
                .HasOne(cs => cs.Teacher)
                .WithMany(t => t.ClassSessions)
                .HasForeignKey(cs => cs.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            // Venue relationships
            modelBuilder.Entity<ClassSession>()
                .HasOne(cs => cs.Venue)
                .WithMany(v => v.ClassSessions)
                .HasForeignKey(cs => cs.VenueId)
                .OnDelete(DeleteBehavior.Restrict);

            // Assessment relationships
            modelBuilder.Entity<Grades>()
                .HasOne(g => g.Assessment)
                .WithMany(a => a.Grades)
                .HasForeignKey(g => g.AssessmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LearnerUpload>()
                .HasOne(lu => lu.Assessment)
                .WithMany(a => a.Uploads)
                .HasForeignKey(lu => lu.AssessmentId)
                .OnDelete(DeleteBehavior.SetNull);

            // AssessmentBank relationships
            modelBuilder.Entity<Assessment>()
                .HasOne(a => a.AssessmentBank)
                .WithMany(ab => ab.Assessments)
                .HasForeignKey(a => a.AssessmentBankId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<RandomizedPaper>()
                .HasOne(rp => rp.AssessmentBank)
                .WithMany(ab => ab.RandomizedPapers)
                .HasForeignKey(rp => rp.AssessmentBankId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cost relationships
            modelBuilder.Entity<Qualification_cost>()
                .HasOne(qc => qc.Qualification)
                .WithMany(q => q.QualificationCosts)
                .HasForeignKey(qc => qc.QualificationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Qualification_cost>()
                .HasOne(qc => qc.Cost)
                .WithMany(c => c.QualificationCosts)
                .HasForeignKey(qc => qc.CostId)
                .OnDelete(DeleteBehavior.Restrict);

            // User relationships
            modelBuilder.Entity<User>()
                .HasOne(u => u.Qualification)
                .WithMany(q => q.Users)
                .HasForeignKey(u => u.QualificationId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Qualification)
                .WithMany(q => q.Admins)
                .HasForeignKey(a => a.QualificationId)
                .OnDelete(DeleteBehavior.Restrict);

            // DocumentWorkflow relationships
            modelBuilder.Entity<DocumentWorkflow>()
                .HasOne(dw => dw.AssessmentBank)
                .WithMany(ab => ab.WorkflowHistory)
                .HasForeignKey(dw => dw.AssessmentBankId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<DocumentWorkflow>()
                .HasOne(dw => dw.AdminUpload)
                .WithMany(au => au.WorkflowHistory)
                .HasForeignKey(dw => dw.AdminUploadId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<DocumentWorkflow>()
                .HasOne(dw => dw.Assessment)
                .WithMany(a => a.WorkflowHistory)
                .HasForeignKey(dw => dw.AssessmentId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<DocumentWorkflow>()
                .HasOne(dw => dw.RandomizedPaper)
                .WithMany(rp => rp.WorkflowHistory)
                .HasForeignKey(dw => dw.RandomizedPaperId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<DocumentWorkflow>()
                .HasOne(dw => dw.ActionBy)
                .WithMany(u => u.WorkflowActions)
                .HasForeignKey(dw => dw.ActionByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Feedback relationships
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Learner)
                .WithMany(l => l.Feedbacks)
                .HasForeignKey(f => f.LearnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Teacher)
                .WithMany(t => t.Feedbacks)
                .HasForeignKey(f => f.TeacherId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.ClassSession)
                .WithMany(cs => cs.Feedbacks)
                .HasForeignKey(f => f.ClassSessionId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes for performance
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Learners>().HasIndex(l => l.Email).IsUnique();
            modelBuilder.Entity<Teacher>().HasIndex(t => t.Email).IsUnique();
            modelBuilder.Entity<Qualification>().HasIndex(q => q.QualificationCode);
            modelBuilder.Entity<Assessment>().HasIndex(a => a.Status);
            modelBuilder.Entity<DocumentWorkflow>().HasIndex(dw => dw.Status);
            modelBuilder.Entity<Enrollment>().HasIndex(e => e.Status);

            // ApplicationUser configuration
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Qualification)
                .WithMany()
                .HasForeignKey(u => u.QualificationId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
