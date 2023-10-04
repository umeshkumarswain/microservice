using Authentication.Application.Abstractions;
using Authentication.Application.Features.Post.Commands;
using MediatR;

namespace Authentication.Application.Features.User;

public class CreateUserHandler : IRequestHandler<CreateUser,Domain.Models.User.User>
{
    private readonly IUserRepository _repository;
    public CreateUserHandler(IUserRepository userRepository)
    {
        _repository = userRepository;
    }

    public async Task<Domain.Models.User.User> Handle(CreateUser request, CancellationToken cancellationToken)
    {
        var post = new Domain.Models.User.User()
        {
            PhoneNumber =  request.MobileNumber,
            Email = request.EmailAddress
        };
        return await _repository.CreateUser(post);
    }
}

public class CreateUser :IRequest<Domain.Models.User.User>
{
    public string? MobileNumber { get; set; }
    public string? EmailAddress { get; set; }
}