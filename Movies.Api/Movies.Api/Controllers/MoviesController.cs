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
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public MovieListDto Get(string? title, string? categories)
        {
            var categoryArray = (categories ?? "").Split(';').Where(c => !String.IsNullOrWhiteSpace(c)).ToArray();
            return _movieService.ListMovies(title, categoryArray);
        }

        [HttpGet("{id}")]
        public MovieDto? Get(int id)
        {
            return _movieService.GetMovieById(id);
        }
    }
}
