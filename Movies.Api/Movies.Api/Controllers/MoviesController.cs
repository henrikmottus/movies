using Microsoft.AspNetCore.Mvc;
using Movies.Api.Entities;
using Movies.Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public MovieList Get()
        {
            return _movieService.ListMovies();
        }

        [HttpGet("{id}")]
        public Movie? Get(int id)
        {
            return _movieService.GetMovieById(id);
        }
    }
}
