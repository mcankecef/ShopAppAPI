using AutoMapper;

namespace ShopAppAPI.Application;

public class AuthMapping : Profile
{
    public AuthMapping()
    {
        CreateMap<TokenDto, LoginUserCommandResponse>();
    }
}
