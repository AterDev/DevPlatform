namespace Share.Models.RoleDtos;
/// <summary>
/// 角色表
/// </summary>
public class RoleFilter : FilterBase
{
    /// <summary>
    /// 角色名称
    /// </summary>
    [MaxLength(50)]
    public string? Name { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    
}
