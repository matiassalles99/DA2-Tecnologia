namespace WebApi.Models.In;

using Domain;

public class CreatePet
{
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }

    public Pet ToEntity()
    {
        return new Pet()
        {
            Name = Name,
            Breed = Breed,
            Age = Age
        };
    }
}
