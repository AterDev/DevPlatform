using System;
using System.ComponentModel.DataAnnotations;
namespace Share.Models
{

    public class ThirdNewsDetailDto
    {

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(5000)]
        public string Description { get; set; }
        [MaxLength(300)]
        public string Url { get; set; }
        [MaxLength(300)]
        public string ThumbnailUrl { get; set; }
        [MaxLength(50)]
        public string Provider { get; set; }
        public DateTime DatePublished { get; set; }
        [MaxLength(8000)]
        public string Content { get; set; }
        [MaxLength(50)]
        public string Category { get; set; }
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public Status Status { get; set; }
        public DateTimeOffset CreatedTime { get; set; }

        public DateTimeOffset UpdatedTime { get; set; }

    }
}