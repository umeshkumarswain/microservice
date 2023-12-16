using Authentication.Domain.Models.User;

namespace Authentication.Application.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
        //Task<User> CreateUser(User toCreate);
    }
}