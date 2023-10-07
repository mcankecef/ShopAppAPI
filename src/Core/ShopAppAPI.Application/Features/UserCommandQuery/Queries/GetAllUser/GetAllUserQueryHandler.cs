using AutoMapper;
using MediatR;

namespace ShopAppAPI.Application.Features.UserCommandQuery.Queries.GetAllUser;
public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, BaseResponse<List<GetAllUserQueryResponse>>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetAllUserQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<BaseResponse<List<GetAllUserQueryResponse>>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllUser();

        var response = _mapper.Map<List<GetAllUserQueryResponse>>(users);

        return BaseResponse<List<GetAllUserQueryResponse>>.Success(response);
    }

}
