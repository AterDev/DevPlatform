namespace Share.Models.CommentDtos;
/// 
public class CommentShortDto
{
    public Article Article { get; set; }
    public Account Account { get; set; }
    public Guid Id { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    
}
