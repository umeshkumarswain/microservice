using Authentication.Domain.Models.User;
using FluentValidation;

namespace Service.Authentication.Filters;

public class ValidationFilter : IEndpointFilter
{
    private readonly IValidator<User> _userValidator;
    public ValidationFilter(IValidator<User> userValidator)
    {
        _userValidator = userValidator;
    }
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var user = context.Arguments.FirstOrDefault((usr) => usr.GetType() == typeof(User)) as User;
        var result = await _userValidator.ValidateAsync(user!);
        if (!result.IsValid)
        {
            return Results.Json(result.Errors, statusCode: 400);
            
        }

        return next(context);
    }
}