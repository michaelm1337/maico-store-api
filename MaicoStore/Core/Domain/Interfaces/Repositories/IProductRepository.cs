using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        void Create(ProductEntity entity);
        void Update(ProductEntity entity);
        bool Delete(Guid id);
        Task<List<ProductEntity>> GetAllAsync();
        Task<ProductEntity> GetAsync(Guid id);
        Task SaveChangesAsync();
    }
}
