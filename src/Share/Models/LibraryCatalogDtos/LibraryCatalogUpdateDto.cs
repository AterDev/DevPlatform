using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Share.Models.LibraryCatalogDtos;

public class LibraryCatalogUpdateDto
{
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(50)]
    public string? Type { get; set; }
    public short Sort { get; set; }
    public short Level { get; set; }
    [ForeignKey("ParentId")]
    public LibraryCatalog? Parent { get; set; }
    public Guid AccountId { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }

}
