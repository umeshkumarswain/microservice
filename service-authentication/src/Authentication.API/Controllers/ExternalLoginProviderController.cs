using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Authentication.Application.Features.ExternalProviders.Queries;
using Authentication.Domain.Models;
using Authentication.Domain.Models.User;
using FluentValidation.Validators;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ExternalLoginProviderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public ExternalLoginProviderController(
        IMediator mediator,
        SignInManager<User> manager,
        UserManager<User> userManager
    )
    {
        _mediator = mediator;
        _signInManager = manager;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetExternalLoginProviders()
    {
        // var externalProviders = (
        //     await _signInManager.GetExternalAuthenticationSchemesAsync()
        // ).ToList();
        // List<string> loginProviders = new List<string>();
        // if (externalProviders != null)
        // {
        //     externalProviders.ForEach(
        //         (provider) =>
        //         {
        //             loginProviders.Add(provider?.DisplayName);
        //         }
        //     );
        // }

        //return Ok(new ChallengeResult("Google"));

        var authenticationProperties = _signInManager.ConfigureExternalAuthenticationProperties(
            "Google",
            "http://localhost:4200"
        );
        return Challenge(authenticationProperties, "Google");
    }

    [HttpPost]
    public async Task<IActionResult> LoginWithGoogle([FromBody] string credentials)
    {
        var payload = await GoogleJsonWebSignature.ValidateAsync(credentials);
        var userInfo = await _userManager.FindByNameAsync(payload.Email);

        var signInResult = await _signInManager.ExternalLoginSignInAsync(
            "GOOGLE",
            payload.Subject,
            isPersistent: false,
            bypassTwoFactor: true
        );

        if (signInResult.Succeeded)
        {
            return Ok(userInfo);
        }

        if (payload.Email != null && userInfo == null)
        {
            if (userInfo == null)
            {
                userInfo = new User { UserName = payload.Email, Email = payload.Email, };
                await _userManager.CreateAsync(userInfo);
            }
            await _userManager.AddLoginAsync(
                userInfo,
                new UserLoginInfo("GOOGLE", payload.Subject, "Google")
            );
            await _signInManager.SignInAsync(userInfo, isPersistent: false);
        }

        return Ok(userInfo);
    }

    private dynamic JWTGenerator(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("SECRET");

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new[]
                {
                    new Claim("id", user.UserName),
                    new Claim(ClaimTypes.Role, user.PhoneNumber)
                }
            ),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var encryptedToken = tokenHandler.WriteToken(token);
        return new { token = encryptedToken, username = user.UserName };
    }
}
