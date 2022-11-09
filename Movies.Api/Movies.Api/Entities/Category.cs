namespace Movies.Api.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = "";

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
