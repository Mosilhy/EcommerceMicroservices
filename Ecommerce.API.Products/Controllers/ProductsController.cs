using Ecommerce.API.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Products.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Route("api/")]

    public class ProductsController:Controller
    {
        private readonly IProductsProvider _productsProvider;

        public ProductsController(IProductsProvider productsProvider)
        {
            _productsProvider = productsProvider;


        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {

            var result= await _productsProvider.GetProductsAsync();
            if (result.IsSucess)
            {
                return Ok(result.products);
            }
           
                return NotFound();
            
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {

            var result = await _productsProvider.GetProductAsync(id);
            if (result.IsSucess)
            {
                return Ok(result.products);
            }

            return NotFound();

        }
    }
}
