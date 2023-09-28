using Authentication.Application.Abstractions;
using Authentication.Domain.Models.User;
using Microsoft.AspNetCore.Identity;

namespace Authentication.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<IdentityUser> _userManager;
    public UserRepository(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<User> CreateUser(User toCreate)
    {
        var identityUser = new IdentityUser()
        {
            Email = toCreate.Email,
            PhoneNumber = toCreate.PhoneNumber,
            UserName = toCreate.PhoneNumber
        };
        var result = await this._userManager.CreateAsync(identityUser);

        if (result.Succeeded)
        {
            return toCreate;
        }

        return null;

    }
}