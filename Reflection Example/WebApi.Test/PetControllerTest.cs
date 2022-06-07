using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;
using WebApi.Models.Out;

namespace WebApi.Test;

[TestClass]
public class PetControllerTest
{
  private Mock<IPetLogic> _petLogicMock;

  [TestInitialize]
  public void Setup()
  {
    _petLogicMock = new Mock<IPetLogic>(MockBehavior.Strict);
  }

  [TestCleanup]
  // Arrange: Creamos los mocks y se lo pasamos a los objetos que queremos testear
  // Act: Probamos/ejecutamos el metodo
  // Assert: Comprobamos que el resultado es el que esperamos

  // Dummy: No tiene comportamiento, ej: Pasar por parametro algo que no vamos a usar
  // Fake: ej in memory db
  // Stubs: Devuelven algo por default
  // Spies: Como el stub pero tambien registra informacion extra
  // Mocks: Objetos que programamos nosotros y es el unico que verifica comportamiento
  [TestMethod]
  public void GetAllTest()
  {
    var petsList = new List<Pet>();
    petsList.Add(new Pet() { Id = 1, Name = "Perro 1", Age = 2 });
    petsList.Add(new Pet() { Id = 2, Name = "Perro 2", Age = 3 });
    var expectedList = petsList.Select(pet => new BasicPet(pet)).ToList();

    _petLogicMock.Setup(m => m.GetAll()).Returns(petsList);

    var controller = new PetController(_petLogicMock.Object);
    var result = controller.Get();
    var okResult = result as OkObjectResult;
    var retrievedList = okResult.Value as List<BasicPet>;


    CollectionAssert.AreEqual(expectedList, retrievedList);
    _petLogicMock.VerifyAll();
  }

  [TestMethod]
  public void GetByIdNotFound()
  {
    Mock<IPetLogic> mock = new Mock<IPetLogic>(MockBehavior.Strict);
    mock.Setup(m => m.GetById(It.IsAny<int>())).Throws(new Exception("No existe"));

    var controller = new PetController(mock.Object);
    var result = controller.GetById(1);
    var notFoundResult = result as ObjectResult;

    Assert.IsTrue(notFoundResult.StatusCode == 404);
    mock.VerifyAll();
  }
}