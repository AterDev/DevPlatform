namespace Share.Models.NewsTagsDtos;

public class NewsTagsUpdateDto
{
    [MaxLength(40)]
    public string? Name { get; set; }
    [MaxLength(20)]
    public string? Color { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    public Guid? ThirdNewsId { get; set; }
    
}
