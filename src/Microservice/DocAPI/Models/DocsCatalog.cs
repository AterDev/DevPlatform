namespace DocAPI.Models;

/// <summary>
/// 文档目录
/// </summary>
public class DocsCatalog : EntityBase
{
    /// <summary>
    /// 父节点
    /// </summary>
    public DocsCatalog? Parent { get; set; }
    /// <summary>
    /// 子节点
    /// </summary>
    public ICollection<DocsCatalog>? Children { get; set; }
    [MaxLength(20)]
    [MinLength(3)]
    public string Name { get; set; } = default!;
    public int Sort { get; set; }
    /// <summary>
    /// git url
    /// </summary>
    [MaxLength(300)]
    public string? GitUrl { get; set; }
    [MaxLength(60)]
    public string? GitSha { get; set; }
    [MaxLength(20)]
    public string Language { get; set; } = "en";
    public ICollection<Docs>? Docs { get; set; }
}
