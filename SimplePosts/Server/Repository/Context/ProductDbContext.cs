using Microsoft.EntityFrameworkCore;
using SimplePosts.Shared.Models.Entities;
using System.Collections.Generic;

namespace SimplePosts.Server.Repository.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        #region public properties
        public DbSet<Product> Product { get; set; }
        #endregion

        #region override methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region private methods
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Sugar",
                    Description = "Sugar",
                    Price = 10,
                    Quantity = 1000
                },
                new Product
                {
                    Id = 2,
                    Name = "Salt",
                    Description = "Salt",
                    Price = 5,
                    Quantity = 800
                }
            };
        }
        #endregion
    }
}
