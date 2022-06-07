using Domain;

namespace IDataAccess;

public interface IPetRepository
{
  List<Pet> GetAll();
  Pet GetById(int id);
  Pet CreatePet(Pet newPet);
  Pet UpdatePet(int id, Pet updatedPet);
  void Delete(int id);
}
