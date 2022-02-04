namespace Share.Models.EntityBaseDtos;
/// <summary>
/// 数据加基础字段模型
/// </summary>
/// <inheritdoc/>
public class EntityBaseItemDto
{
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    
}
