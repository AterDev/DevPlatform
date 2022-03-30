namespace DocAPI.Models.UserDtos;

public class UserFilter : FilterBase
{
    [MaxLength(30)]
    public string? UserName { get; set; }
    // [MaxLength(50)]
    // public string? Password { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    
}
