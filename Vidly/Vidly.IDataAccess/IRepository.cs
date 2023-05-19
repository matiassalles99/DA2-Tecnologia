using System.Linq.Expressions;

namespace Vidly.IDataAccess;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAllBy(Expression<Func<T, bool>> expression);
    T? GetOneBy(Expression<Func<T, bool>> expression);
    void Insert(T elem);
    void Delete(T elem);
    void Update(T elem);
    void Save();
}
