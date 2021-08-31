namespace Entity
{
    public class ThirdNews : BaseDB
    {
        private string _description;
        private string _content;
        private string _title;
        private string _url;
        private string _provider;
        private string _category;

        [MaxLength(200)]
        public string Title
        {
            get => _title;
            set
            {
                if (value.Length > 200)
                {
                    _title = value.Substring(0, 200);
                }
                else
                {
                    _title = value;
                }
            }
        }

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
                else
                {
                    _description = value;
                }
            }
        }
        [MaxLength(300)]
        public string Url
        {
            get => _url;
            set
            {
                if (value.Length > 300)
                {
                    _url = value.Substring(0, 300);
                }
                else
                {
                    _url = value;
                }
            }
        }
        [MaxLength(300)]
        public string ThumbnailUrl { get; set; }
        [MaxLength(50)]
        public string Provider {
            get => _provider;
            set
            {
                if (value.Length > 300)
                {
                    _provider = value.Substring(0, 50);
                }
                else
                {
                    _provider = value;
                }
            }
        }
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
                else
                {
                    _content = value;
                }
            }
        }
        [MaxLength(50)]
        public string Category {
            get => _category;
            set
            {
                if (value.Length > 50)
                {
                    _category = value.Substring(0, 50);
                }
                else
                {
                    _category = value;
                }
            }
        }
    }
}
