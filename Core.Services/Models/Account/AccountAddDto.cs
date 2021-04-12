using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Services.Models;
using GT.Agreement.Models;
using Core.Entity;
using GT.Agreement.Entity;

namespace Core.Services.Models
{
    public class AccountAddDto
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(120)]
        public string Email { get; set; }
        /// <summary>
        ///  密码
        /// </summary>
        [MaxLength(60)]
        public string Password { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(100)]
        public string Username { get; set; }


        [MaxLength(16)]
        public string Phone { get; set; }
        /// <summary>
        /// 头像url
        /// </summary>
        [MaxLength(200)]
        public string Avatar { get; set; }
    
    }
}