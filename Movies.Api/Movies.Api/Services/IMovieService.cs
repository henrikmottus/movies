using Movies.Api.Dtos;

namespace Movies.Api.Services
{
    public interface IMovieService
    {
        MovieListDto ListMovies(string? title, string[] categories);
        MovieDto? GetMovieById(int id);
    }
}
