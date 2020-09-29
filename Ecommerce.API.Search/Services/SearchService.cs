using Ecommerce.API.Search.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrderService _orderService;

        private readonly IProductsService _productsService;
        private readonly ICustomerService _customerService;


        public SearchService(IOrderService orderService,IProductsService productsService,ICustomerService customerService)
        {
            _productsService = productsService;
            _orderService = orderService;
            _customerService = customerService;
        }
        public async Task<(bool IsSucess, dynamic searchResult)> SearchAsync(int CustomerId)
        {

            var orderresult = await _orderService.GetOrdersAsync(CustomerId);
            var productresult = await _productsService.GetProductAsync();
            var customerresult = await _customerService.GetCustomersAsync(CustomerId);


            if (orderresult.IsSucess)
            {
                foreach (var order in orderresult.orders)
                {

                    order.CustomerName = customerresult.IsSucess ? customerresult.customers.Name : "Customer Name Not Available";

                    foreach (var item in order.Items)
                    {
                        item.ProductName = productresult.IsSucess? productresult.products.FirstOrDefault(p => p.Id == item.ProductId)?.Name:"Product Not Available";

                    }
                }

                return (true, orderresult.orders);
            }
            else
            {
                return (false, null);
            }
           
        }
    }
}
