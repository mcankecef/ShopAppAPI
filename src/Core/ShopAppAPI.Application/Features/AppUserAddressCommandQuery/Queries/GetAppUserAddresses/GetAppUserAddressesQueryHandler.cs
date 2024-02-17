using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAppAPI.Application.Repositories.AppUserAddress;

namespace ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Queries.GetAppUserAddresses;

public class GetAppUserAddressesQueryHandler : IRequestHandler<GetAppUserAddressesQueryRequest, BaseResponse<List<GetAppUserAddressesQueryResponse>>>
{
    private readonly IAppUserAddressReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetAppUserAddressesQueryHandler(IAppUserAddressReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<List<GetAppUserAddressesQueryResponse>>> Handle(GetAppUserAddressesQueryRequest request, CancellationToken cancellationToken)
    {
        var appUserAddresses = await _readRepository
            .GetByFilter(r => r.AppUserId.Equals(request.UserId))
            .ToListAsync();

        return BaseResponse<List<GetAppUserAddressesQueryResponse>>
            .Success(_mapper.Map<List<GetAppUserAddressesQueryResponse>>(appUserAddresses));
    }
}
