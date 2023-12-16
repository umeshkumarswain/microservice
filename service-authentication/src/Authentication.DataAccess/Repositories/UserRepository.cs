using System.Linq.Expressions;
using Authentication.Application.Abstractions;
using Authentication.Domain.Models.User;
using Microsoft.AspNetCore.Identity;

namespace Authentication.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AuthenticationDbContext context) : base(context)
        {
    
        }
    }
}