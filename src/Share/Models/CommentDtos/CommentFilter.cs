namespace Share.Models.CommentDtos;

public class CommentFilter : FilterBase
{
    public Guid? ArticleId { get; set; }
    public Guid? AccountId { get; set; }

}
