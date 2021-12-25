using System.ComponentModel.DataAnnotations;

namespace Share.Models.TagLibraryDtos;

/// <summary>
/// 标签库
/// </summary>

public class NewsTagsAddDto
{
    [MaxLength(40)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(20)]
    public string? Color { get; set; }

}
