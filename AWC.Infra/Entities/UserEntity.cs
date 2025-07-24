using AWC.Infra.Bases;
using AWC.Infra.Enums;
using System.ComponentModel.DataAnnotations;

namespace AWC.Infra.Entities;

public class UserEntity : BaseEntity
{
#nullable disable
    [Required, MaxLength(30)]
    public string ICnumber { get; set; }

    [Required]
    public byte[] PasswordHash { get; set; }

    [Required]
    public byte[] PasswordSalt { get; set; }
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
    public string Country { get; set; }

    [Required, MaxLength(32)]
    public string City { get; set; }
}