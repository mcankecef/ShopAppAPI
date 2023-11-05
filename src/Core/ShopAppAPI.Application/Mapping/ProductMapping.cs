using AutoMapper;
using ShopAppAPI.Application.Dtos.Product;
using ShopAppAPI.Application.Features.ProductCommandQuery.Commands.CreateProduct;
using ShopAppAPI.Domain.Entities;

namespace ShopAppAPI.Application.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, GetAllProductQueryResponse>();
        // .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        CreateMap<Product, CreateProductCommandRequest>().ReverseMap();
        CreateMap<Product, GetProductsByCategoryIdResponse>();
        CreateMap<UpdateProductCommandRequest, Product>();
        CreateMap<ProductDto, Product>().ReverseMap();
    }
}
