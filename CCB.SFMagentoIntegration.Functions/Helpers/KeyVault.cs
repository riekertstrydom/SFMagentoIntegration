using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Threading.Tasks;

namespace CCB.SFMagentoIntegration.Functions.Helpers
{
    internal class KeyVault
    {
        public static async Task<KeyVaultSecret> GetSecret()
        {
            string keyVaultUrl = Environment.GetEnvironmentVariable("KEY_VAULT_URL");
            string keyVaultSecret = Environment.GetEnvironmentVariable("KEY_VAULT_SECRET");

            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            var secret = await client.GetSecretAsync(keyVaultSecret);

            return secret.Value;
        }
    }
}
