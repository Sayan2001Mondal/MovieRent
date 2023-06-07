using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieRent.Web.DTOs
{
    public class LoginDTO
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
