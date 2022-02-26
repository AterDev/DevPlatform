namespace DocAPI.Models.UserDtos;

public class LoginResult
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }

    public LoginResult(Guid id, string userName, string token)
    {
        Id = id;
        UserName = userName;
        Token = token;
    }
}
