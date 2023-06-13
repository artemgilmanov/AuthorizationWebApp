using System.ComponentModel.DataAnnotations;

namespace AuthorizationWebApp.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Please enter Firstname.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Firstname must have min 2 and max 15 symbols.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Lastname.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Lastname must have min 2 and max 15 symbols.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter Email.")]
        [EmailAddress(ErrorMessage = "Email must have @ symbol.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Password must have min 8 and max 15 symbols.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [Compare("Password", ErrorMessage = "Passwords don't match.")]
        public string? RepeatPasswort { get; set; }

    }
}