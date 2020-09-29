using Ecommerce.API.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Search.Interfaces
{
    public interface IOrderService
    {
        Task<(bool IsSucess, IEnumerable<Order> orders, string ErrorMessege)> GetOrdersAsync(int CustomerId);
    }
}
