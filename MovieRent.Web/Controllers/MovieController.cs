using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRent.Web.DTOs;
using MovieRent.Web.Services;
using System.Runtime.CompilerServices;

namespace MovieRent.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMoviesService _movieService;

        public MovieController(IMoviesService moviesService)
        {
            _movieService= moviesService;
        }
        /// <summary>
        /// Method to Add a Movie
        /// </summary>
        [Authorize(Roles ="User,Admin")]
        [HttpPost("Add a movie")]
        public async Task<string> AddMovie(AddMoviesDTO newmovie)
        {
            return await _movieService.AddMovie(newmovie);
        }
        /// <summary>
        /// Method to Display all the Movies 
        /// </summary>
        [Authorize(Roles = "User,Admin")]
        [HttpGet("GetAllMovies")]
        public ActionResult<List<GetMoviesDTO>> GetAllMovie ()
        {
            return Ok(_movieService.GetMovieList());
            
        }
        /// <summary>
        /// Method to Display a Single Movie
        /// </summary>
        [Authorize(Roles ="User,Admin")]
        [HttpGet("Get a Single Movie")]
        public ActionResult<GetMoviesDTO> GetMovie (int id)
        {
            return Ok(_movieService.GetSingleMovie(id));
        }
        /// <summary>
        /// Method to Update a Movie
        /// </summary>

        [Authorize(Roles = "Admin")]
        [HttpPut("Update a Movie")]
        public async Task<string> UpdateMovie(UpdateMoviesDTO movie) 
        {
            return await _movieService.UpdateMovie(movie);
        }
        /// <summary>
        /// Method to Delete a Movie
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete a Movie")]
        public async Task<string> DeleteMovie(int id)
        {
            return await _movieService.DeleteMovie(id);
        }
    }

}
