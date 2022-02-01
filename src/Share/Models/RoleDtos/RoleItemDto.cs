namespace Share.Models.RoleDtos;
/// <summary>
/// 角色表
/// </summary>
public class RoleItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? NormalizedName { get; set; }
    public string ConcurrencyStamp { get; set; }
    /// <summary>
    /// 图标
    /// </summary>
    [MaxLength(30)]
    public string? Icon { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }

}
