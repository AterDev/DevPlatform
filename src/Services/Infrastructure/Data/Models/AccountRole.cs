namespace Infrastructure.Data.Models;

/// <summary>
/// 用户角色表
/// </summary>
public partial class AccountRole : BaseDB
{
    [ForeignKey("AccountId")]
    public Account? Account { get; set; }
    [ForeignKey("RoleId")]
    public Role? Role { get; set; }
    public Guid AccountId { get; set; }
    public Guid RoleId { get; set; }
}
