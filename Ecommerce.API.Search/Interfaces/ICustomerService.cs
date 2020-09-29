using Ecommerce.API.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Search.Interfaces
{
    public interface ICustomerService
    {

        Task<(bool IsSucess,Customer customers,string ErrorMessege)>GetCustomersAsync(int CustomerID);
    }
}
