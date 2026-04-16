using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learner_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    CostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CostType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.CostId);
                });

            migrationBuilder.CreateTable(
                name: "Learners",
                columns: table => new
                {
                    LearnerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Learners", x => x.LearnerId);
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    QualificationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QualificationName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    QualificationCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    DurationInHours = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.QualificationId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Specialization = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    HireDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VenueName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Facilities = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueId);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QualificationId = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Department = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    HireDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admins_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "QualificationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LearnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    QualificationId = table.Column<int>(type: "INTEGER", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FinalGrade = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Learners_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "Learners",
                        principalColumn: "LearnerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "QualificationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualificationCosts",
                columns: table => new
                {
                    QualificationCostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QualificationId = table.Column<int>(type: "INTEGER", nullable: false),
                    CostId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationCosts", x => x.QualificationCostId);
                    table.ForeignKey(
                        name: "FK_QualificationCosts_Costs_CostId",
                        column: x => x.CostId,
                        principalTable: "Costs",
                        principalColumn: "CostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualificationCosts_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "QualificationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    QualificationId = table.Column<int>(type: "INTEGER", nullable: true),
                    Department = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Specialization = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "QualificationId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ClassSessions",
                columns: table => new
                {
                    ClassSessionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QualificationId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    VenueId = table.Column<int>(type: "INTEGER", nullable: false),
                    SessionName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MaxCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsCancelled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSessions", x => x.ClassSessionId);
                    table.ForeignKey(
                        name: "FK_ClassSessions_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "QualificationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassSessions_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassSessions_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "VenueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdminUploads",
                columns: table => new
                {
                    UploadId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdminId = table.Column<int>(type: "INTEGER", nullable: false),
                    QualificationId = table.Column<int>(type: "INTEGER", nullable: true),
                    FileName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    FileType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FileSize = table.Column<long>(type: "INTEGER", nullable: false),
                    UploadCategory = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    FileData = table.Column<byte[]>(type: "BLOB", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsPublished = table.Column<bool>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    UploadedByUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUploads", x => x.UploadId);
                    table.ForeignKey(
                        name: "FK_AdminUploads_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminUploads_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "QualificationId");
                    table.ForeignKey(
                        name: "FK_AdminUploads_Users_UploadedByUserId",
                        column: x => x.UploadedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "AssessmentBanks",
                columns: table => new
                {
                    AssessmentBankId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QualificationId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    AssessorDeveloperId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Version = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentBanks", x => x.AssessmentBankId);
                    table.ForeignKey(
                        name: "FK_AssessmentBanks_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "QualificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentBanks_Users_AssessorDeveloperId",
                        column: x => x.AssessorDeveloperId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_AssessmentBanks_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LearnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassSessionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_Attendances_ClassSessions_ClassSessionId",
                        column: x => x.ClassSessionId,
                        principalTable: "ClassSessions",
                        principalColumn: "ClassSessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Learners_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "Learners",
                        principalColumn: "LearnerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LearnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClassSessionId = table.Column<int>(type: "INTEGER", nullable: true),
                    FeedbackText = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: true),
                    FeedbackDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_ClassSessions_ClassSessionId",
                        column: x => x.ClassSessionId,
                        principalTable: "ClassSessions",
                        principalColumn: "ClassSessionId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Learners_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "Learners",
                        principalColumn: "LearnerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QualificationId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssessmentBankId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    AssessmentName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    AssessmentType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MaxScore = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PassingScore = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    WeightPercentage = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.AssessmentId);
                    table.ForeignKey(
                        name: "FK_Assessments_AssessmentBanks_AssessmentBankId",
                        column: x => x.AssessmentBankId,
                        principalTable: "AssessmentBanks",
                        principalColumn: "AssessmentBankId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Assessments_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "QualificationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assessments_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "RandomizedPapers",
                columns: table => new
                {
                    RandomizedPaperId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssessmentBankId = table.Column<int>(type: "INTEGER", nullable: false),
                    QualificationId = table.Column<int>(type: "INTEGER", nullable: true),
                    UploadedByUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    PaperName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    PaperVersion = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    FileName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    FileType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FileSize = table.Column<long>(type: "INTEGER", nullable: false),
                    FileData = table.Column<byte[]>(type: "BLOB", nullable: false),
                    RandomizationSeed = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    QuestionPoolSize = table.Column<int>(type: "INTEGER", nullable: true),
                    QuestionsPerPaper = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomizedPapers", x => x.RandomizedPaperId);
                    table.ForeignKey(
                        name: "FK_RandomizedPapers_AssessmentBanks_AssessmentBankId",
                        column: x => x.AssessmentBankId,
                        principalTable: "AssessmentBanks",
                        principalColumn: "AssessmentBankId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RandomizedPapers_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "QualificationId");
                    table.ForeignKey(
                        name: "FK_RandomizedPapers_Users_UploadedByUserId",
                        column: x => x.UploadedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LearnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssessmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    LetterGrade = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Comments = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    GradeDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grades_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Learners_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "Learners",
                        principalColumn: "LearnerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LearnerUploads",
                columns: table => new
                {
                    UploadId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LearnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssessmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    FileName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    FileType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FileSize = table.Column<long>(type: "INTEGER", nullable: false),
                    UploadCategory = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    FileData = table.Column<byte[]>(type: "BLOB", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    ReviewComments = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearnerUploads", x => x.UploadId);
                    table.ForeignKey(
                        name: "FK_LearnerUploads_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_LearnerUploads_Learners_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "Learners",
                        principalColumn: "LearnerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentWorkflows",
                columns: table => new
                {
                    WorkflowId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DocumentType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    AssessmentBankId = table.Column<int>(type: "INTEGER", nullable: true),
                    AdminUploadId = table.Column<int>(type: "INTEGER", nullable: true),
                    AssessmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    RandomizedPaperId = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    PreviousStatus = table.Column<int>(type: "INTEGER", nullable: true),
                    ActionByUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Feedback = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    ActionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentWorkflows", x => x.WorkflowId);
                    table.ForeignKey(
                        name: "FK_DocumentWorkflows_AdminUploads_AdminUploadId",
                        column: x => x.AdminUploadId,
                        principalTable: "AdminUploads",
                        principalColumn: "UploadId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DocumentWorkflows_AssessmentBanks_AssessmentBankId",
                        column: x => x.AssessmentBankId,
                        principalTable: "AssessmentBanks",
                        principalColumn: "AssessmentBankId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DocumentWorkflows_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DocumentWorkflows_RandomizedPapers_RandomizedPaperId",
                        column: x => x.RandomizedPaperId,
                        principalTable: "RandomizedPapers",
                        principalColumn: "RandomizedPaperId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DocumentWorkflows_Users_ActionByUserId",
                        column: x => x.ActionByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_QualificationId",
                table: "Admins",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUploads_AdminId",
                table: "AdminUploads",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUploads_QualificationId",
                table: "AdminUploads",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUploads_UploadedByUserId",
                table: "AdminUploads",
                column: "UploadedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentBanks_AssessorDeveloperId",
                table: "AssessmentBanks",
                column: "AssessorDeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentBanks_CreatedByUserId",
                table: "AssessmentBanks",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentBanks_QualificationId",
                table: "AssessmentBanks",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_AssessmentBankId",
                table: "Assessments",
                column: "AssessmentBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_CreatedByUserId",
                table: "Assessments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_QualificationId",
                table: "Assessments",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_Status",
                table: "Assessments",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_ClassSessionId",
                table: "Attendances",
                column: "ClassSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_LearnerId",
                table: "Attendances",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSessions_QualificationId",
                table: "ClassSessions",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSessions_TeacherId",
                table: "ClassSessions",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSessions_VenueId",
                table: "ClassSessions",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentWorkflows_ActionByUserId",
                table: "DocumentWorkflows",
                column: "ActionByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentWorkflows_AdminUploadId",
                table: "DocumentWorkflows",
                column: "AdminUploadId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentWorkflows_AssessmentBankId",
                table: "DocumentWorkflows",
                column: "AssessmentBankId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentWorkflows_AssessmentId",
                table: "DocumentWorkflows",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentWorkflows_RandomizedPaperId",
                table: "DocumentWorkflows",
                column: "RandomizedPaperId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentWorkflows_Status",
                table: "DocumentWorkflows",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_LearnerId",
                table: "Enrollments",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_QualificationId",
                table: "Enrollments",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_Status",
                table: "Enrollments",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ClassSessionId",
                table: "Feedbacks",
                column: "ClassSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_LearnerId",
                table: "Feedbacks",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_TeacherId",
                table: "Feedbacks",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_AssessmentId",
                table: "Grades",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_LearnerId",
                table: "Grades",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Learners_Email",
                table: "Learners",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LearnerUploads_AssessmentId",
                table: "LearnerUploads",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerUploads_LearnerId",
                table: "LearnerUploads",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_QualificationCosts_CostId",
                table: "QualificationCosts",
                column: "CostId");

            migrationBuilder.CreateIndex(
                name: "IX_QualificationCosts_QualificationId",
                table: "QualificationCosts",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_QualificationCode",
                table: "Qualifications",
                column: "QualificationCode");

            migrationBuilder.CreateIndex(
                name: "IX_RandomizedPapers_AssessmentBankId",
                table: "RandomizedPapers",
                column: "AssessmentBankId");

            migrationBuilder.CreateIndex(
                name: "IX_RandomizedPapers_QualificationId",
                table: "RandomizedPapers",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_RandomizedPapers_UploadedByUserId",
                table: "RandomizedPapers",
                column: "UploadedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Email",
                table: "Teachers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_QualificationId",
                table: "Users",
                column: "QualificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "DocumentWorkflows");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "LearnerUploads");

            migrationBuilder.DropTable(
                name: "QualificationCosts");

            migrationBuilder.DropTable(
                name: "AdminUploads");

            migrationBuilder.DropTable(
                name: "RandomizedPapers");

            migrationBuilder.DropTable(
                name: "ClassSessions");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Learners");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "AssessmentBanks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Qualifications");
        }
    }
}
