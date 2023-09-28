using Authentication.Application.Abstractions;
using Authentication.Domain.Models.User;
using Microsoft.AspNetCore.Identity;

namespace Authentication.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AuthenticationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    public UserRepository(AuthenticationDbContext dbContext,UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
    {
        _context = dbContext;
        _userManager = userManager;
        _signInManager = signInManager;
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