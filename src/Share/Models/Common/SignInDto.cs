using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Models.Common
{
    public class SignInDto
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(120)]
        public string Email { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(100)]
        public string Username { get; set; }
        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 密码重试次数
        /// </summary>
        public int RetryCount { get; set; }
        [MaxLength(16)]
        public string Phone { get; set; }
        
        /// <summary>
        /// 头像url
        /// </summary>
        [MaxLength(200)]
        public string Avatar { get; set; }
        // public AccountExtendDto Extend { get; set; }
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public Status Status { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset UpdatedTime { get; set; }
        public string Token { get; set; }
        public string RoleName { get; set; }
    }
}
