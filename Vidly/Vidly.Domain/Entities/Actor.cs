namespace Vidly.Domain.Entities;

public class Actor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public ICollection<Role> Roles { get; set; }

    public Actor()
    {
        Roles = new List<Role>();
    }
    
    // Other methods...
}