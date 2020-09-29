using AutoMapper;
using Ecommerce.API.Orders.Db;
using Ecommerce.API.Orders.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Orders.Providers
{
    public class OrderProvider : IOrderProvider
    {
        private readonly OrdersDbContext _ordersDbContext;
        private readonly ILogger<OrderProvider> _logger;
        private readonly IMapper _mapper;

        public OrderProvider(OrdersDbContext ordersDbContext, ILogger<OrderProvider> logger, IMapper mapper)
        {
            _ordersDbContext = ordersDbContext;
            _logger = logger;
            _mapper = mapper;
            AddSeed();
        }

        private void AddSeed()
        {
            if (!_ordersDbContext.orders.Any())
            {
                var item1 = new OrderItem { Id = 1, OrderId =1, ProductId = 1, Quantity = 5, UnitPrice = 20.5M };
                var item2= new OrderItem { Id = 2, OrderId = 2, ProductId = 2, Quantity = 5, UnitPrice = 30.5M };
                var item3 = new OrderItem { Id = 3, OrderId = 3, ProductId = 3, Quantity = 5, UnitPrice = 40.5M };

                List<OrderItem> orderItems = new List<OrderItem> { item1, item2, item3 };
                _ordersDbContext.orders.Add(new Order() { Id = 1,CustomerId=1,OrderDate=DateTime.Today,Total=10,Items=orderItems });

                _ordersDbContext.orders.Add(new Order() { Id = 2, CustomerId = 2, OrderDate = DateTime.Today.AddDays(-1), Total = 10, Items = orderItems });

                _ordersDbContext.orders.Add(new Order() { Id =3, CustomerId = 3, OrderDate = DateTime.Today.AddDays(-2), Total = 10, Items = orderItems });


                _ordersDbContext.SaveChanges();

            }

        }

        public async Task<(bool IsSucess, IEnumerable< OrderDTO> order, string ErrorMesseges)> GetOrderAsync(int id)
        {
            try
            {
                var customers2 = await _ordersDbContext.orders.Where(x => x.Id == id).Include(x => x.Items).ToListAsync();

                if (customers2 != null)
                {
                    var result = _mapper.Map< IEnumerable<Order>, IEnumerable<OrderDTO>>(customers2);
                    return (true, result, null);
                }
            }
            catch (Exception ex)
            {

                return (false, null, ex.Message);
            }
            return (false, null, "Not Found");
        }

        public async Task<(bool IsSucess, IEnumerable<OrderDTO> orders, string ErrorMesseges)> GetOrdersAsync()
        {
            try
            {
                var products = await _ordersDbContext.orders.Include(x => x.Items).ToListAsync();

                if (products != null && products.Any())
                {
                    var result = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(products);

                    return (true, result, null);
                }
                return (false, null, "Not Found");


            }
            catch (Exception ex)
            {

                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);

            }
        }
    }
}
