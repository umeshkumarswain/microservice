using MediatR;

namespace Authentication.Application.Features.ExternalProviders.Queries
{
    public class GetAllExternalLoginProviders : IRequest<ICollection<Domain.Models.ExternalLoginProvider>>
    {
    
    }
}