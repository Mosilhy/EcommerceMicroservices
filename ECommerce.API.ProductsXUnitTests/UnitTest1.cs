using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Ecommerce.API.Products.Db;
using Ecommerce.API.Products.Profiles;
using AutoMapper;
using Ecommerce.API.Products.Provides;
using System.Linq;

namespace ECommerce.API.ProductsXUnitTests
{
    public class ProductsServiceTest
    {
        [Fact]
        public async Task GetProductsReturnsAllProducts()
        {

            var options = new DbContextOptionsBuilder<ProductsDbContext>().
                UseInMemoryDatabase(nameof(GetProductsReturnsAllProducts)).Options;

            var dbContext = new ProductsDbContext(options);
            CreateProducts(dbContext);

            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            var mapper = new Mapper(configuration);

            var productsProvider = new ProductsProvider(dbContext, null, mapper);

            var products = await productsProvider.GetProductsAsync();
            Assert.True(products.IsSucess);
            Assert.True(products.products.Any());
            Assert.Null(products.ErrorMesseges);
        }


        [Fact]
        public async Task ReturnProductByValidId()
        {

            var options = new DbContextOptionsBuilder<ProductsDbContext>().
                UseInMemoryDatabase(nameof(ReturnProductByValidId)).Options;

            var dbContext = new ProductsDbContext(options);
            CreateProducts(dbContext);

            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            var mapper = new Mapper(configuration);

            var productsProvider = new ProductsProvider(dbContext, null, mapper);
            var products2 = await productsProvider.GetProductsAsync();

            var products = await productsProvider.GetProductAsync(11);
            Assert.True(products.IsSucess);
            Assert.True(products.products.Id == 11);
            Assert.NotNull(products.products);
            Assert.Null(products.ErrorMesseges);
        }

        private void CreateProducts(ProductsDbContext dbContext)
        {
            for (int i = 10; i < 21; i++)
            {
                var pro= new Product()
                {
                    Id = i,
                    Name = "Product Name" + i.ToString(),
                    Inventory = i,
                    Price = (decimal)(i * 3.1)
                };
                dbContext.Products.Add(pro) ;
            }
            dbContext.SaveChanges();
        }
    }
}
