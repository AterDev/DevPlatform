using System.ComponentModel.DataAnnotations;

namespace Share.Models.CatalogDtos;

public class CatalogItemDto
{
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(50)]
    public string? Type { get; set; }
    public short Sort { get; set; }
    public short Level { get; set; }
    public Guid ParentId { get; set; }
    public LibraryCatalog? Parent { get; set; }
    [Key]
    public Guid Id { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; }
    public DateTimeOffset CreatedTime { get; set; }

}
