using System.ComponentModel.DataAnnotations;

namespace Share.Models.AccountDtos;

public class AccountAddDto
{
    /// <summary>
    /// 邮箱
    /// </summary>
    [MaxLength(120)]
    public string? Email { get; set; }
    /// <summary>
    ///  密码
    /// </summary>
    [MaxLength(60)]
    public string? Password { get; set; }
    /// <summary>
    /// 用户名
    /// </summary>
    [MaxLength(100)]
    public string? Username { get; set; }
    [MaxLength(16)]
    public string? Phone { get; set; }
}
