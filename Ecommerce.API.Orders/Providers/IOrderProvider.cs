using Ecommerce.API.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Orders.Providers
{
    public interface IOrderProvider
    {

        Task<(bool IsSucess, IEnumerable<OrderDTO> orders, string ErrorMesseges)> GetOrdersAsync();

        Task<(bool IsSucess, IEnumerable<OrderDTO> order, string ErrorMesseges)> GetOrderAsync(int id);
    }
}
