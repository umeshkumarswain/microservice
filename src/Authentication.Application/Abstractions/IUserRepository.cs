using Authentication.Domain.Models.User;

namespace Authentication.Application.Abstractions;

public interface IUserRepository
{
    Task<User> CreateUser(User toCreate);
}