using Movies.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Movies.Api.Data;

public class MovieRepository
{
    private readonly MoviesContext _MoviesContext;

    public MovieRepository(MoviesContext moviesContext)
    {
        _MoviesContext = moviesContext;
    }

    public IList<Movie> ListMovies(string? title)
    {
        var lowerCaseTitle = (title ?? "").ToLower();
        return _MoviesContext.Movies.Where(m => m.Title.ToLower().StartsWith(lowerCaseTitle)).Include(m => m.Category).ToList();
    }

    public Movie? GetMovieById(int id)
    {
        return _MoviesContext.Find<Movie>(id);
    }
}
