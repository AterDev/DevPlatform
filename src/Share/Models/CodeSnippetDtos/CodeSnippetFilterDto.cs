namespace Share.Models.CodeSnippetDtos;
/// <summary>
/// 代码片段
/// </summary>
public class CodeSnippetFilter : FilterBase
{
    /// <summary>
    /// 实体名称
    /// </summary>
    [MaxLength(100)]
    public string? Name { get; set; }
    /// <summary>
    /// 语言类型
    /// </summary>
    public Language? Language { get; set; }
    /// <summary>
    /// 类型
    /// </summary>
    public CodeType? CodeType { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    public Guid? LibraryId { get; set; } = default!;

}
