namespace MovieManager.api.Entities;

public class Movies
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public required string ImageUrl {get; set;}
    public bool Rented {get; set;} = false;
}