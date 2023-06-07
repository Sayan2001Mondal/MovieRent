using MovieRent.Web.DTOs;
using MovieRent.Web.Infrastructure;

namespace MovieRent.Web.Services
{
    public interface IMoviesService
    {
        ServiceResponse<List<GetMoviesDTO>> GetMovieList();
        ServiceResponse<GetMoviesDTO> GetSingleMovie(int id);
        Task<String> AddMovie(AddMoviesDTO newMovie);
        Task<String> UpdateMovie(UpdateMoviesDTO Movie);
        Task<String> DeleteMovie(int id);
    }
}
