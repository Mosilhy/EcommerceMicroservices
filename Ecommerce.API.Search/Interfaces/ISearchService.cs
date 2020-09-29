using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Search.Interfaces
{
    public interface ISearchService
    {
        Task<(bool IsSucess, dynamic searchResult)> SearchAsync(int CustomerId);
    }
}
