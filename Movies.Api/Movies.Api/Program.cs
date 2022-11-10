using Microsoft.EntityFrameworkCore;
using Movies.Api.Data;
using Movies.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddDbContext<MoviesContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesContext")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "default",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173");
                      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MoviesContext>();
    context.Database.Migrate();
    DbInitializer.Initialize(context);
}

app.UseCors("default");

app.MapControllers();

app.Run();
