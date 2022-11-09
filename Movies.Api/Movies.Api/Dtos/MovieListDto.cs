namespace Movies.Api.Dtos
{
    public class MovieListDto
    {
        public IList<MovieDto> Movies { get; set; } = new List<MovieDto>();
    }
}
