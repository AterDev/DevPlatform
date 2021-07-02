using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Share.Models;
using Entity;
namespace Share.Models
{
    public class ArticleCatalogDetailDto
    {
        /// <summary>
        /// 该目录的文章
        /// </summary>
        public List<Article> Articles { get; set; }
        /// <summary>
        /// 父目录
        /// </summary>
        public ArticleCatalog Parent { get; set; }
        /// <summary>
        /// 所属用户
        /// </summary>
        // public AccountDto Account { get; set; }
        /// <summary>
        /// 子目录
        /// </summary>
        public List<ArticleCatalog> Catalogs { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
        public short Sort { get; set; }
        public short Level { get; set; }
        public Guid ParentId { get; set; }
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