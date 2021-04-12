using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Services.Models
{
    /// <summary>
    /// 修改密码
    /// </summary>
    public class ChangePasswordDto
    {
        public Guid? Id { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
