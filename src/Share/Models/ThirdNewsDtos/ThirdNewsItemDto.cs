namespace Share.Models.ThirdNewsDtos;

public class ThirdNewsItemDto
{
    [MaxLength(100)]
    public string? AuthorName { get; set; }
    [MaxLength(300)]
    public string? AuthorAvatar { get; set; }

    [MaxLength(200)]
    public string Title { get; set; } = default!;
    [MaxLength(300)]
    public string? Url { get; set; }
    [MaxLength(300)]
    public string? ThumbnailUrl { get; set; }
    [MaxLength(50)]
    public string? Provider { get; set; }
    public DateTimeOffset? DatePublished { get; set; }
    [MaxLength(50)]
    public string? Category { get; set; }
    [MaxLength(50)]
    public string? IdentityId { get; set; }
    public NewsSource Type { get; set; } = default!;
    public NewsType NewsType { get; set; } = default!;
    public TechType TechType { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;

}
