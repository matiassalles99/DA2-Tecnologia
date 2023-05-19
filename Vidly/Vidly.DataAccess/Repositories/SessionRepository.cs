using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Vidly.DataAccess.Contexts;
using Vidly.Domain.Entities;

namespace Vidly.DataAccess;

public class SessionRepository : BaseRepository<Session>
{
    public SessionRepository(VidlyContext context) : base(context)
    {
    }

    // Si queremos agregar o hacer override del comportamiento del base podemos
    // crear repositorios especificos
    public override Session? GetOneBy(Expression<Func<Session, bool>> expression)
    {
        return _context.Set<Session>().Include(a => a.User).FirstOrDefault(expression);
    }
    
    public override void Insert(Session session)
    {
        _context.Entry(session.User).State = EntityState.Unchanged;
        _context.Set<Session>().Add(session);
    }
}