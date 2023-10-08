namespace ShopAppAPI.Application;

public class UserLoginFailedException: Exception
{
    public UserLoginFailedException()
    {

    }
    public UserLoginFailedException(string? message) : base(message)
    {
    }

}
