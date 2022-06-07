using Domain;

namespace IBusinessLogic;

public interface IImporterLogic
{
  List<string> GetAllImporters();
  List<Pet> ImportPets(string importerName);
}
