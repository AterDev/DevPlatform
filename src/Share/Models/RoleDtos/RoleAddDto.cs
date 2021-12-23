using System.ComponentModel.DataAnnotations;

namespace Share.Models.RoleDtos;

public class RoleAddDto
{
    /// <summary>
    /// 角色名称
    /// </summary>
    [MaxLength(50)]
    public string Name { get; set; }
    /// <summary>
    /// 图标
    /// </summary>
    [MaxLength(30)]
    public string Icon { get; set; }
}
