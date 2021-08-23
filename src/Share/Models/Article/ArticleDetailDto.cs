using System.ComponentModel.DataAnnotations;
namespace Share.Models
{
    public class ArticleDetailDto
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


        // public AccountDto Account { get; set; }
        /// <summary>
        /// 文章扩展内容
        /// </summary>
        // public ArticleExtendDto Extend { get; set; }
        /// <summary>
        /// 所属目录
        /// </summary>
        // public ArticleCatalogDto Catalog { get; set; }
        /// <summary>
        /// 评论
        /// </summary>
        public List<Comment> Comments { get; set; }
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