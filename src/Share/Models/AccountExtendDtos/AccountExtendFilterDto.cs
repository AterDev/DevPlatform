namespace Share.Models.AccountExtendDtos;
/// <summary>
/// 账号扩展表
/// </summary>
public class AccountExtendFilter : FilterBase
{
    public Guid? AccountId { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    
}
