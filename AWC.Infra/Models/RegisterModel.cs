using AWC.Infra.Bases;
using AWC.Infra.Enums;
namespace AWC.Infra.Models
{
    public class RegisterModel : BaseEntity
    {
#nullable disable
        public string ICnumber { get; set; }
        public int RankId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; } = "India";
        public string Password { get; set; }
        public DateTime CommissionDate { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? SeniorityDate { get; set; }
        public GenderEnum Gender { get; set; }
        public int LineDirectorateId { get; set; }
        public int RegimentId { get; set; }
        public string Division { get; set; }
        public string PresentUnit { get; set; }
        public string UnitAddress { get; set; }
        public string UnitPinCode { get; set; }
        public int PresentCommandId { get; set; }
        public string CurrentAddress { get; set; }
        public string CdaAccountNumber { get; set; }
        public string ICardNumber { get; set; }
        public string MaritialStatus { get; set; }
        public string SpouseName { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int NationalityId { get; set; }
        public string ArrivalDateTime { get; set; }
    }

}
