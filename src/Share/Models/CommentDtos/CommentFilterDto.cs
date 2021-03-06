namespace Share.Models.CommentDtos;

public class CommentFilter : FilterBase
{
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    public Guid? ArticleId { get; set; } = default!;
    public Guid? AccountId { get; set; } = default!;

}
