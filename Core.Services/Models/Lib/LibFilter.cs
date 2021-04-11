using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Services.Models;
using GT.Agreement.Models;
using Core.Entity;
namespace Core.Services.Models
{
    public class LibFilter : FilterBase
    {
        public Guid? UserId { get; set; }
        public Guid? CatalogId { get; set; }
    
    }
}