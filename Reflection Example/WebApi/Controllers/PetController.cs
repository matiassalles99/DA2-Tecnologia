using BusinessLogic;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using WebApi.Models.In;
using WebApi.Models.Out;

namespace WebApi.Controllers;

[ApiController]
[Route("api/pets")]
[AddHeaderFilter("HeaderEjemplo", "ValorEjemplo", Order = int.MaxValue)]
public class PetController : ControllerBase
{
  private readonly IPetLogic _petLogic;
  private readonly IImporterLogic _importerLogic;

  public PetController(IPetLogic petLogic, IImporterLogic importerLogic)
  {
    _petLogic = petLogic;
    _importerLogic = importerLogic;
  }

  [HttpGet]
  public IActionResult Get()
  {
    List<BasicPet> retrievedPets = new List<BasicPet>();
    retrievedPets.Add(new BasicPet() { Id = 1, Name = "Perro" });
    retrievedPets.Add(new BasicPet() { Id = 2, Name = "Perro 2" });

    return Ok(retrievedPets);
  }

  [HttpGet("importers")]
  public IActionResult GetImporters()
  {
    List<string> retrievedImporters = _importerLogic.GetAllImporters();
    return Ok(retrievedImporters);
  }

  [HttpPost("import")]
  public IActionResult ImportPets([FromBody] string importerName)
  {
    List<BasicPet> importedPets = _importerLogic.ImportPets(importerName).Select(pet => new BasicPet(pet)).ToList();
    return Ok(importedPets);
  }

  [HttpGet("{id}", Name = "GetById")]
  public IActionResult GetById(int id)
  {
    DetailedPet retrievedPet = new DetailedPet(_petLogic.GetById(id));
    return Ok(retrievedPet);
  }

  [HttpPost]
  public IActionResult Create([FromBody] CreatePet newPet)
  {
    DetailedPet createdPet = new DetailedPet(_petLogic.CreatePet(newPet.ToEntity()));
    return Created(Url.Action("GetById", new { id = createdPet.Id }), createdPet);
  }

  [HttpPut("{id}")]
  // Crear un modelo para update?
  public IActionResult Update(int id, CreatePet updatePet)
  {
    DetailedPet updatedPet = new DetailedPet(_petLogic.UpdatePet(id, updatePet.ToEntity()));
    return Ok(updatedPet);
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    _petLogic.Delete(id);
    return Ok();
  }
}
