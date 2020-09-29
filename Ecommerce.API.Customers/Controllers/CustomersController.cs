using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.API.Customers.DTOs;
using Ecommerce.API.Customers.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.API.Customers.Controllers
{
    [ApiController]
    [Route("api/customers")]
    
    public class CustomersController : ControllerBase

        
    {


        private readonly ICustomersProvider _customersProvider;
        public CustomersController(ICustomersProvider customersProvider)
        {
            _customersProvider = customersProvider;
        }// GET: api/<CustomersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var results= await _customersProvider.GetCustomersAsync();
            return Ok(results.customers);

        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var results = await _customersProvider.GetCustomerAsync(id);
            return Ok(results.customer);

        }

    }
}
