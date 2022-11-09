using Movies.Api.Entities;

namespace Movies.Api.Data;

public class MovieRepository
{
    private readonly MoviesContext _MoviesContext;

    public MovieRepository(MoviesContext moviesContext)
    {
        _MoviesContext = moviesContext;
    }

    public IList<Movie> ListMovies()
    {
        return _MoviesContext.Movies.ToList();
    }

    public Movie? GetMovieById(int id)
    {
        return _MoviesContext.Find<Movie>(id);
    }
}
