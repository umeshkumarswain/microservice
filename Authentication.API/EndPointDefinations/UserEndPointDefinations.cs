using Authentication.Application.Features.Post.Queries;
using Authentication.Application.Features.User;
using Authentication.Domain.Models.User;
using MediatR;
using Service.Authentication.Abstractions;

namespace Service.Authentication.EndPointDefinations;

public class UserEndPointDefinations : IEndPointDefinations
{
    public void RegisterEndPoints(WebApplication app)
    {
        var baseRoute = app.MapGroup("/api/User");
        
        baseRoute.MapPost(
            "/Register",
            async (IMediator mediator, User userInfo) =>
            {
                var createUser = new CreateUser() { EmailAddress = userInfo.Email,MobileNumber = userInfo.PhoneNumber};
                var createdUser = await mediator.Send(createUser);
                return Results.CreatedAtRoute(
                    "Register",
                    new { createdUser.Email },
                    createdUser
                );
            }
        );
    }
}