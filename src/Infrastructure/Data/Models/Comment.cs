namespace Infrastructure.Data.Models;

public class Comment : BaseDB
{
    public Article? Article { get; set; }
    public Account? Account { get; set; }
    /// <summary>
    /// 评论内容
    /// </summary>
    [MaxLength(2000)]
    public string? Content { get; set; }
}
