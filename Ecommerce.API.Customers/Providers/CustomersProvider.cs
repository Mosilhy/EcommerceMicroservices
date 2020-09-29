using AutoMapper;
using Ecommerce.API.Customers.Db;
using Ecommerce.API.Customers.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Customers.Providers
{
    public class CustomersProvider : ICustomersProvider
    {
        private readonly CustomersDbContext _customersDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomersProvider> _logger;

        public CustomersProvider(CustomersDbContext customersDbContext,IMapper mapper, ILogger<CustomersProvider> logger)
        {
            _customersDbContext = customersDbContext;
            _mapper = mapper;
            _logger = logger;
            SeedData();
        }

        private void SeedData()
        {
            if (!_customersDbContext.Customers.Any())
            {
                _customersDbContext.Customers.Add(new Db.Customer() { Id = 1, Name = "Mohamed", Address="Nasr City" });

                _customersDbContext.Customers.Add(new Db.Customer() { Id = 2, Name = "Ahmed", Address = "City" });

                _customersDbContext.Customers.Add(new Db.Customer() { Id = 3, Name = "Said", Address = "New City" });

                _customersDbContext.Customers.Add(new Db.Customer() { Id = 4, Name = "Ibrahim", Address = "Tagamo3" });

                _customersDbContext.SaveChanges();

            }

        }


        public async Task<(bool IsSucess, IEnumerable<CustomerDTO> customers, string ErrorMesseges)> GetCustomersAsync()
        {

            try
            {
                var customers2 = await _customersDbContext.Customers.ToListAsync();

                if (customers2 != null && customers2.Any())
                {
                    var result = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers2);
                    return (true, result, null);
                }
            }
            catch (Exception ex)
            {

                return (false, null, ex.Message);
            }
            return (false, null,"Not Found");

        }

        public async Task<(bool IsSucess, CustomerDTO customer, string ErrorMesseges)> GetCustomerAsync(int id)
        {
            try
            {
                var customers2 = await _customersDbContext.Customers.FirstOrDefaultAsync(x=>x.Id==id);

                if (customers2 != null )
                {
                    var result = _mapper.Map<Customer, CustomerDTO>(customers2);
                    return (true, result, null);
                }
            }
            catch (Exception ex)
            {

                return (false, null, ex.Message);
            }
            return (false, null, "Not Found");
        }
    }
}
