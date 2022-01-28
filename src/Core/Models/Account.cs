using Microsoft.AspNetCore.Identity;

namespace Core.Models;

/// <summary>
/// 账号表
/// </summary>
public class Account : IdentityUser<Guid>, IBase
{
    /// <summary>
    /// 最后登录时间
    /// </summary>
    public DateTimeOffset? LastLoginTime { get; set; }
    /// <summary>
    /// 软删除
    /// </summary>
    public bool IsDeleted { get; set; } = false;
    /// <summary>
    /// 密码重试次数
    /// </summary>
    public int RetryCount { get; set; } = 0;
    public virtual Status Status { get; set; } = Status.Default;
    public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.UtcNow;
    /// <summary>
    /// 头像url
    /// </summary>
    [MaxLength(200)]
    public string? Avatar { get; set; }
    public AccountExtend? Extend { get; set; }
    /// <summary>
    /// 文章
    /// </summary>
    public List<Article>? Articles { get; set; }
    /// <summary>
    /// 文章目录
    /// </summary>
    public List<ArticleCatalog>? ArticleCatalogs { get; set; }
    /// <summary>
    /// 评论
    /// </summary>
    public List<Comment>? Comments { get; set; }
}

