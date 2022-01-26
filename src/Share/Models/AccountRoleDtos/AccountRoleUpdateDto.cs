namespace Share.Models.AccountRoleDtos;
/// <summary>
/// 用户角色表
/// </summary>
public class AccountRoleUpdateDto
{
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    public Guid? AccountId { get; set; }
    public Guid? RoleId { get; set; }
    
}
