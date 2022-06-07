using Domain;
using ImporterInterface;

namespace XmlImporter;

public class XmlImporter : IImporter
{
  public string GetName()
  {
    return "XML Importer";
  }

  public List<Pet> ImportPets()
  {
    return new List<Pet>() { new Pet() { Id = 2, Name = "Puppy", Age = 3 } };
  }
}
