using System.ComponentModel.DataAnnotations;

namespace AuthorizationWebApp.Models
{
    public class Login
    {

        [Required(ErrorMessage = "Please enter E-Mail.")]
        [EmailAddress(ErrorMessage = "Email must have @ symbol.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter Password.")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Password must have min 8 and max 25 symbols.")]
        public string? Password { get; set; }
    }

}
