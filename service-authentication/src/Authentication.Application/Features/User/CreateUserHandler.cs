using Authentication.Application.Abstractions;
using Authentication.Application.Features.Post.Commands;
using MediatR;

namespace Authentication.Application.Features.User
{
    public class CreateUserHandler : IRequestHandler<CreateUser,Domain.Models.User.User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Models.User.User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = new Domain.Models.User.User()
            {
                PhoneNumber =  request.MobileNumber,
                Email = request.EmailAddress
            };
            _unitOfWork.User.Add(user);
            _unitOfWork.Save();

            return user;
        }
    }

    public class CreateUser :IRequest<Domain.Models.User.User>
    {
        public string? MobileNumber { get; set; }
        public string? EmailAddress { get; set; }
    }
}