using Domain;

namespace ImporterInterface;

public interface IImporter
{
  string GetName();
  List<Pet> ImportPets(params string[] importerParam);
}
