namespace Share.Models
{
    public class CommentFilter : FilterBase
    {
        public Guid? ArticleId { get; set; }
        public Guid? AccountId { get; set; }

    }
}