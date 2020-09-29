using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.API.Orders.Providers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.API.Orders.Controllers
{
    [ApiController]
    [Route("api/Orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderProvider _orderProvider;

        public OrdersController(IOrderProvider orderProvider)
        {
            _orderProvider = orderProvider;
        }


        // GET: api/<Orders>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _orderProvider.GetOrdersAsync();
            return Ok(results.orders);

        }

        // GET api/<Orders>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var results = await _orderProvider.GetOrderAsync(id);
            return Ok(results.order);

        }

        // POST api/<Orders>


    }
}
