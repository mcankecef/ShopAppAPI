using AutoMapper;
using ShopAppAPI.Application.Features.BasketCommandQuery.Queries.GetBasketByUserId;
using ShopAppAPI.Domain;

namespace ShopAppAPI.Application;

public class BasketMapping : Profile
{
    public BasketMapping()
    {
        CreateMap<AddBasketCommandRequest, Basket>();
    }
}
