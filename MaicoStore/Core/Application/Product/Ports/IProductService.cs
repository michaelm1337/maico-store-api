using Application.Product.DTO;
using Domain.Entities;

namespace Application.Product.Ports
{
    public interface IProductService
    {
        Task<Result<ProductDTO>> GetAsync(Guid id);
        Task<Result<List<ProductDTO>>> GetAllAsync();
        Task<Result<bool>> DeleteAsync(Guid id);
        Task<Result<bool>> UpdateAsync(ProductDTO productDTO);
        Task<Result<bool>> CreateAsync(ProductDTO productDTO);
    }
}
