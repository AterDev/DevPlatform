namespace Entity
{
    public class BingNews
    {
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(200)]
        public string Url { get; set; }
        [MaxLength(300)]
        public string ThumbnailUrl { get; set; }
        [MaxLength(30)]
        public string Provider { get; set; }
        public DateTime DatePublished { get; set; }
        [MaxLength(40)]
        public string Category { get; set; }
    }
}
