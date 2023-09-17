using AutoMapper;
using ShopAppAPI.Application.Features.ProductCommandQuery.Commands;
using ShopAppAPI.Domain.Entities;

namespace ShopAppAPI.Application.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, GetAllProductQueryResponse>().ReverseMap();
        CreateMap<Product, CreateProductCommandRequest>().ReverseMap();
    }
}
