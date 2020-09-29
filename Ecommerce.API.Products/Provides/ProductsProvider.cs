using AutoMapper;
using Ecommerce.API.Products.Db;
using Ecommerce.API.Products.Interfaces;
using Ecommerce.API.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product = Ecommerce.API.Products.Models.Product;

namespace Ecommerce.API.Products.Provides
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly ProductsDbContext _productsDbContext;
        private readonly ILogger<ProductsProvider> _logger;
        private readonly IMapper _mapper;


        public ProductsProvider(ProductsDbContext productsDbContext,ILogger<ProductsProvider> logger, IMapper mapper)
        {
            _productsDbContext = productsDbContext;
            _logger = logger;
            _mapper = mapper;
            SeedData();
        }

        private void SeedData()
        {
            if (!_productsDbContext.Products.Any())
            {
                _productsDbContext.Products.Add(new Db.Product() { Id = 1, Name = "Keyboard", Price = 20,Inventory=10 });
                _productsDbContext.Products.Add(new Db.Product() { Id = 2, Name = "Mouse", Price = 10,Inventory=20 });
                _productsDbContext.Products.Add(new Db.Product() { Id = 3, Name = "Monitor", Price = 100,Inventory=30 });
                _productsDbContext.Products.Add(new Db.Product() { Id = 4, Name = "CPU", Price = 200 ,Inventory=100});
                _productsDbContext.SaveChanges();

            }

        }

        public async Task<(bool IsSucess, IEnumerable<Product> products,
            string ErrorMesseges)> GetProductsAsync()
        {


            try
            {
                var products = await _productsDbContext.Products.ToListAsync();

                if (products!=null&&products.Any())
                {
                   var result= _mapper.Map<IEnumerable<Db.Product>, IEnumerable<Models.Product>>(products);

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



        public async Task<(bool IsSucess, Product products,
            string ErrorMesseges)> GetProductAsync(int id)
        {


            try
            {
                var products =  await _productsDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

                if (products != null)
                {
                    var result = _mapper.Map<Db.Product,Models.Product>(products);

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
