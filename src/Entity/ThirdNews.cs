namespace Entity
{
    public class ThirdNews : BaseDB
    {
        private string _description;
        private string _content;

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(5000)]
        public string Description
        {
            get => _description;
            set
            {
                if (value.Length > 5000)
                {
                    _description = value.Substring(0, 5000);
                }
            }
        }
        [MaxLength(200)]
        public string Url { get; set; }
        [MaxLength(300)]
        public string ThumbnailUrl { get; set; }
        [MaxLength(30)]
        public string Provider { get; set; }
        public DateTime DatePublished { get; set; }
        [MaxLength(8000)]
        public string Content
        {
            get => _content;
            set
            {
                if (value.Length > 8000)
                {
                    _content = value.Substring(0, 8000);
                }
            }
        }
        [MaxLength(40)]
        public string Category { get; set; }
    }
}
