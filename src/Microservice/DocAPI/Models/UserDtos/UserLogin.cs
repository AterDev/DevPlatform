namespace DocAPI.Models.UserDtos;

public class UserLogin
{
    [MaxLength(30)]
    public string UserName { get; set; } = default!;
    [MaxLength(50)]
    public string Password { get; set; } = default!;
}
