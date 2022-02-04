namespace Share.Models.ThirdNewsDtos;

public class ThirdNewsUpdateDto
{
    [MaxLength(100)]
    public string? AuthorName { get; set; }
    [MaxLength(300)]
    public string? AuthorAvatar { get; set; }

    [MaxLength(200)]
    public string? Title { get; set; }
    [MaxLength(5000)]
    public string? Description { get; set; }
    [MaxLength(300)]
    public string? Url { get; set; }
    [MaxLength(300)]
    public string? ThumbnailUrl { get; set; }
    [MaxLength(50)]
    public string? Provider { get; set; }
    public DateTimeOffset? DatePublished { get; set; }
    [MaxLength(8000)]
    public string? Content { get; set; }
    [MaxLength(50)]
    public string? Category { get; set; }
    [MaxLength(50)]
    public string? IdentityId { get; set; }
    public NewsSource? Type { get; set; }
    public NewsType? NewsType { get; set; }
    public TechType? TechType { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    
}
