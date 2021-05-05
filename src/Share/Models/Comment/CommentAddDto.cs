using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Share.Models;
using Core.Entity;
namespace Share.Models
{
    public class CommentAddDto
    {
        /// <summary>
        /// 评论内容
        /// </summary>
        [MaxLength(2000)]
        public string Content { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public Status Status { get; set; }
        public DateTimeOffset UpdatedTime { get; set; }
        public Guid? ArticleId { get; set; }
        public Guid? AccountId { get; set; }
    
    }
}