using Microsoft.Extensions.DependencyInjection;
using BusinessLogic;
using IBusinessLogic;
using IDataAccess;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;

namespace ServiceRegistrator;

public class Registrator
{
  private IServiceCollection _services;

  public Registrator(IServiceCollection services)
  {
    _services = services;
  }

  public void RegisterBusinessLogicServices()
  {
    _services.AddScoped<IPetLogic, PetLogic>();
    _services.AddScoped<ISessionLogic, SessionLogic>();
    _services.AddScoped<IImporterLogic, ImporterLogic>();
  }

  public void RegisterDataAccessServices()
  {
    _services.AddScoped<IPetRepository, PetRepository>();
    _services.AddDbContext<DbContext, PetServerContext>();
  }
}
