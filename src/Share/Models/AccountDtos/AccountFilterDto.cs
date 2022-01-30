namespace Share.Models.AccountDtos;
/// <summary>
/// 账号表
/// </summary>
public class AccountFilter : FilterBase
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public bool? EmailConfirmed { get; set; }
    /// <summary>
    /// A random value that must change whenever a user is persisted to the store
    /// </summary>
    public string? ConcurrencyStamp { get; set; }
    public bool? PhoneNumberConfirmed { get; set; }
    public bool? TwoFactorEnabled { get; set; }
    public bool? LockoutEnabled { get; set; }
    public int? AccessFailedCount { get; set; }
    /// <summary>
    /// 软删除
    /// </summary>
    public bool? IsDeleted { get; set; }
    /// <summary>
    /// 密码重试次数
    /// </summary>
    public int? RetryCount { get; set; }
    public Status? Status { get; set; }
    public Guid? ExtendId { get; set; }
    
}
