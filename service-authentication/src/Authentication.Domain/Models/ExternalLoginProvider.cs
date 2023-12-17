namespace Authentication.Domain.Models
{
    public class ExternalLoginProvider
    {
        public int ProviderId { get; set; }
        public int ProviderName { get; set; }
    }

}