namespace ShopAppAPI.Application;

public class CreateUserCommandResponse
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}
