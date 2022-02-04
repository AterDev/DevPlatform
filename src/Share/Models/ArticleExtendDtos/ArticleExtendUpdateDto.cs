namespace Share.Models.ArticleExtendDtos;
/// <summary>
/// 文章扩展
/// </summary>
public class ArticleExtendUpdateDto
{
    public Guid? ArticleId { get; set; }
    public string? Content { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }

}
