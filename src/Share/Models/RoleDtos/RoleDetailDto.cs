using System.ComponentModel.DataAnnotations;

namespace Share.Models.RoleDtos;

public class RoleDetailDto
{
    /// <summary>
    /// 角色名称
    /// </summary>
    [MaxLength(50)]
    public string? Name { get; set; }
    /// <summary>
    /// 图标
    /// </summary>
    [MaxLength(30)]
    public string? Icon { get; set; }

    /// <summary>
    /// 多对多关联账号
    /// </summary>
    public List<Account>? Accounts { get; set; }
    [Key]
    public Guid Id { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }

}
