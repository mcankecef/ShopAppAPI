using AutoMapper;
using MediatR;
using ShopAppAPI.Application.Features.UserCommandQuery.Queries.GetByUserId;

namespace ShopAppAPI.Application.Features.UserCommandQuery.Queries.GetUserByIdId;
public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, BaseResponse<GetUserByIdQueryResponse>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetUserByIdQueryResponse>> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
    {
        if (request.UserId is null)
            throw new ArgumentNullException("User id is must not null!");

        var result = await _userService.GetUserById(request.UserId);

        var response = _mapper.Map<GetUserByIdQueryResponse>(result);

        return BaseResponse<GetUserByIdQueryResponse>.Success(response);
    }
}
