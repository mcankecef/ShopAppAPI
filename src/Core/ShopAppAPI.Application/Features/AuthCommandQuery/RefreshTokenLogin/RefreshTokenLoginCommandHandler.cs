using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopAppAPI.Domain;

namespace ShopAppAPI.Application.Features.AuthCommandQuery.RefreshToken;
public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, BaseResponse<RefreshTokenLoginCommandResponse>>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserService _userService;
    private readonly ITokenHandler _tokenHandler;
    private readonly IMapper _mapper;

    public RefreshTokenLoginCommandHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IUserService userService, IMapper mapper)
    {
        _userManager = userManager;
        _tokenHandler = tokenHandler;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<BaseResponse<RefreshTokenLoginCommandResponse>> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == request.RefreshToken);

        if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
        {
            var token = _tokenHandler.CreateAccessToken(7, null);

            var accessTokenLifeTime = token.Expiration.AddHours(1);

            await _userService.UpdateRefreshToken(user, token.RefreshToken, accessTokenLifeTime);

            var response = _mapper.Map<RefreshTokenLoginCommandResponse>(token);

            return BaseResponse<RefreshTokenLoginCommandResponse>.Success(response);
        }
        return BaseResponse<RefreshTokenLoginCommandResponse>.Fail("Refresh token operation failed.");
    }
}
