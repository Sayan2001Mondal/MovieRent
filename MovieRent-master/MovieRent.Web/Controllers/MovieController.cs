using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRent.Web.DTOs;
using MovieRent.Web.Services;
using System.Runtime.CompilerServices;

namespace MovieRent.Web.Controllers
{
    [Route("api/[controller]")]
    //[AllowAnonymous]
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
        [HttpPost("Addmovie")]
        public async Task<ActionResult> AddMovie(AddMoviesDTO newmovie)
        {
            await _movieService.AddMovie(newmovie);
            return Ok(newmovie);
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
        [HttpGet("GetMovie")]
        public ActionResult<GetMoviesDTO> GetMovie (int id)
        {
            return Ok(_movieService.GetSingleMovie(id));
        }
        /// <summary>
        /// Method to Update a Movie
        /// </summary>

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateMovie")]
        public async Task<ActionResult> UpdateMovie(UpdateMoviesDTO movie) 
        {
             await _movieService.UpdateMovie(movie);
            return Ok(movie);
        }
        /// <summary>
        /// Method to Delete a Movie
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteMovie")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            await _movieService.DeleteMovie(id);
            return Ok();
        }
    }

}
