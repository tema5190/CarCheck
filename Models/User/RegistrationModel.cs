using System.ComponentModel.DataAnnotations;

namespace Models.User
{
    public class RegistrationModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords are not the same")]
        public string PasswordConfirm { get; set; }
    }
}
