using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Share.Models;
using Core.Entity;
namespace Share.Models
{
    public class CatalogFilter : FilterBase
    {
        public Guid? AccountId { get; set; }
    
    }
}