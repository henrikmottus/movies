using Movies.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Movies.Api.Data;

public class MovieRepository : IMovieRepository
{
    private readonly MoviesContext _MoviesContext;

    public MovieRepository(MoviesContext moviesContext)
    {
        _MoviesContext = moviesContext;
    }

    public IEnumerable<Movie> ListMovies()
    {
        return _MoviesContext.Movies
            .Include(m => m.Category);
    }

    public Movie? GetMovieById(int id)
    {
        return _MoviesContext.Find<Movie>(id);
    }
}
