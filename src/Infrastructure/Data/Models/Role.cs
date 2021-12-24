namespace Infrastructure.Data.Models;

/// <summary>
/// 角色表
/// </summary>
public class Role : BaseDB
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

}
