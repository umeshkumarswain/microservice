using Authentication.Application.Abstractions;
using Authentication.Application.Features.ExternalProviders.Queries;
using Authentication.Domain.Models;
using MediatR;

namespace Authentication.Application.Features.ExternalProviders.QueryHandlers
{
    public class GetAllExternalLoginProvidersHandler : IRequestHandler<GetAllExternalLoginProviders,
    ICollection<ExternalLoginProvider>>
    {
       private readonly IExternalLoginProviders _externalLoginProvidersRepository;

        public GetAllExternalLoginProvidersHandler(IExternalLoginProviders externalLoginProvidersRepository)
        {
            _externalLoginProvidersRepository = externalLoginProvidersRepository;
        }

       

        public Task<ICollection<ExternalLoginProvider>> Handle(GetAllExternalLoginProviders request, CancellationToken cancellationToken)
        {
            return this._externalLoginProvidersRepository.GetAllExternalLoginProviders();
        }
    }
}