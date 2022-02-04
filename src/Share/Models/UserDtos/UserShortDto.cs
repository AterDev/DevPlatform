namespace Share.Models.UserDtos;
/// <summary>
/// 账号表
/// </summary>
public class UserShortDto
{
    public Guid Id { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string? NormalizedUserName { get; set; }
    public string Email { get; set; } = default!;
    public string? NormalizedEmail { get; set; }
    public bool EmailConfirmed { get; set; } = default!;
    // public string PasswordHash { get; set; }
    /// <summary>
    /// A random value that must change whenever a users credentials change (password changed, login removed)
    /// </summary>
    public string? SecurityStamp { get; set; }

    /// <summary>
    /// A random value that must change whenever a user is persisted to the store
    /// </summary>
    public string ConcurrencyStamp { get; set; } = default!;

    public string? PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; } = default!;
    public bool TwoFactorEnabled { get; set; } = default!;
    public DateTimeOffset? LockoutEnd { get; set; }
    public bool LockoutEnabled { get; set; } = default!;
    public int AccessFailedCount { get; set; } = default!;
    /// <summary>
    /// 最后登录时间
    /// </summary>
    public DateTimeOffset? LastLoginTime { get; set; }
    /// <summary>
    /// 软删除
    /// </summary>
    public bool IsDeleted { get; set; } = default!;
    /// <summary>
    /// 密码重试次数
    /// </summary>
    public int RetryCount { get; set; } = default!;
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    /// <summary>
    /// 头像url
    /// </summary>
    [MaxLength(200)]
    public string? Avatar { get; set; }
    public UserInfo? Extend { get; set; } = default!;
    
}
