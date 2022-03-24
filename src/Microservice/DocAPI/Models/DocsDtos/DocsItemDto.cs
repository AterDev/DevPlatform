namespace DocAPI.Models.DocsDtos;
/// <summary>
/// 文档
/// </summary>
public class DocsItemDto
{
    [MaxLength(100)]
    [MinLength(3)]
    public string Name { get; set; } = default!;
    public Guid Id { get; set; }
}
