using AutoMapper;
using ShopAppAPI.Application;
using ShopAppAPI.Application.Features.UserCommandQuery.Commands.UpdateUser;
using ShopAppAPI.Domain;

namespace CodeApp.Application.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, CreateUserCommandResponse>().ReverseMap();
            CreateMap<AppUser, GetAllUserDto>().ReverseMap();
            CreateMap<GetAllUserDto, GetAllUserQueryResponse>();
            CreateMap<AppUser, GetUserByIdDto>().ReverseMap();
            CreateMap<GetUserByIdDto, GetUserByIdQueryResponse>();
            CreateMap<UpdateUserCommandRequest, UpdateUserDto>().ReverseMap();
        }
    }
}
