using Microsoft.Extensions.DependencyInjection;
using Vidly.BusinessLogic;
using Vidly.DataAccess;
using Vidly.DataAccess.Contexts;
using Vidly.Domain.Entities;
using Vidly.IBusinessLogic;
using Vidly.IDataAccess;

namespace Vidly.Factory;

public class ServiceFactory
{
    public void RegisterServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IRepository<Movie>, BaseRepository<Movie>>();
        serviceCollection.AddTransient<IRepository<Actor>, ActorRepository>();
        serviceCollection.AddTransient<IRepository<Session>, SessionRepository>();
        serviceCollection.AddTransient<IRepository<User>, BaseRepository<User>>();

        serviceCollection.AddTransient<IMovieManager, MovieManager>();
        // Lo hago scoped ya que este manager maneja estado, tiene el currentUser
        serviceCollection.AddScoped<ISessionManager, SessionManager>();

        serviceCollection.AddDbContext<VidlyContext>();
    }
}