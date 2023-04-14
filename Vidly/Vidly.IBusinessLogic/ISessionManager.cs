using Vidly.Domain.Entities;

namespace Vidly.IBusinessLogic;

public interface ISessionManager
{
    User? GetCurrentUser(Guid? authToken = null);
    Guid Authenticate(string email, string password);
}