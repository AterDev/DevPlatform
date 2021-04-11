using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entity
{
    /// <summary>
    /// 数据加基础字段模型
    /// </summary>
    public class EntityBase
    {
        public virtual DateTimeOffset? UpdatedTime { get; set; } = DateTimeOffset.Now;
        public virtual Status Status { get; set; } = Status.Default;
        [Key]
        public virtual Guid Id { get; set; }
        public virtual DateTimeOffset? CreatedTime { get; set; }
    }

    /// <summary>
    /// 状态
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// 默认值 
        /// </summary>
        Default,
        /// <summary>
        /// 已删除
        /// </summary>
        Deleted,
        /// <summary>
        /// 无效
        /// </summary>
        Invalid,
        Valid
    }
}
