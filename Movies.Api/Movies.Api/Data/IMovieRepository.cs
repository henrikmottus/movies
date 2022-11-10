using Movies.Api.Entities;
using System.Linq.Expressions;

namespace Movies.Api.Data
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> ListMovies();
        Movie? GetMovieById(int id);
    }
}
