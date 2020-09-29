using Ecommerce.API.Customers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Mappers;
namespace Ecommerce.API.Customers.Profiles
{
    public class CustomerProfile : AutoMapper.Profile
    {
        public CustomerProfile()
        { 
            CreateMap<Db.Customer,CustomerDTO>();

        }
    }
}
