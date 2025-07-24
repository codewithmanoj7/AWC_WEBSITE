using System.ComponentModel.DataAnnotations;

namespace AWC.Infra.Models
{
    public class LoginModel
    {
        [Required, MinLength(5), MaxLength(30)]
        public string ICnumber { get; set; } = "";
        [Required, MinLength(8), MaxLength(30)]
        public string Password { get; set; } = "";
        public bool RememberUser { get; set; }
        public void ClearFields()
        {
            ICnumber = "";
            Password = "";
            RememberUser = false;
        }
    }
}
