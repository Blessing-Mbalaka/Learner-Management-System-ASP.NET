namespace Learner_Management_System.Models
{
    public enum DocumentWorkflowStatus
    {
        Draft = 1,
        SubmittedByAdmin = 2,
        UnderReviewByAssessorDeveloper = 3,
        ApprovedByAssessorDeveloper = 4,
        RejectedByAssessorDeveloper = 5,
        SubmittedToETQA = 6,
        UnderReviewByETQA = 7,
        ApprovedByETQA = 8,
        RejectedByETQA = 9,
        SubmittedToAssessmentCentre = 10,
        ApprovedByAssessmentCentre = 11,
        RejectedByAssessmentCentre = 12,
        SubmittedToQCTO = 13,
        UnderReviewByQCTO = 14,
        ApprovedByQCTO = 15,
        RejectedByQCTO = 16,
        PublishedToStudents = 17,
        Archived = 18
    }
}
