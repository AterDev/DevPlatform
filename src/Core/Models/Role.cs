using Microsoft.AspNetCore.Identity;

namespace Core.Models;

/// <summary>
/// 角色表
/// </summary>
public class Role : IdentityRole<Guid>
{
    /// <summary>
    /// 图标
    /// </summary>
    [MaxLength(30)]
    public string? Icon { get; set; }
    public virtual Status Status { get; set; } = Status.Default;
    public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.UtcNow;
}
