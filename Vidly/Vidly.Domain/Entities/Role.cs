namespace Vidly.Domain.Entities;

// N-N con tabla intermedia
public class Role
{
    public int Id { get; set; }
    public Movie Movie { get; set; }
    public Actor Actor { get; set; }
    public int Payment { get; set; }
    
    // Other methods...
}
