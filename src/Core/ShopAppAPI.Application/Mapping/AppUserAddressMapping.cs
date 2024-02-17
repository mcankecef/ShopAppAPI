using AutoMapper;
using ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Commands.CreateAppUserAddress;
using ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Queries.GetAppUserAddresses;
using ShopAppAPI.Domain.Entities;

namespace ShopAppAPI.Application.Mapping;

public class AppUserAddressMapping : Profile
{
    public AppUserAddressMapping()
    {
        CreateMap<AppUserAddress, GetAppUserAddressesQueryResponse>();
        CreateMap<AppUserAddress, CreateAppUserAddressCommandResponse>();
    }
}
