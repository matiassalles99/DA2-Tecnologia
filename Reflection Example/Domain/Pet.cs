namespace Domain;
public class Pet
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Breed { get; set; }
  public int Age { get; set; }

  public override bool Equals(object? obj)
  {
    if (obj is Pet pet)
      return Id == pet.Id;
    else
      return false;
  }
}
