﻿namespace Movies.Api.Entities;

public class Movie : BaseEntity
{
    public string Title { get; set; } = "";
    public int Year { get; set; }
    public string Description { get; set; } = "";
    public int Rating { get; set; }
    public int CategoryId { get; set; }
}
