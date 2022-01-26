namespace Core.Models;

public class Comment : BaseDB
{
    public Article Article { get; set; } = null!;
    public Account Account { get; set; } = null!;
    /// <summary>
    /// 评论内容
    /// </summary>
    [MaxLength(2000)]
    public string? Content { get; set; }
}
