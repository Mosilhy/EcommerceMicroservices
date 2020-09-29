using Ecommerce.API.Customers.Db;
using Ecommerce.API.Customers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Customers.Providers
{
    public interface ICustomersProvider
    {

        Task <(bool IsSucess, IEnumerable<CustomerDTO> customers, string ErrorMesseges)> GetCustomersAsync();

        Task<(bool IsSucess, CustomerDTO customer, string ErrorMesseges)> GetCustomerAsync(int id);
    }
}
