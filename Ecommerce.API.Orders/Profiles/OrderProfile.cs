using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.API.Orders.Db;
using Ecommerce.API.Orders.DTOs;
using AutoMapper;
namespace Ecommerce.API.Orders.Profiles
{
    public class OrderProfile:AutoMapper.Profile
    {
        public OrderProfile()
        {
           CreateMap<Order, OrderDTO>();
            CreateMap<OrderItem, OrderItemDTO>();

        }


    }
}
