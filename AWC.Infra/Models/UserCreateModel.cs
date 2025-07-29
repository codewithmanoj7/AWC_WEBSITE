using AWC.Infra.Enums;
using System.ComponentModel.DataAnnotations;

namespace AWC.Infra.Models
{
    public class UserCreateModel
    {
        public Guid Id { get; set; }

#nullable disable
        [Required, MaxLength(30)]
        public string ICnumber { get; set; }

        [Required, MinLength(8), MaxLength(30)]
        public string Password { get; set; } = "";
        public GenderEnum Gender { get; set; }
        public UserPermissionsEnum Permissions { get; set; }

        [Required, MaxLength(30)]
        public string FirstName { get; set; }

        [Required, MaxLength(30)]
        public string LastName { get; set; }

        [Required, MaxLength(128)]
        public string Email { get; set; }

        [Required, MaxLength(16)]
        public string PhoneNumber { get; set; }

        [Required, MaxLength(32)]
        public string Country { get; set; } = "India";

        [Required, MaxLength(32)]
        public string City { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

}
