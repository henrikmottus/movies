using Movies.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Movies.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MoviesContext context)
        {
            if (context.Movies.Any())
            {
                return;
            }

            var courses = new Category[]
            {
                new Category{Name="History", Movies = new List<Movie>{
                    new Movie{Title="Gladiator",Year=2000,Rating=8,CategoryId=1,Description="A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery."},
                    new Movie{Title="Ben-Hur",Year=1959,Rating=8,CategoryId=1,Description="After a Jewish prince is betrayed and sent into slavery by a Roman friend in 1st-century Jerusalem, he regains his freedom and comes back for revenge."},
                    new Movie{Title="Cleopatra",Year=1963,Rating=7,CategoryId=1,Description="Queen Cleopatra VII of Egypt experiences both triumph and tragedy as she attempts to resist the imperial ambitions of Rome."},
                }},
                new Category{Name="Fantasy", Movies = new List<Movie>{
                    new Movie{Title="The Lord of the Rings: The Fellowship of the Ring",Year=2001,Rating=9,CategoryId=2,Description="A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron."},
                }},
                new Category{Name="Science Fiction", Movies = new List<Movie>{
                    new Movie{Title="Arrival",Year=2016,Rating=8,CategoryId=3,Description="A linguist works with the military to communicate with alien lifeforms after twelve mysterious spacecraft appear around the world."},
                }},
                new Category{Name="Comedy", Movies = new List<Movie>{
                    new Movie{Title="The Royal Tenenbaums",Year=2001,Rating=7,CategoryId=4,Description="The eccentric members of a dysfunctional family reluctantly gather under the same roof for various reasons."},
                    new Movie{Title="The Unbearable Weight of Massive Talent",Year=2022,Rating=7,CategoryId=4,Description="In this action-packed comedy, Nicolas Cage plays Nick Cage, channeling his iconic characters as he's caught between a superfan (Pedro Pascal) and a CIA agent (Tiffany Haddish)."},
                    new Movie{Title="Casper",Year=1995,Rating=6,CategoryId=4,Description="An afterlife therapist and his daughter meet a friendly young ghost when they move into a crumbling mansion in order to rid the premises of wicked spirits."},
                }},
                new Category{Name="Horror", Movies = new List<Movie>{
                    new Movie{Title="Nope",Year=2022,Rating=7,CategoryId=5,Description="The residents of a lonely gulch in inland California bear witness to an uncanny and chilling discovery."},
                    new Movie{Title="Scream",Year=1996,Rating=7,CategoryId=5,Description="A year after the murder of her mother, a teenage girl is terrorized by a new killer, who targets the girl and her friends by using horror films as part of a deadly game."},
                    new Movie{Title="The Exorcist",Year=1973,Rating=8,CategoryId=5,Description="When a teenage girl is possessed by a mysterious entity, her mother seeks the help of two priests to save her daughter."},
                }},
                new Category{Name="Drama", Movies = new List<Movie>{
                    new Movie{Title="Blonde",Year=2022,Rating=5,CategoryId=6,Description="A fictionalized chronicle of the inner life of Marilyn Monroe."},
                }},
                new Category{Name="Action", Movies = new List<Movie>{
                    new Movie{Title="The Northman",Year=2022,Rating=7,CategoryId=7,Description="A young Viking prince is on a quest to avenge his father's murder."},
                    new Movie{Title="Top Gun",Year=1986,Rating=7,CategoryId=7,Description="As students at the United States Navy's elite fighter weapons school compete to be best in the class, one daring young pilot learns a few things from a civilian instructor that are not taught in the classroom."},
                    new Movie{Title="The Dark Knight",Year=2008,Rating=9,CategoryId=7,Description="When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."},
                    new Movie{Title="Wonder Woman 1984",Year=2020,Rating=5,CategoryId=7,Description="Diana must contend with a work colleague, and with a businessman whose desire for extreme wealth sends the world down a path of destruction, after an ancient artifact that grants wishes goes missing."},
                }},
            };

            context.Categories.AddRange(courses);
            context.SaveChanges();
        }
    }
}
