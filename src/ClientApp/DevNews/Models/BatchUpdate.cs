using System;
using System.Collections.Generic;

namespace DevNews.Models
{
    public class BatchUpdate<T>
    {
        public List<Guid> Ids { get; set; } 
        public T UpdateDto { get; set; } 
    }
}