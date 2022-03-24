namespace DocAPI.Models.UserDtos;

public class UserItemDto
{
    [MaxLength(30)]
    public string UserName { get; set; } = default!;
    // [MaxLength(50)]
    // public string Password { get; set; }
    [MaxLength(200)]
    public string? Avatar { get; set; }
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    
}
