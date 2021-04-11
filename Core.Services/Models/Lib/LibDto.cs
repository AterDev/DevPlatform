using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Services.Models;
using GT.Agreement.Models;
using Core.Entity;
namespace Core.Services.Models
{
    public class LibDto
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
        // public AccountDto User { get; set; }
        // public CatalogDto Catalog { get; set; }
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
    
    }
}