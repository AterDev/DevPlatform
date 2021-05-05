using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entity
{
    /// <summary>
    /// 目录/文件目录 / 自引用
    /// </summary>
    public partial class Catalog : BaseDB
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
        public short Sort { get; set; } = 0;
        public short Level { get; set; }
        public Guid ParentId { get; set; }
        
    }
}
