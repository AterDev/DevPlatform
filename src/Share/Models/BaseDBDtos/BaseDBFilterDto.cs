namespace Share.Models.BaseDBDtos;
/// <summary>
/// 数据加基础字段模型
/// </summary>
/// <inheritdoc/>
public class BaseDBFilter : FilterBase
{
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }

}
