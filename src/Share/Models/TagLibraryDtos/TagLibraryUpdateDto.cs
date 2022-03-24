namespace Share.Models.TagLibraryDtos;
/// <summary>
/// 标签库
/// </summary>
public class TagLibraryUpdateDto
{
    [MaxLength(40)]
    public string? Type { get; set; }
    [MaxLength(40)]
    public string? Name { get; set; }
    [MaxLength(20)]
    public string? Color { get; set; }
    [MaxLength(40)]
    public string? Style { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }

}
