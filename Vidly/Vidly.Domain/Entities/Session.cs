namespace Vidly.Domain.Entities;

public class Session
{
    public int Id { get; set; }
    public Guid AuthToken { get; set; }
    public User User { get; set; }

    public Session()
    {
        AuthToken = Guid.NewGuid();
    }
}
