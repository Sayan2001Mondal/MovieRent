using MovieRent.Web.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieRent.Web.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [RegularExpression(@"^[A-Za-z][A-Za-z ]*[A-Za-z]$")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        
    }
}
