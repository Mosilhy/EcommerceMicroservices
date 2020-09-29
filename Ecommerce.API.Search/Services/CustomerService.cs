using Ecommerce.API.Search.Interfaces;
using Ecommerce.API.Search.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce.API.Search.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IHttpClientFactory httpClientFactory, ILogger<CustomerService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public async Task<(bool IsSucess, Customer customers, string ErrorMessege)> GetCustomersAsync(int CustomerId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("CustomerService");
                var responce = await client.GetAsync($"api/customers/{CustomerId}");
                if (responce.IsSuccessStatusCode)
                {
                    var content = await responce.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<Customer>(content, options);
                    Console.WriteLine(result.Name);
                    return (true, result, null);
                }
                return (false, null, "Error");
            }

            catch (Exception ex)
            {

                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);

            }
        }
    }
}
