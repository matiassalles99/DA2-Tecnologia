using System.Security.Authentication;
using Vidly.Domain.Entities;
using Vidly.IBusinessLogic;
using Vidly.IDataAccess;

namespace Vidly.BusinessLogic;

public class SessionManager : ISessionManager
{
    private User? _currentUser { get; set; }
    private IRepository<Session> _sessionRepository;
    private IRepository<User> _userRepository;

    public SessionManager(IRepository<Session> sessionRepository, IRepository<User> userRepository)
    {
        _sessionRepository = sessionRepository;
        _userRepository = userRepository;
    }
    
    public User? GetCurrentUser(Guid? authToken = null)
    {
        if (_currentUser != null)
            return _currentUser;

        if (authToken == null)
            throw new ArgumentException("Cant retrieve user without auth token");

        var session = _sessionRepository.GetOneBy(s => s.AuthToken == authToken);

        if (session != null)
            _currentUser = session.User;

        return _currentUser;
    }

    public Guid Authenticate(string email, string password)
    {
        var user = _userRepository.GetOneBy(u => u.Email == email && u.Password == password);

        if (user == null)
            throw new InvalidCredentialException("Invalid credentials");

        var session = new Session() { User = user };
        _sessionRepository.Insert(session);

        return session.AuthToken;
    }
}