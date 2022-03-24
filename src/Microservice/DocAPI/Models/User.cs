namespace DocAPI.Models;

/// <summary>
/// 用户
/// </summary>
public class User : EntityBase
{
    [MaxLength(30)]
    public string UserName { get; set; } = default!;
    [MaxLength(50)]
    public string Password { get; set; } = default!;
    [MaxLength(200)]
    public string? Avatar { get; set; }
}
