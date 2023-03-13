using AutoMapper;
using MovieRent.Web.DTOs;
using MovieRent.Web.Infrastructure;
using MovieRent.Web.Models;

namespace MovieRent.Web.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly DbMeow _Dbobject;
        private readonly IMapper _mapper;

        public MoviesService(DbMeow Dbobject,IMapper mapper)
        {
            _Dbobject=Dbobject;
            _mapper=mapper;
        }
        public async Task<string> AddMovie(AddMoviesDTO newMovie)
        {
            try
            {
                _Dbobject.MoviesTable.Add(_mapper.Map<Movies>(newMovie));
                await _Dbobject.SaveChangesAsync();
                return "Movie Added";
            }
            catch (Exception ex)
            {
                new Error(ex);
                return (ex.Message);
            }

        }

        public async Task<string> DeleteMovie(int id)
        {
            try
            {
                var result = _Dbobject.MoviesTable.FirstOrDefault(c => c.Id == id);
                _Dbobject.MoviesTable.Remove(result);
                await _Dbobject.SaveChangesAsync();
                return "Successfully Deleted";
                
            }
            catch (Exception ex)
            {
                new Error(ex);
                return (ex.Message);
            }
        }

        public ServiceResponse<List<GetMoviesDTO>> GetMovieList()
        {
            var Response = new ServiceResponse<List<GetMoviesDTO>>();
            try
            {
                
                var result = _Dbobject.MoviesTable.ToList();
                Response.Data = result.Select(c => _mapper.Map<GetMoviesDTO>(c)).ToList();
                Response.Message = "Successfully Fetched the List";
            }
            catch (Exception ex)
            {
                new Error(ex);
                Response.Success = false;
                Response.Message = ex.Message;
            }
            return Response;
        }

        public  ServiceResponse<GetMoviesDTO> GetSingleMovie(int id)
        {
            var Response= new ServiceResponse<GetMoviesDTO>();
            try
            {
                var result = _Dbobject.MoviesTable.FirstOrDefault(c=> c.Id==id);
                Response.Data = _mapper.Map<GetMoviesDTO>(result);
                Response.Message = "Successfully Fetched the Movie";
            }
            catch(Exception ex)
            {
                new Error(ex);
                Response.Success = false;
                Response.Message = ex.Message;
                
            }
            return Response;
        }

        public async Task<string> UpdateMovie(UpdateMoviesDTO Movie)
        {
            try
            {
                var result = _Dbobject.MoviesTable.FirstOrDefault(c => c.Id ==Movie.Id);
                result.Title = Movie.Title;
                result.Description = Movie.Description;
                result.Director = Movie.Director;
                result.Genre = Movie.Genre;
                result.Rating = Movie.Rating;
                await _Dbobject.SaveChangesAsync();
                return  Movie.Id.ToString() + " Updated";


            }
            catch (Exception ex)
            {
                new Error(ex);
                return ex.Message;
                
            }
        }
    }
}
