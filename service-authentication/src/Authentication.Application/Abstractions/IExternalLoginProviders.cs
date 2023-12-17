using Authentication.Domain.Models;

namespace Authentication.Application.Abstractions
{
    public interface IExternalLoginProviders
    {
         Task<ICollection<ExternalLoginProvider>> GetAllExternalLoginProviders();
    }
}