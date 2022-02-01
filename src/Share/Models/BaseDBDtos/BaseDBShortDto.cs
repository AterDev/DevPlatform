namespace Share.Models.BaseDBDtos;
/// <summary>
/// 数据加基础字段模型
/// </summary>
/// <inheritdoc/>
public class BaseDBShortDto
{
    public Guid Id { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }

}
