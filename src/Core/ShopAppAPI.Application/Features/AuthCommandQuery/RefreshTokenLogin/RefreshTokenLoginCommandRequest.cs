using MediatR;

namespace ShopAppAPI.Application.Features.AuthCommandQuery.RefreshToken;
public class RefreshTokenLoginCommandRequest : IRequest<BaseResponse<RefreshTokenLoginCommandResponse>>
{
    public string RefreshToken { get; set; }

    public RefreshTokenLoginCommandRequest(string refreshToken)
    {
        RefreshToken = refreshToken;
    }
}
