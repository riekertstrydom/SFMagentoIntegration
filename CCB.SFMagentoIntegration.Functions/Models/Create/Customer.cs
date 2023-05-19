using Newtonsoft.Json;
using System.Collections.Generic;

namespace CCB.SFMagentoIntegration.Functions.Models.Create
{
    internal class Customer
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("group_id")]
        public int GroupId { get; set; } = 0;

        [JsonProperty("default_billing")]
        public string DefaultBilling { get; set; } = string.Empty;

        [JsonProperty("default_shipping")]
        public string DefaultShipping { get; set; } = string.Empty;

        [JsonProperty("confirmation")]
        public string Confirmation { get; set; } = string.Empty;

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; } = string.Empty;

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; } = string.Empty;

        [JsonProperty("created_in")]
        public string CreatedIn { get; set; } = string.Empty;

        [JsonProperty("dob")]
        public string DateOfBirth { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("firstname")]
        public string Firstname { get; set; } = string.Empty;

        [JsonProperty("lastname")]
        public string Lastname { get; set; } = string.Empty;

        [JsonProperty("middlename")]
        public string MiddleName { get; set; } = string.Empty;

        [JsonProperty("prefix")]
        public string Prefix { get; set; } = string.Empty;

        [JsonProperty("suffix")]
        public string Suffix { get; set; } = string.Empty;

        [JsonProperty("gender")]
        public int Gender { get; set; } = 0;

        [JsonProperty("store_id")]
        public int StoreId { get; set; } = 0;

        [JsonProperty("taxvat")]
        public string TaxVat { get; set; } = string.Empty;

        [JsonProperty("website_id")]
        public int WebsiteId { get; set; } = 0;

        [JsonProperty("addresses")]
        public List<string> Addresses { get; set; } = new List<string>();

        [JsonProperty("disable_auto_group_change")]
        public int DisableAutoGroupChange { get; set; } = 0;

        [JsonProperty("extension_attributes")]
        public string ExtensionAttributes { get; set; } = "{}";

        [JsonProperty("custom_attributes")]
        public List<string> CustomAttributes { get; set; } = new List<string>();
    }
}
