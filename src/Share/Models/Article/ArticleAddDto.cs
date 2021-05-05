using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Share.Models;
using Core.Entity;
namespace Share.Models
{
    public class ArticleAddDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        [MaxLength(100)]
        public string Title { get; set; }
        /// <summary>
        /// 概要
        /// </summary>
        [MaxLength(500)]
        public string Summary { get; set; }
        /// <summary>
        /// 作者名称
        /// </summary>
        [MaxLength(100)]
        public string AuthorName { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        [MaxLength(100)]
        public string Tags { get; set; }
        /// <summary>
        /// 文章类别
        /// </summary>
        public ArticleType ArticleType { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public Status Status { get; set; }
        public DateTimeOffset UpdatedTime { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? ExtendId { get; set; }
        public Guid? CatalogId { get; set; }
    
    }
}