using Microsoft.EntityFrameworkCore;
using SimplePosts.Server.Repository.Context;
using SimplePosts.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplePosts.Server.Services
{
    public class ProductServices
    {
        private ProductDbContext dbContext;

        public ProductServices(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await dbContext.Product.ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await dbContext.Product.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            dbContext.Product.Add(product);
            await dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            if (dbContext.Product.Contains(product))
            {
                dbContext.Product.Update(product);
                await dbContext.SaveChangesAsync();

                return product;
            }
            else
            {
                throw new Exception($"Сущности с id {product.Id} не существует");
            }
        }

        public async Task DeleteProductAsync(Product product)
        {
            dbContext.Product.Remove(product);
            await dbContext.SaveChangesAsync();
        }
    }
}
