namespace DocAPI.Models.UserDtos;

public class UserUpdateDto
{
    [MaxLength(30)]
    public string? UserName { get; set; }
    // [MaxLength(50)]
    // public string? Password { get; set; }
    [MaxLength(200)]
    public string? Avatar { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    
}
