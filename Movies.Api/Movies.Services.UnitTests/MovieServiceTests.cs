using Moq;
using Movies.Api.Data;
using Movies.Api.Dtos;
using Movies.Api.Entities;
using Movies.Api.Services;
using System.Linq.Expressions;

namespace Movies.Services.UnitTests
{
    public class MovieServiceTests
    {
        private readonly Mock<IMovieRepository> _movieRepository = new();

        public MovieServiceTests()
        {
            var allMovies = new List<Movie>
            {
                new Movie { Id = 1, Title = "Gladiator", Year = 2000, Rating = 8, CategoryId = 1, Description = "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.", Category = new Category { Name = "History" } },
                new Movie { Id = 2, Title = "Ben-Hur", Year = 1959, Rating = 8, CategoryId = 1, Description = "After a Jewish prince is betrayed and sent into slavery by a Roman friend in 1st-century Jerusalem, he regains his freedom and comes back for revenge.", Category = new Category { Name = "History" } },
                new Movie { Id = 3, Title = "Cleopatra", Year = 1963, Rating = 7, CategoryId = 1, Description = "Queen Cleopatra VII of Egypt experiences both triumph and tragedy as she attempts to resist the imperial ambitions of Rome.", Category = new Category { Name = "History" } },
                new Movie { Id = 4, Title = "The Lord of the Rings: The Fellowship of the Ring", Year = 2001, Rating = 9, CategoryId = 2, Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", Category = new Category { Name = "Fantasy" } },
                new Movie { Id = 5, Title = "Arrival", Year = 2016, Rating = 8, CategoryId = 3, Description = "A linguist works with the military to communicate with alien lifeforms after twelve mysterious spacecraft appear around the world.", Category = new Category { Name = "Science Fiction" } },
                new Movie { Id = 6, Title = "The Royal Tenenbaums", Year = 2001, Rating = 7, CategoryId = 4, Description = "The eccentric members of a dysfunctional family reluctantly gather under the same roof for various reasons.", Category = new Category { Name = "Comedy" } },
                new Movie { Id = 7, Title = "The Unbearable Weight of Massive Talent", Year = 2022, Rating = 7, CategoryId = 4, Description = "In this action-packed comedy, Nicolas Cage plays Nick Cage, channeling his iconic characters as he's caught between a superfan (Pedro Pascal) and a CIA agent (Tiffany Haddish).", Category = new Category { Name = "Comedy" } },
                new Movie { Id = 8, Title = "Casper", Year = 1995, Rating = 6, CategoryId = 4, Description = "An afterlife therapist and his daughter meet a friendly young ghost when they move into a crumbling mansion in order to rid the premises of wicked spirits.", Category = new Category { Name = "Comedy" } },
                new Movie { Id = 9, Title = "Nope", Year = 2022, Rating = 7, CategoryId = 5, Description = "The residents of a lonely gulch in inland California bear witness to an uncanny and chilling discovery.", Category = new Category { Name = "Horror" } },
                new Movie { Id = 10, Title = "Scream", Year = 1996, Rating = 7, CategoryId = 5, Description = "A year after the murder of her mother, a teenage girl is terrorized by a new killer, who targets the girl and her friends by using horror films as part of a deadly game.", Category = new Category { Name = "Horror" } },
                new Movie { Id = 11, Title = "The Exorcist", Year = 1973, Rating = 8, CategoryId = 5, Description = "When a teenage girl is possessed by a mysterious entity, her mother seeks the help of two priests to save her daughter.", Category = new Category { Name = "Horror" } },
                new Movie { Id = 12, Title = "Blonde", Year = 2022, Rating = 5, CategoryId = 6, Description = "A fictionalized chronicle of the inner life of Marilyn Monroe.", Category = new Category { Name = "Drama" } },
                new Movie { Id = 13, Title = "The Northman", Year = 2022, Rating = 7, CategoryId = 7, Description = "A young Viking prince is on a quest to avenge his father's murder.", Category = new Category { Name = "Action" } },
                new Movie { Id = 14, Title = "Top Gun", Year = 1986, Rating = 7, CategoryId = 7, Description = "As students at the United States Navy's elite fighter weapons school compete to be best in the class, one daring young pilot learns a few things from a civilian instructor that are not taught in the classroom.", Category = new Category { Name = "Action" } },
                new Movie { Id = 15, Title = "The Dark Knight", Year = 2008, Rating = 9, CategoryId = 7, Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", Category = new Category { Name = "Action" } },
                new Movie { Id = 16, Title = "Wonder Woman 1984", Year = 2020, Rating = 5, CategoryId = 7, Description = "Diana must contend with a work colleague, and with a businessman whose desire for extreme wealth sends the world down a path of destruction, after an ancient artifact that grants wishes goes missing.", Category = new Category { Name = "Action" } },
            };

            _movieRepository
                .Setup(r => r.ListMovies())
                .Returns(allMovies);

            var movieById = new Movie { Id = 4, Title = "The Lord of the Rings: The Fellowship of the Ring", Year = 2001, Rating = 9, CategoryId = 2, Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", Category = new Category { Name = "Fantasy" } };

            _movieRepository
                .Setup(r => r.GetMovieById(It.Is<int>(i => i == 4)))
                .Returns(movieById);
        }

        [Fact]
        public void ListMoviesWithoutParameters_ShouldReturnAllMovies()
        {
            var expectedMovies = new MovieListDto
            {
                Movies = new List<MovieDto>
                {
                    new MovieDto { Id = 1, Title = "Gladiator", Year = 2000, Rating = 8, CategoryName = "History", Description = "" },
                    new MovieDto { Id = 2, Title = "Ben-Hur", Year = 1959, Rating = 8, CategoryName = "History", Description = "" },
                    new MovieDto { Id = 3, Title = "Cleopatra", Year = 1963, Rating = 7, CategoryName = "History", Description = "" },
                    new MovieDto { Id = 4, Title = "The Lord of the Rings: The Fellowship of the Ring", Year = 2001, Rating = 9, CategoryName = "Fantasy", Description = "" },
                    new MovieDto { Id = 5, Title = "Arrival", Year = 2016, Rating = 8, CategoryName = "Science Fiction", Description = "" },
                    new MovieDto { Id = 6, Title = "The Royal Tenenbaums", Year = 2001, Rating = 7, CategoryName = "Comedy", Description = "" },
                    new MovieDto { Id = 7, Title = "The Unbearable Weight of Massive Talent", Year = 2022, Rating = 7, CategoryName = "Comedy", Description = "" },
                    new MovieDto { Id = 8, Title = "Casper", Year = 1995, Rating = 6, CategoryName = "Comedy", Description = "" },
                    new MovieDto { Id = 9, Title = "Nope", Year = 2022, Rating = 7, CategoryName = "Horror", Description = "" },
                    new MovieDto { Id = 10, Title = "Scream", Year = 1996, Rating = 7, CategoryName = "Horror", Description = "" },
                    new MovieDto { Id = 11, Title = "The Exorcist", Year = 1973, Rating = 8, CategoryName = "Horror", Description = "" },
                    new MovieDto { Id = 12, Title = "Blonde", Year = 2022, Rating = 5, CategoryName = "Drama", Description = "" },
                    new MovieDto { Id = 13, Title = "The Northman", Year = 2022, Rating = 7, CategoryName = "Action", Description = "" },
                    new MovieDto { Id = 14, Title = "Top Gun", Year = 1986, Rating = 7, CategoryName = "Action", Description = "" },
                    new MovieDto { Id = 15, Title = "The Dark Knight", Year = 2008, Rating = 9, CategoryName = "Action", Description = "" },
                    new MovieDto { Id = 16, Title = "Wonder Woman 1984", Year = 2020, Rating = 5, CategoryName = "Action", Description = "" },
                }
            };
            var service = new MovieService(_movieRepository.Object);

            var movieList = service.ListMovies(null, null);

            Assert.Equal(System.Text.Json.JsonSerializer.Serialize(expectedMovies), System.Text.Json.JsonSerializer.Serialize(movieList));
        }

        [Fact]
        public void ListMoviesWithTitle_ShouldReturnMoviesStartingWithThatTitle()
        {
            var expectedMovies = new MovieListDto
            {
                Movies = new List<MovieDto>
                {
                    new MovieDto { Id = 3, Title = "Cleopatra", Year = 1963, Rating = 7, CategoryName = "History", Description = "" },
                    new MovieDto { Id = 8, Title = "Casper", Year = 1995, Rating = 6, CategoryName = "Comedy", Description = "" },
                }
            };
            var service = new MovieService(_movieRepository.Object);

            var movieList = service.ListMovies("C", null);

            Assert.Equal(System.Text.Json.JsonSerializer.Serialize(expectedMovies), System.Text.Json.JsonSerializer.Serialize(movieList));
        }

        [Fact]
        public void ListMoviesWithCategories_ShouldReturnMoviesInThoseCategories()
        {
            var expectedMovies = new MovieListDto
            {
                Movies = new List<MovieDto>
                {
                    new MovieDto { Id = 1, Title = "Gladiator", Year = 2000, Rating = 8, CategoryName = "History", Description = "" },
                    new MovieDto { Id = 2, Title = "Ben-Hur", Year = 1959, Rating = 8, CategoryName = "History", Description = "" },
                    new MovieDto { Id = 3, Title = "Cleopatra", Year = 1963, Rating = 7, CategoryName = "History", Description = "" },
                    new MovieDto { Id = 13, Title = "The Northman", Year = 2022, Rating = 7, CategoryName = "Action", Description = "" },
                    new MovieDto { Id = 14, Title = "Top Gun", Year = 1986, Rating = 7, CategoryName = "Action", Description = "" },
                    new MovieDto { Id = 15, Title = "The Dark Knight", Year = 2008, Rating = 9, CategoryName = "Action", Description = "" },
                    new MovieDto { Id = 16, Title = "Wonder Woman 1984", Year = 2020, Rating = 5, CategoryName = "Action", Description = "" },
                }
            };
            var service = new MovieService(_movieRepository.Object);

            var movieList = service.ListMovies(null, new string[] { "History", "Action" });

            Assert.Equal(System.Text.Json.JsonSerializer.Serialize(expectedMovies), System.Text.Json.JsonSerializer.Serialize(movieList));
        }

        [Fact]
        public void ListMoviesWithTitleAndCategories_ShouldReturnMoviesWithTheTitleAndInThoseCategories()
        {
            var expectedMovies = new MovieListDto
            {
                Movies = new List<MovieDto>
                {
                    new MovieDto { Id = 13, Title = "The Northman", Year = 2022, Rating = 7, CategoryName = "Action", Description = "" },
                    new MovieDto { Id = 15, Title = "The Dark Knight", Year = 2008, Rating = 9, CategoryName = "Action", Description = "" },
                }
            };
            var service = new MovieService(_movieRepository.Object);

            var movieList = service.ListMovies("Th", new string[] { "History", "Action" });

            Assert.Equal(System.Text.Json.JsonSerializer.Serialize(expectedMovies), System.Text.Json.JsonSerializer.Serialize(movieList));
        }

        [Fact]
        public void ListMoviesWithNonExistentTitleAndCategories_ShouldReturnNoMovies()
        {
            var expectedMovies = new MovieListDto
            {
                Movies = new List<MovieDto>
                {
                }
            };
            var service = new MovieService(_movieRepository.Object);

            var movieList = service.ListMovies("Title", new string[] { "Thriller" });

            Assert.Equal(System.Text.Json.JsonSerializer.Serialize(expectedMovies), System.Text.Json.JsonSerializer.Serialize(movieList));
        }

        [Fact]
        public void GettingMovieById_ShouldReturnThatMovie()
        {
            var expectedMovie = new MovieDto { Id = 4, Title = "The Lord of the Rings: The Fellowship of the Ring", Year = 2001, Rating = 9, CategoryName = "", Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron." };
            var service = new MovieService(_movieRepository.Object);

            var movieList = service.GetMovieById(4);

            Assert.Equal(System.Text.Json.JsonSerializer.Serialize(expectedMovie), System.Text.Json.JsonSerializer.Serialize(movieList));
        }

        [Fact]
        public void GettingMovieByNonExistentId_ShouldReturnNull()
        {
            MovieDto? expectedMovie = null;
            var service = new MovieService(_movieRepository.Object);

            var movieList = service.GetMovieById(17);

            Assert.Equal(System.Text.Json.JsonSerializer.Serialize(expectedMovie), System.Text.Json.JsonSerializer.Serialize(movieList));
        }
    }
}