using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShopAppAPI.Domain;

namespace ShopAppAPI.Application.Features.UserCommandQuery.Commands.CreateUser;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, BaseResponse<CreateUserCommandResponse>>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<BaseResponse<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException("Model is not valid!");

        var appUser = new AppUser
        {
            UserName = request.UserName,
            Email = request.Email,
            FullName = request.FullName,
        };

        if (!request.Password.Equals(request.PasswordConfirm))
            return BaseResponse<CreateUserCommandResponse>.Fail("Passwords do not match!");

        var result = await _userManager.CreateAsync(appUser, request.Password);

        if (result.Succeeded)
        {
            var response = _mapper.Map<CreateUserCommandResponse>(appUser);

            return BaseResponse<CreateUserCommandResponse>.Success(response);
        }

        string message = string.Empty;

        foreach (var error in result.Errors)
            message += $"{error.Description}";

        return BaseResponse<CreateUserCommandResponse>.Fail(message);
    }
}
