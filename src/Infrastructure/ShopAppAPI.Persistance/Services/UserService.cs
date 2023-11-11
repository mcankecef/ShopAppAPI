using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopAppAPI.Application;
using ShopAppAPI.Domain;

namespace ShopAppAPI.Persistance;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public UserService(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<bool> UserExistAsync(string userId)
        => await _userManager.Users.AnyAsync(u => u.Id == userId);

    public async Task<GetUserByIdDto> GetUserById(string userId)
    {
        var user = await _userManager.Users
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user is null)
            throw new ArgumentNullException($"User is not found");

        return _mapper.Map<GetUserByIdDto>(user);
    }

    public async Task UpdateUser(UpdateUserDto updateUserDto)
    {

        var user = await _userManager.FindByIdAsync(updateUserDto.UserId);

        var email = await _userManager.FindByEmailAsync(updateUserDto.Email);

        if (user is null)
            throw new ArgumentNullException($"User is not found");

        else if (email != null)
            if (email.Email != user.Email) throw new ArgumentException("Email already exists");

        user.Email = updateUserDto.Email ?? user.Email;
        user.FullName = updateUserDto.FullName ?? user.FullName;

        await _userManager.UpdateAsync(user);
    }

    public async Task DeleteUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId) ?? throw new ArgumentNullException($"User is not found");
        await _userManager.DeleteAsync(user);
    }

    public async Task UpdateRefreshToken(AppUser user, string refreshToken, DateTime refreshTokenLifeTime)
    {

        if (user != null)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenEndDate = refreshTokenLifeTime;

            await _userManager.UpdateAsync(user);
        }
        else
            throw new UserNotFoundException("User is not found!");
    }

    public async Task<List<GetAllUserDto>> GetAllUser()
    {
        var users = await _userManager.Users.ToListAsync();

        var dto = _mapper.Map<List<GetAllUserDto>>(users);

        return dto;
    }
}
