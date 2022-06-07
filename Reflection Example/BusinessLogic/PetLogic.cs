using Domain;
using IBusinessLogic;
using IDataAccess;

namespace BusinessLogic;

public class PetLogic : IPetLogic
{
  private readonly IPetRepository _repository;

  public PetLogic(IPetRepository repository)
  {
    _repository = repository;
  }

  public List<Pet> GetAll()
  {
    return _repository.GetAll();
  }

  public Pet GetById(int id)
  {
    return _repository.GetById(id);
  }

  public Pet CreatePet(Pet newPet)
  {
    return _repository.CreatePet(newPet);
  }

  public Pet UpdatePet(int id, Pet updatedPet)
  {
    return _repository.UpdatePet(id, updatedPet);
  }

  public void Delete(int id)
  {
    _repository.Delete(id);
  }
}
