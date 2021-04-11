using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entity
{
    /// <summary>
    /// 模型库
    /// </summary>
    public class Lib : EntityBase
    {
        /// <summary>
        /// 库命名空间
        /// </summary>
        [MaxLength(100)]
        public string Namespace { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(500)]
        public string Description { get; set; }
        /// <summary>
        /// 语言类型
        /// </summary>
        [MaxLength(100)]
        public string Language { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid { get; set; }
        public Account User { get; set; }
        public Catalog Catalog { get; set; }
        public List<Entity> Entities { get; set; }
    }
}
