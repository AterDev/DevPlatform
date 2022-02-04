namespace Share.Models.ArticleCatalogDtos;

public class ArticleCatalogUpdateDto
{
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(50)]
    public string? Type { get; set; }
    public short? Sort { get; set; }
    public short? Level { get; set; }
    public Guid? ParentId { get; set; }
    public Guid? AccountId { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    
}
