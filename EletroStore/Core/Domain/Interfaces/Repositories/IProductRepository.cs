using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<ProductEntity> CreateAsync(ProductEntity entity);
        Task<ProductEntity> UpdateAsync(ProductEntity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<List<ProductEntity>> GetAllAsync();
        Task<ProductEntity> GetAsync(Guid id);
    }
}
