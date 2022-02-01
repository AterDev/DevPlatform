namespace Share.Models.AccountInfoDtos;
/// <summary>
/// 账号扩展表, 可用作用户信息
/// </summary>
public class AccountInfoFilter : FilterBase
{
    public Guid? AccountId { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }

}
