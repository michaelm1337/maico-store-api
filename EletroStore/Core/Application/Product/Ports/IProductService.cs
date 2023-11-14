using Application.Product.DTO;
using Domain.Entities;

namespace Application.Product.Ports
{
    public interface IProductService
    {
        Task<Result<ProductDTO>> GetAsync(Guid id);
        Task<Result<List<ProductDTO>>> GetAllAsync();
        Task<Result<bool>> DeleteAsync(Guid id);
        Task<Result<ProductDTO>> UpdateAsync(ProductDTO productDTO);
        Task<Result<ProductDTO>> CreateAsync(ProductDTO productDTO);
    }
}
