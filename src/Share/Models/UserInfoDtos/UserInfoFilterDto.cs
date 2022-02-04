namespace Share.Models.UserInfoDtos;
/// <summary>
/// 账号扩展表, 可用作用户信息
/// </summary>
public class UserInfoFilter : FilterBase
{
    public Guid? AccountId { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }

}
