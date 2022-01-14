namespace Share.Models.NewsTagsDtos;

public class NewsTagsFilter : FilterBase
{
    public string? Name { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; }
    public Guid? ThirdNewsId { get; set; }

}
