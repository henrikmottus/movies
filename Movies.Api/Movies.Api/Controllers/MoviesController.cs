using Microsoft.AspNetCore.Mvc;
using Movies.Api.Dtos;
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
        public MovieListDto Get(string? title)
        {
            return _movieService.ListMovies(title);
        }

        [HttpGet("{id}")]
        public MovieDto? Get(int id)
        {
            return _movieService.GetMovieById(id);
        }
    }
}
