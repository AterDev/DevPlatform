using System;

namespace Entity
{
    public class Rss
    {
        public string Categories { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public string Link { get; set; }
        public string Author { get; set; }
        public int PublishId { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ThumbUrl { get; set; }
    }
}