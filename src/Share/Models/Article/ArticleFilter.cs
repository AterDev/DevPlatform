using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Share.Models;
using Entity;
namespace Share.Models
{
    public class ArticleFilter : FilterBase
    {
        public Guid? AccountId { get; set; }
        public Guid? CatalogId { get; set; }
    
    }
}