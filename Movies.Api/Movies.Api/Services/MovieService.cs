using Movies.Api.Data;
using Movies.Api.Dtos;
using Movies.Api.Entities;

namespace Movies.Api.Services
{
    public class MovieService
    {
        private readonly MovieRepository _movieRepository;

        public MovieService(MovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public MovieListDto ListMovies(string? title)
        {
            return new MovieListDto
            {
                Movies = _movieRepository.ListMovies(title).Select(m => new MovieDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                    Rating = m.Rating,
                    CategoryName = m.Category?.Name ?? "",
                }).ToList(),
            };
        }

        public MovieDto? GetMovieById(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            if (movie is null)
            {
                return null;
            }

            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Year = movie.Year,
                Rating = movie.Rating,
                Description = movie.Description,
            };
        }
    }
}
