using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Share.Models;
using Core.Entity;
namespace Share.Models
{
    public class CatalogAddDto
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
        public short Sort { get; set; }
        public short Level { get; set; }
        public Guid ParentId { get; set; }
        public LibraryCatalog Parent { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public Status Status { get; set; }
        public DateTimeOffset UpdatedTime { get; set; }
        public Guid? AccountId { get; set; }
    
    }
}