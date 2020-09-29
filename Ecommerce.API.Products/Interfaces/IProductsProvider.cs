using Ecommerce.API.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Products.Interfaces
{
    public interface IProductsProvider
    {

        Task<(bool IsSucess, IEnumerable<Product> products, string ErrorMesseges)> GetProductsAsync();

        Task<(bool IsSucess,Product products, string ErrorMesseges)> GetProductAsync(int id);

    }
}
