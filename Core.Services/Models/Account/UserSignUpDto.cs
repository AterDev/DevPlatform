using System.ComponentModel.DataAnnotations;

namespace Core.Services.Models
{
    /// <summary>
    /// 管理登录dto
    /// </summary>
    public class UserSignUpDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Username { get; set; }
        [Required]
        [MaxLength(60)]
        public string Password { get; set; }
    }
}
