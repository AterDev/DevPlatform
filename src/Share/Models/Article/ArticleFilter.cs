namespace Share.Models
{
    public class ArticleFilter : FilterBase
    {
        public Guid? AccountId { get; set; }
        public Guid? CatalogId { get; set; }

    }
}