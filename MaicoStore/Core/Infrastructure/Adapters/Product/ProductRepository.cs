using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Adapters.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly MaicoStoreContext _context;
        public ProductRepository(MaicoStoreContext context)
        {
            _context = context;
        }

        public void Create(ProductEntity entity)
        {
            _context.Products.Add(entity);
        }

        public bool Delete(Guid id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                return true;
            }
            return false;
        }

        public async Task<List<ProductEntity>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductEntity> GetAsync(Guid id)
        {
            return await _context.Products.FirstAsync(p => p.Id == id);
        }

        public void Update(ProductEntity entity)
        {
            _context.Products.Update(entity);
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
