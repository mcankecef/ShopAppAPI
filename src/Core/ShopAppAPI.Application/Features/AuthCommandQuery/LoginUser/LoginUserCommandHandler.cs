using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopAppAPI.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ShopAppAPI.Application.Features.AuthCommandQuery.LoginUser;
public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, BaseResponse<LoginUserCommandResponse>>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenHandler _tokenHandler;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public LoginUserCommandHandler(UserManager<AppUser> userManager,
       SignInManager<AppUser> signInManager,
       ITokenHandler tokenHandler,
       IUserService userService, 
       IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenHandler = tokenHandler;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<BaseResponse<LoginUserCommandResponse>> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var userQuery = _userManager.Users
            .AsQueryable();

        var user = await userQuery
            .FirstOrDefaultAsync(u => u.UserName == request.UsernameOrEmail);

        user ??= await userQuery
            .FirstOrDefaultAsync(u => u.Email == request.UsernameOrEmail);

        if (user is null)
            throw new UserLoginFailedException("Username or password incorrect!");

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (result.Succeeded)
        {
            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name,user.FullName),
                new(ClaimTypes.Email,user.Email),
                new(ClaimTypes.NameIdentifier,user.Id),
                new(JwtRegisteredClaimNames.Jti,new Guid().ToString()),
            };

            var token = _tokenHandler.CreateAccessToken(7, authClaims);

            token.UserId = user.Id;
            token.UserName = user.UserName;
            token.Email = user.Email;
            token.FullName = user.FullName;

            var refreshTokenLifeTime = token.Expiration.AddHours(1);

            await _userService.UpdateRefreshToken(user, token.RefreshToken, refreshTokenLifeTime);

            var response = _mapper.Map<LoginUserCommandResponse>(token);

            return BaseResponse<LoginUserCommandResponse>.Success(response);
        }

        return BaseResponse<LoginUserCommandResponse>.Fail("Failed logged into the application");
    }

}
