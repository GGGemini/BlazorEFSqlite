using SimplePosts.Server.Repository.Base;
using SimplePosts.Server.Repository.Context;
using SimplePosts.Server.Repository.Interfaces;
using SimplePosts.Shared.Models.Entities;

namespace SimplePosts.Server.Repository
{
    public class ProductsRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
