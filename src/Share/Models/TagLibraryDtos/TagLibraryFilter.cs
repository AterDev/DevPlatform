namespace Share.Models.TagLibraryDtos;

/// <summary>
/// 标签库
/// </summary>

public class TagLibraryFilter : FilterBase
{
    /// <summary>
    /// 类型
    /// </summary>
    public string? Type { get; set; }
    public string? Name { get; set; }
}
