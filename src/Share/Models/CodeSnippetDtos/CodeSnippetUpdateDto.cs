namespace Share.Models.CodeSnippetDtos;
/// <summary>
/// 代码片段
/// </summary>
public class CodeSnippetUpdateDto
{
    /// <summary>
    /// 实体名称
    /// </summary>
    [MaxLength(100)]
    public string? Name { get; set; }
    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }
    /// <summary>
    /// 实体定义内容
    /// </summary>
    [MaxLength(4000)]
    public string? Content { get; set; }
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

}
