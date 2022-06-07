namespace WebApi.Models.Out;

using Domain;

public class BasicPet
{
  public BasicPet()
  {
  }

  public BasicPet(Pet pet)
  {
    Id = pet.Id;
    Name = pet.Name;
  }

  public int Id { get; set; }
  public string Name { get; set; }

  public override bool Equals(object? obj)
  {
    if (obj is BasicPet)
    {
      var otherPet = obj as BasicPet;

      return otherPet.Id == Id;
    }
    else
    {
      return false;
    }
  }
}
