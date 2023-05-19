using Vidly.Exceptions;

namespace Vidly.Domain.Entities;

public class Movie
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public ICollection<Role> Roles { get; set; }

    public Movie()
    {
        Roles = new List<Role>();
    }

    public void ValidOrFail()
    {
        if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Description))
            throw new InvalidResourceException("Title or description empty");
    }

    public void UpdateAttributes(Movie movie)
    {
        Title = movie.Title;
        Description = movie.Description;
    }
}