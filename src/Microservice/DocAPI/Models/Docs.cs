namespace DocAPI.Models;

/// <summary>
/// 文档
/// </summary>
public class Docs : EntityBase
{
    [MaxLength(100)]
    [MinLength(3)]
    public string Name { get; set; } = default!;
    [MaxLength(10000)]
    public string? Content { get; set; }
    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; set; } = 1;
    /// <summary>
    /// git url
    /// </summary>
    [MaxLength(300)]
    public string? GitUrl { get; set; }
    [MaxLength(60)]
    public string? GitSha { get; set; }
    [MaxLength(20)]
    public string Language { get; set; } = "en";
    public DocsCatalog DocsCatalog { get; set; } = default!;
}
