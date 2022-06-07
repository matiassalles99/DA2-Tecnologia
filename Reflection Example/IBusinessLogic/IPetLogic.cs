using Domain;

namespace IBusinessLogic;
public interface IPetLogic
{
  public List<Pet> GetAll();
  public Pet GetById(int id);
  public Pet CreatePet(Pet newPet);
  public Pet UpdatePet(int id, Pet updatedPet);
  public void Delete(int id);
}
