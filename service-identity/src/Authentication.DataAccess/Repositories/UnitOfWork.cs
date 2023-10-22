using Authentication.Application.Abstractions;

namespace Authentication.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AuthenticationDbContext _context;
    public IUserRepository User { get; private set; }
    public UnitOfWork(AuthenticationDbContext context)
    {
        _context = context;
        User = new UserRepository(context: _context);
    }

    public int Save()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}