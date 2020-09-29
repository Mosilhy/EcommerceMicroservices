using Ecommerce.API.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Search.Interfaces
{
    public interface IProductsService
    {
        Task<(bool IsSucess, IEnumerable<Product> products, string ErrorMessege)> GetProductAsync();
    }
}
