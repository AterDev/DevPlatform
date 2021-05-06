using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    /// <summary>
    /// 目录/文件目录 / 自引用
    /// </summary>
    public partial class LibraryCatalog : BaseDB
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
        public short Sort { get; set; } = 0;
        public short Level { get; set; }
        [ForeignKey("ParentId")]
        public LibraryCatalog Parent { get; set; }
        public Guid? ParentId { get; set; }
        /// <summary>
        /// 所属用户
        /// </summary>
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        public Guid AccountId { get; set; }
        /// <summary>
        /// 子目录
        /// </summary>
        public List<LibraryCatalog> Catalogs { get; set; }
    }
}
