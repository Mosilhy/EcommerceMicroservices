using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.API.Search.Interfaces;
using Ecommerce.API.Search.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.API.Search.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        // GET: api/<SearchController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SearchController>/5
        [HttpPost]
        public async Task<IActionResult>SearchAsync(SearchTerm term)
        {
            (bool IsSucess, dynamic searchResult) results = await _searchService.SearchAsync(term.CustomerId);

            //return results.IsSucess ? Ok(results) : NotFound();

            if (results.IsSucess)
            {
                return Ok(results.searchResult);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
