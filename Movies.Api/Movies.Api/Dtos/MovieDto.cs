using Movies.Api.Entities;

namespace Movies.Api.Dtos
{
    public class MovieDto : BaseEntity
    {
        public string Title { get; set; } = "";
        public int Year { get; set; }
        public string Description { get; set; } = "";
        public int Rating { get; set; }
        public string CategoryName { get; set; } = "";
    }
}
