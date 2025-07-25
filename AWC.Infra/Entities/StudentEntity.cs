using AWC.Infra.Bases;
using AWC.Infra.Enums;

namespace AWC.Infra.Entities
{
    public class StudentEntity : BaseEntity
    {
#nullable disable
        public UserPermissionsEnum Permissions { get; set; }

        // Personal Information
        public string ICnumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentName { get; set; }
        public GenderEnum? Gender { get; set; }

        // Rank & Course Details
        public Guid RankId { get; set; }
        public string RankName { get; set; }
        public Guid LineDirectorateId { get; set; }
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public Guid DecorationId { get; set; }

        // Contact Information
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Guid NationalityId { get; set; }

        // Address Details
        public string CurrentAddress { get; set; }
        public string UnitAddress { get; set; }
        public string UnitPinCode { get; set; }

        // Important Dates
      //  public MaritialStatusEnum MaritialStatus { get; set; }
        public DateTime? MarriageDate { get; set; }
        public DateTime? CommissionDate { get; set; }
        public DateTime? SeniorityDate { get; set; }
        public DateTime? PresentRankDate { get; set; }
        public DateTime? BirthDate { get; set; }

        // Service Details
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public Guid RegimentId { get; set; }
        public string RegimentName { get; set; }
        public string PresentUnit { get; set; }
        public Guid PresentCommandId { get; set; }

        // Military & Academic Details
        public Guid TrainingProfileId { get; set; }
        public Guid EntryTypeId { get; set; }
        public Guid PromotionBoardId { get; set; }

        // Initiating Officer Details
        public Guid InitiatingOfficerRankId { get; set; }
        public string InitiatingOfficerName { get; set; }
        public Guid InitiatingOfficerDecorationId { get; set; }
        public Guid InitiatingOfficerServiceId { get; set; }
        public string InitiatingOfficerAddress { get; set; }
        public string InitiatingOfficerPinCode { get; set; }
        public string InitiatingOfficerMobile { get; set; }

        // Service & Academic Information
        public string CurrentAppointment { get; set; }
        public string Corps { get; set; }
        public string Division { get; set; }
        public string BDE { get; set; }
        public string CivQualification { get; set; }
        public Guid StaffQualifiedId { get; set; }
        public Guid JuniorCommandGradeId { get; set; }
        public string JuniorCommandServiceNumber { get; set; }
        public string CdaAccountNumber { get; set; }
        public string ICardNumber { get; set; }

        // Family Information
        public string SpouseName { get; set; }
        public string OriginContactNumber { get; set; }
        public string OriginAddress { get; set; }

        // Other Details
        public string OtherRemark { get; set; }
        public string ArrivalDateTime { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public Guid? TutorialId { get; set; }
        public Guid? SyndicateId { get; set; }
        public Guid? StudentSyndicateId { get; set; }
        public string AssumedSyndicate { get; set; }

        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }
        public Guid UnitId { get; set; }
        public string UnitName { get; set; }
    }

}
