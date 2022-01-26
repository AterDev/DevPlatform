namespace Share.Models.AccountDtos;
/// <summary>
/// 账号表
/// </summary>
public class AccountUpdateDto
{
    /// <summary>
    /// 邮箱
    /// </summary>
    [MaxLength(120)]
    public string? Email { get; set; }
    /// <summary>
    ///  密码
    /// </summary>
    // [MaxLength(60)]
    // public string? Password { get; set; }
    /// <summary>
    /// 用户名
    /// </summary>
    [MaxLength(100)]
    public string? Username { get; set; }
    /// <summary>
    /// 密码加盐
    /// </summary>
    [MaxLength(40)]
    public string? HashSalt { get; set; }
    /// <summary>
    /// 最后登录时间
    /// </summary>
    public DateTimeOffset? LastLoginTime { get; set; }
    /// <summary>
    /// 软删除
    /// </summary>
    public bool? IsDeleted { get; set; }
    /// <summary>
    /// 密码重试次数
    /// </summary>
    public int? RetryCount { get; set; }
    [MaxLength(16)]
    public string? Phone { get; set; }
    public bool? PhoneConfirm { get; set; }
    public bool? EmailConfirm { get; set; }
    /// <summary>
    /// 头像url
    /// </summary>
    [MaxLength(200)]
    public string? Avatar { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    
}
