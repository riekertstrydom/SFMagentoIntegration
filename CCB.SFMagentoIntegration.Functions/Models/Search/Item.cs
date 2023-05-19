using Newtonsoft.Json;

namespace CCB.SFMagentoIntegration.Functions.Models.Search
{
    internal class Item
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("firstname")]
        public string Firstname { get; set; } = string.Empty;

        [JsonProperty("lastname")]
        public string Lastname { get; set; } = string.Empty;
    }
}
