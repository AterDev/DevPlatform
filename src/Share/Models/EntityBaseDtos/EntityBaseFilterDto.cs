namespace Share.Models.EntityBaseDtos;
/// <summary>
/// 数据加基础字段模型
/// </summary>
/// <inheritdoc/>
public class EntityBaseFilter : FilterBase
{
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    
}
