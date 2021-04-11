using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Services.Models;
using GT.Agreement.Models;
using Core.Entity;
namespace Core.Services.Models
{
    public class CatalogDto
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
        public short Sort { get; set; }
        public short Level { get; set; }
        public Guid ParentId { get; set; }
        public Catalog Parent { get; set; }

        // public AccountDto Account { get; set; }
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
    
    }
}