using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DevNews.Models
{
    public class NewsTags
    {
        public Guid Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Color { get; set; }
        [JsonIgnore]
        public ThirdNews ThirdNews { get; set; }

    }
}