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

    public LanguageType Language { get; set; } = LanguageType.EN;
    public DocsCatalog DocsCatalog { get; set; } = default!;
}
