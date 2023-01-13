namespace MovieRent.Web.DTOs
{
    public class GetMoviesDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public string Director { get; set; }
    }
}
