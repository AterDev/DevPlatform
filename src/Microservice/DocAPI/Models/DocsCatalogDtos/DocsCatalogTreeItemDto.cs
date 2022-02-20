namespace DocAPI.Models.DocsCatalogDtos;

public class DocsCatalogTreeItemDto
{
    [MaxLength(20)]
    [MinLength(3)]
    public string Name { get; set; } = default!;
    public int Sort { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    public ICollection<DocsCatalogTreeItemDto>? Children { get; set; }
    public Guid? ParentId { get; set; }
    /// <summary>
    /// 是否为文档节点
    /// </summary>
    public bool IsDoc { get; set; } = false;
}
