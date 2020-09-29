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
    public class OrderService : IOrderService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<Order> _logger;

        public OrderService(IHttpClientFactory httpClientFactory,ILogger<Order> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public async Task<(bool IsSucess, IEnumerable<Order> orders, string ErrorMessege)> GetOrdersAsync(int CustomerId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("OrderService");
                var responce = await client.GetAsync($"api/orders/{CustomerId}");
                if (responce.IsSuccessStatusCode)
                {
                    var content = await responce.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<Order>>(content,options);
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
