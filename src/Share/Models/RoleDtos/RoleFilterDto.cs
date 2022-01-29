namespace Share.Models.RoleDtos;
/// <summary>
/// 角色表
/// </summary>
public class RoleFilter : FilterBase
{
    public string? Name { get; set; }
    public string? ConcurrencyStamp { get; set; }
    public Guid? StatusId { get; set; }
    
}
