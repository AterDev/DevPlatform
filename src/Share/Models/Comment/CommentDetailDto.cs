using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Share.Models;
using Entity;
namespace Share.Models
{
    public class CommentDetailDto
    {
        // public ArticleDto Article { get; set; }
        // public AccountDto Account { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        [MaxLength(2000)]
        public string Content { get; set; }
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