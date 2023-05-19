using Newtonsoft.Json;

namespace CCB.SFMagentoIntegration.Functions.Models.Create
{
    internal class CreateRequest
    {
        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; } = string.Empty;

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; } = string.Empty;
    }
}
