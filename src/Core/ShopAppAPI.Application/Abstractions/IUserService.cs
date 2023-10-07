using ShopAppAPI.Domain;

namespace ShopAppAPI.Application;

public interface IUserService
{
    Task<List<GetAllUserDto>> GetAllUser();
    Task<GetUserByIdDto> GetUserById(string userId);
    Task UpdateUser(UpdateUserDto updateUserDto);
    Task DeleteUser(string userId);
    Task UpdateRefreshToken(AppUser user, string refreshToken, DateTime refreshTokenLifeTime);
}
