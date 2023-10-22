namespace Authentication.Application.Abstractions;

public interface IUnitOfWork : IDisposable
{
    IUserRepository User { get; }
    int Save();
}