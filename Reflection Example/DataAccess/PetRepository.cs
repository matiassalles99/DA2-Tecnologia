using Domain;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class PetRepository : IPetRepository
{
  protected DbContext Context { get; set; }

  public PetRepository(DbContext dbContext)
  {
    Context = dbContext;
  }

  public Pet CreatePet(Pet newPet)
  {
    Context.Set<Pet>().Add(newPet);
    Context.SaveChanges();

    return newPet;
  }

  public void Delete(int id)
  {
    if (!PetExists(id))
      throw new ResourceNotFoundException("Could not find specified pet");

    Context.Set<Pet>().Remove(Context.Set<Pet>().Find(id));
    Context.SaveChanges();
  }

  public List<Pet> GetAll()
  {
    return Context.Set<Pet>().ToList();
  }

  public Pet GetById(int id)
  {
    if (!PetExists(id))
      throw new ResourceNotFoundException("Could not find specified pet");

    return Context.Set<Pet>().Where(p => p.Id == id).FirstOrDefault();
  }

  public Pet UpdatePet(int id, Pet updatedPet)
  {
    if (!PetExists(id))
      throw new ResourceNotFoundException("Could not find specified pet");

    updatedPet.Id = id;
    Context.Entry(updatedPet).State = EntityState.Modified;
    Context.SaveChanges();

    return updatedPet;
  }

  private bool PetExists(int petId)
  {
    Pet? resort = Context.Set<Pet>().AsNoTracking().Where(p => p.Id == petId).FirstOrDefault();
    return resort != null;
  }
}
