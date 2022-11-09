using Microsoft.EntityFrameworkCore;
using Movies.Api.Entities;

namespace Movies.Api.Data;

public class MoviesContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }

    public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasKey("Id");
        modelBuilder.Entity<Category>().HasKey("Id");
        modelBuilder.Ignore<MovieList>();
    }
}