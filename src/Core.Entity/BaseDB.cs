using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    /// <summary>
    /// 数据加基础字段模型
    /// </summary>
    public class BaseDB
    {
        [Key]
        [Column(TypeName = "char(36)")]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 状态
        /// </summary>
        public virtual Status Status { get; set; } = Status.Default;
        [Column(TypeName = "datetime")]
        public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
        [Column(TypeName = "datetime")]
        public DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.UtcNow;
    }

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
