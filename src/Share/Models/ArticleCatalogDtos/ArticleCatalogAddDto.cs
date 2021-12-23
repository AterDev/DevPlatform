using System.ComponentModel.DataAnnotations;

namespace Share.Models.ArticleCatalogDtos;

public class ArticleCatalogAddDto
{
    /// <summary>
    /// 父目录
    /// </summary>
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(50)]
    public string Type { get; set; }
    public short Sort { get; set; } = 0;
    /// <summary>
    /// 可忽略
    /// </summary>
    public short Level { get; set; }
    public Guid? ParentId { get; set; }
    /// <summary>
    /// 可忽略
    /// </summary>
    public Guid AccountId { get; set; }
}
