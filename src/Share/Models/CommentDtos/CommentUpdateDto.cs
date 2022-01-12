using System.ComponentModel.DataAnnotations;

namespace Share.Models.CommentDtos;

public class CommentUpdateDto
{
    /// <summary>
    /// 评论内容
    /// </summary>
    [MaxLength(2000)]
    public string? Content { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }

}
