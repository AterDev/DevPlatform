using System.ComponentModel.DataAnnotations;

namespace Share.Models.CommonDtos;

/// <summary>
/// 登录模型
/// </summary>
public class SignInForm
{
    /// <summary>
    /// 用户名/手机号/邮箱
    /// </summary>
    [Required]
    [MinLength(4)]
    [MaxLength(50)]
    [Display(Name = "用户名")]
    public string Username { get; set; }
    [Required]
    [MinLength(6)]
    [MaxLength(50)]
    [Display(Name = "密码")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    /// <summary>
    /// 验证码
    /// </summary>
    [Required]
    [Display(Name = "验证码")]
    public string Captcha { get; set; } = "0000";
}
