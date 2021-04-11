using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Services.Models;
using GT.Agreement.Models;
using Core.Entity;
namespace Core.Services.Models
{
    public class CatalogFilter : FilterBase
    {
        public Guid? AccountId { get; set; }
    
    }
}