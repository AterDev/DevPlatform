namespace Core.Models;

[Table("ArticleCatalog")]
public class ArticleCatalog : BaseDB
{
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(50)]
    public string? Type { get; set; }
    public short Sort { get; set; } = 0;
    public short Level { get; set; }

    /// <summary>
    /// 该目录的文章
    /// </summary>
    public List<Article>? Articles { get; set; }
    /// <summary>
    /// 父目录
    /// </summary>
    [ForeignKey("ParentId")]
    public ArticleCatalog? Parent { get; set; }
    public Guid? ParentId { get; set; }
    /// <summary>
    /// 所属用户
    /// </summary>
    [ForeignKey("AccountId")]
    public Account? Account { get; set; }
    public Guid AccountId { get; set; }
    /// <summary>
    /// 子目录
    /// </summary>
    public List<ArticleCatalog>? Catalogs { get; set; }

}
