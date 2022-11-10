using Movies.Api.Data;
using Movies.Api.Dtos;
using Movies.Api.Entities;
using System.Linq.Expressions;

namespace Movies.Api.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public MovieListDto ListMovies(string? title, string[]? categories)
        {
            var lowerCaseTitle = (title ?? "").ToLower();
            return new MovieListDto
            {
                Movies = _movieRepository
                    .ListMovies()
                    .Where(m =>
                        m.Title.ToLower().StartsWith(lowerCaseTitle)
                        && (categories is null || categories.Length == 0 || (m.Category != null && categories.Contains(m.Category.Name))))
                    .Select(m => new MovieDto
                    {
                        Id = m.Id,
                        Title = m.Title,
                        Year = m.Year,
                        Rating = m.Rating,
                        CategoryName = m.Category?.Name ?? "",
                    })
                    .ToList(),
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
