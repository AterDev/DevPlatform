namespace Share.Models.ArticleDtos;

public class ArticleFilter : FilterBase
{
    public Guid? AccountId { get; set; }
    public Guid? CatalogId { get; set; }

}
