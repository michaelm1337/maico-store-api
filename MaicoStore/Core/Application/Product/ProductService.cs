using Application.Product.DTO;
using Application.Product.Ports;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Net;

namespace Application.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<bool>> CreateAsync(ProductDTO productDTO)
        {
            try
            {
                var product = _mapper.Map<ProductEntity>(productDTO);
                _repository.Create(product);
                await _repository.SaveChangesAsync();

                return new Result<bool>
                {
                    Data = true,
                    Message = "Product successfully created",
                    StatusCode = HttpStatusCode.Created,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new Result<bool>
                {
                    Message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Success = false
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(Guid id)
        {
            try
            {
                var result = _repository.Delete(id);
                await _repository.SaveChangesAsync();

                return new Result<bool>
                {
                    Data = result,
                    Message = "Product successfully deleted",
                    StatusCode = HttpStatusCode.OK,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new Result<bool>
                {
                    Message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Success = false
                };
            }
        }

        public async Task<Result<List<ProductDTO>>> GetAllAsync()
        {
            try
            {
                var result = await _repository.GetAllAsync();
                var dto = _mapper.Map<List<ProductEntity>, List<ProductDTO>>(result);

                return new Result<List<ProductDTO>>
                {
                    Data = dto,
                    Message = "Products successfully retrieved",
                    StatusCode = HttpStatusCode.OK,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new Result<List<ProductDTO>>
                {
                    Message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Success = false
                };
            }
        }

        public async Task<Result<ProductDTO>> GetAsync(Guid id)
        {
            try
            {
                var result = await _repository.GetAsync(id);

                if (result is null)
                {
                    return new Result<ProductDTO>
                    {
                        Data = null,
                        Message = "Product was not found",
                        StatusCode = HttpStatusCode.NotFound,
                        Success = true
                    };
                }

                var dto = _mapper.Map<ProductDTO>(result);

                return new Result<ProductDTO>
                {
                    Data = dto,
                    Message = "Product successfully retrieved",
                    StatusCode = HttpStatusCode.OK,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new Result<ProductDTO>
                {
                    Message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Success = false
                };
            }
        }

        public async Task<Result<bool>> UpdateAsync(ProductDTO productDTO)
        {
            try
            {
                var product = _mapper.Map<ProductEntity>(productDTO);
                _repository.Update(product);
                await _repository.SaveChangesAsync();

                return new Result<bool>
                {
                    Data = true,
                    Message = "Products successfully updated",
                    StatusCode = HttpStatusCode.OK,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new Result<bool>
                {
                    Message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Success = false
                };
            }
        }
    }
}
