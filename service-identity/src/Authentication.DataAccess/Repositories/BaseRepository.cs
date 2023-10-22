using System.Linq.Expressions;
using Authentication.Application.Abstractions;

namespace Authentication.DataAccess.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly AuthenticationDbContext _context;
    public BaseRepository(AuthenticationDbContext context)
    {
        _context = context;
    }
    public T GetById(int id)
    {
        return _context.Set<T>().Find(id)!;
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(predicate);
    }

    public  void Add(T entity)
    {
         _context.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public void Remove(T entity)
    {
         _context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
}