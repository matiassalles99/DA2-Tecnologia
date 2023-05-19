using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Vidly.DataAccess.Contexts;
using Vidly.Domain.Entities;

namespace Vidly.DataAccess;

public class ActorRepository : BaseRepository<Actor>
{
    public ActorRepository(VidlyContext context) : base(context)
    {
    }

    // Si queremos agregar o hacer override del comportamiento del base podemos
    // crear repositorios especificos
    public override IEnumerable<Actor> GetAllBy(Expression<Func<Actor, bool>> expression)
    {
        return _context.Set<Actor>().Where(expression)
            .Include(a => a.Roles).ThenInclude(r => r.Movie);
    }
}