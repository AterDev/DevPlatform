namespace Share.Models.AccountDtos;
/// <summary>
/// 账号表
/// </summary>
public class AccountShortDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string? NormalizedUserName { get; set; }
    public string Email { get; set; } = default!;
    public string? NormalizedEmail { get; set; }
    public bool EmailConfirmed { get; set; }
    // public string PasswordHash { get; set; }
    /// <summary>
    /// A random value that must change whenever a users credentials change (password changed, login removed)
    /// </summary>
    public string? SecurityStamp { get; set; }

    /// <summary>
    /// A random value that must change whenever a user is persisted to the store
    /// </summary>
    public string ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public DateTimeOffset? LockoutEnd { get; set; }
    public bool LockoutEnabled { get; set; }
    public int AccessFailedCount { get; set; }
    /// <summary>
    /// 最后登录时间
    /// </summary>
    public DateTimeOffset? LastLoginTime { get; set; }
    /// <summary>
    /// 软删除
    /// </summary>
    public bool IsDeleted { get; set; }
    /// <summary>
    /// 密码重试次数
    /// </summary>
    public int RetryCount { get; set; }
    public Status Status { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    /// <summary>
    /// 头像url
    /// </summary>
    [MaxLength(200)]
    public string? Avatar { get; set; }
    public UserInfo? Extend { get; set; }

}
