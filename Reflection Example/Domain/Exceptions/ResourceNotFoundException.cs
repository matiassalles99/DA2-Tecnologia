namespace Domain;

public class ResourceNotFoundException : Exception
{
  public ResourceNotFoundException(string message) : base(message)
  {
  }
}
