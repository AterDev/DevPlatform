namespace Share.Models.AccountRoleDtos;
/// <summary>
/// 用户角色表
/// </summary>
public class AccountRoleItemDto
{
    public Guid Id { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    
}
