using System.ComponentModel.DataAnnotations;

namespace Share.Models.TagLibraryDtos;

///<summary>
/// 标签库
/// </summary>

public class TagLibraryDetailDto
{
    [MaxLength(40)]
    public string? Type { get; set; }
    [MaxLength(40)]
    public string? Name { get; set; }
    [MaxLength(20)]
    public string? Color { get; set; }
    [MaxLength(40)]
    public string? Style { get; set; }

}
