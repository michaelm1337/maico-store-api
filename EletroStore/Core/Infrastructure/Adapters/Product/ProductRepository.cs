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

        public async Task<ProductEntity> CreateAsync(ProductEntity entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await _context.Products.FirstAsync(p => p.Id == id);
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<ProductEntity>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductEntity> GetAsync(Guid id)
        {
            return await _context.Products.FirstAsync(p => p.Id == id);
        }

        public async Task<ProductEntity> UpdateAsync(ProductEntity entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
