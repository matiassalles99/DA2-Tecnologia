namespace Domain;
public class Owner
{
  public int Id { get; set; }
  public string Name { get; set; }
  public List<Pet> Pets { get; set; }

  public Owner()
  {
    Pets = new List<Pet>();
  }
}
