namespace Share.Models.CodeSnippetDtos;
/// <summary>
/// 代码片段
/// </summary>
public class CodeSnippetShortDto
{
    /// <summary>
    /// 实体名称
    /// </summary>
    [MaxLength(100)]
    public string Name { get; set; }
    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }
    /// <summary>
    /// 所属类库
    /// </summary>
    public Library? Library { get; set; }
    /// <summary>
    /// 语言类型
    /// </summary>
    public Language Language { get; set; }
    /// <summary>
    /// 类型
    /// </summary>
    public CodeType CodeType { get; set; }
    public Guid Id { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    
}
