namespace Share.Models.RoleDtos;
/// <summary>
/// 角色表
/// </summary>
public class RoleItemDto
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? NormalizedName { get; set; }
    public string ConcurrencyStamp { get; set; } = default!;
    /// <summary>
    /// 图标
    /// </summary>
    [MaxLength(30)]
    public string? Icon { get; set; }
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    
}
