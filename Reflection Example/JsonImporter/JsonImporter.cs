using Domain;
using ImporterInterface;

namespace JsonImporter;
public class JsonImporter : IImporter
{
  public string GetName()
  {
    return "Json Importer";
  }

  public List<Pet> ImportPets()
  {
    return new List<Pet>() { new Pet() { Id = 1, Name = "Pet desde JSON Importer", Age = 1 } };
  }
}
