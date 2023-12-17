using Authentication.Application.Abstractions;
using Authentication.Domain.Models;

namespace Authentication.DataAccess.Repositories
{
    public class ExternalLoginProviderRepository : IExternalLoginProviders
    {
        public Task<ICollection<Domain.Models.ExternalLoginProvider>> GetAllExternalLoginProviders()
        {
            var providers = new List<Domain.Models.ExternalLoginProvider>
            {
                new ExternalLoginProvider { ProviderId = '1', ProviderName = 1 }
            };
            return null;
        }
    }
}
