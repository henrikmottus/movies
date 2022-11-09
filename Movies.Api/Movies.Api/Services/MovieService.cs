using Movies.Api.Data;
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

        public MovieList ListMovies()
        {
            return new MovieList
            {
                Movies = _movieRepository.ListMovies(),
            };
        }

        public Movie? GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }
    }
}
