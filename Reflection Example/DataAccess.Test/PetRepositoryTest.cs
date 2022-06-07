using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Context;
using System.Collections.Generic;
using Domain;

namespace DataAccess.Test;

[TestClass]
public class PetRepositoryTest
{
  private PetRepository _repository;
  private PetServerContext _context;

  [TestInitialize]
  public void SetUp()
  {
    _context = ContextFactory.GetNewContext(ContextType.Memory);
    _repository = new PetRepository(_context);
  }

  [TestCleanup]
  public void CleanUp()
  {
    _context.Database.EnsureDeleted();
  }

  [TestMethod]
  public void GetAllPetsTest()
  {
    List<Pet> expectedPets = new List<Pet>();

    List<Pet> retrievedPets = _repository.GetAll();
    CollectionAssert.AreEquivalent(expectedPets, retrievedPets);
  }
}
