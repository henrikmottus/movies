namespace Movies.Api.Entities
{
    public class MovieList
    {
        public IList<Movie> Movies { get; set; } = new List<Movie>();
    }
}
