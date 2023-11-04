using AutoMapper;
using ShopAppAPI.Domain;

namespace ShopAppAPI.Application;

public class BasketMapping : Profile
{
    public BasketMapping()
    {
        CreateMap<AddBasketCommandRequest,Basket>();
    }
}
