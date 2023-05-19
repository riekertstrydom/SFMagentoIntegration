using Azure.Security.KeyVault.Secrets;
using CCB.SFMagentoIntegration.Functions.Models.Create;
using CCB.SFMagentoIntegration.Functions.Models.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CCB.SFMagentoIntegration.Functions
{
    public static class CreateCustomerFunction
    {
        [FunctionName("CreateCustomer")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string baseUrl = Environment.GetEnvironmentVariable("MagentoApiBaseUrl");
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                IncomingRequest request = JsonConvert.DeserializeObject<IncomingRequest>(requestBody);
                CreateRequest createRequest = new()
                {
                    Customer = new Customer()
                    {
                        Firstname = request.Firstname,
                        Lastname = request.Lastname,
                        GroupId = request.GroupId,
                        WebsiteId = request.WebsiteId,
                        Email = request.Email
                    }
                };

                string json = JsonConvert.SerializeObject(createRequest);

                using (HttpClient client = new())
                {
                    KeyVaultSecret secret = await Helpers.KeyVault.GetSecret();

                    client.BaseAddress = new Uri("https://mcstaging.istore.co.za");
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {secret.Value}");

                    HttpResponseMessage response = await client.PostAsJsonAsync($"/rest/default/V1/customers", new StringContent(json));
                    response.EnsureSuccessStatusCode();

                    string content = await response.Content.ReadAsStringAsync();
                    List<Item> items = JsonConvert.DeserializeObject<List<Item>>(content);

                    if (items.Any())
                    {
                        return new OkObjectResult(items);
                    }
                }

                return new OkResult();
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString());
                return new BadRequestResult();
            }
        }
    }
}
