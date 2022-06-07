namespace WebApi.Models.Out;

using Domain;

public class DetailedPet
{
    public DetailedPet(Pet pet)
    {
        Id = pet.Id;
        Name = pet.Name;
        Breed = pet.Breed;
        Age = pet.Age;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }
}
