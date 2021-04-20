using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Share.Models;
using Core.Entity;
namespace Share.Models
{
    public class AccountDto
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
        public bool PhoneConfirm { get; set; }
        public bool EmailConfirm { get; set; }
        /// <summary>
        /// 头像url
        /// </summary>
        [MaxLength(200)]
        public string Avatar { get; set; }
        public List<Role> Roles { get; set; }
        // public AccountExtendDto Extend { get; set; }
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public Status Status { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset UpdatedTime { get; set; }
    }
}