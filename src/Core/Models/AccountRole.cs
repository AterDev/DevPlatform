namespace Core.Models;

/// <summary>
/// 用户角色表
/// </summary>
public partial class AccountRole : BaseDB
{
    public Account Account { get; set; } = null!;
    public Role Role { get; set; } = null!;
}
