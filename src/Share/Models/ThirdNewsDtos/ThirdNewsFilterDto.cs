namespace Share.Models.ThirdNewsDtos;
/// 
public class ThirdNewsFilter : FilterBase
{

    [MaxLength(200)]
    public string? Title { get; set; }
    public NewsSource? Type { get; set; }
    public NewsType? NewsType { get; set; }
    public TechType? TechType { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }

}
