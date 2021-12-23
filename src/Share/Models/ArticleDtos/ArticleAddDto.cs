using System.ComponentModel.DataAnnotations;

namespace Share.Models.ArticleDtos;

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
    /// 标签
    /// </summary>
    [MaxLength(100)]
    public string Tags { get; set; }
    /// <summary>
    /// 文章类别
    /// </summary>
    public ArticleType ArticleType { get; set; }
    /// <summary>
    /// 文章内容
    /// </summary>
    public string Content { get; set; }

    public Guid? AccountId { get; set; }
    public Guid? CatalogId { get; set; }

}
