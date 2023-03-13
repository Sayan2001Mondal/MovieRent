using System.ComponentModel.DataAnnotations;

namespace MovieRent.Web.DTOs
{
    public class AddMoviesDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Genre { get; set; }
        [Range(0,10,ErrorMessage ="Please Enter value within 0-10")]
        public int Rating { get; set; }
        [RegularExpression(@"^[A-Za-z][A-Za-z ]*[A-Za-z]$")]
        [Required]

        public string Director { get; set; }
    }
}
