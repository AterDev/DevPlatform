using GT.Agreement.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    /// <summary>
    /// 数据加基础字段模型
    /// </summary>
    public class BaseDB : EntityBase<Guid>
    {
        [Key]
        [Column(TypeName ="char(36)")]
        public override Guid Id { get; set; } = Guid.NewGuid();
        [Column(TypeName = "datetime")]
        public override DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
        [Column(TypeName = "datetime")]
        public override DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.UtcNow;
    }

}
