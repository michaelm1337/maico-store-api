using Application.Product.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Product.Mappers
{
    public sealed class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductEntity, ProductDTO>()
                .ReverseMap();
        }
    }
}
