namespace Infrastructure.Data.Models;

public class ThirdNews : BaseDB
{
    private string? _description;
    private string? _content;
    private string? _title;
    private string? _url;
    private string? _provider;
    private string? _category;
    [MaxLength(100)]
    public string? AuthorName { get; set; }
    [MaxLength(300)]
    public string? AuthorAvatar { get; set; }

    [MaxLength(200)]
    public string? Title {
        get => _title;
        set => _title = value != null && value.Length > 200 ? value.Substring(0, 200) : value;
    }
    [MaxLength(5000)]
    public string? Description {
        get => _description;
        set => _description = value != null && value.Length > 5000 ? value.Substring(0, 5000) : value;
    }
    [MaxLength(300)]
    public string? Url {
        get => _url;
        set => _url = value != null && value.Length > 300 ? value.Substring(0, 300) : value;
    }
    [MaxLength(300)]
    public string? ThumbnailUrl { get; set; }
    [MaxLength(50)]
    public string? Provider {
        get => _provider;
        set => _provider = value != null && value.Length > 50 ? value.Substring(0, 50) : value;
    }
    public DateTimeOffset? DatePublished { get; set; }
    [MaxLength(8000)]
    public string? Content {
        get => _content;
        set => _content = value != null && value.Length > 8000 ? value.Substring(0, 8000) : value;
    }
    [MaxLength(50)]
    public string? Category {
        get => _category;
        set => _category = value != null && value.Length > 50 ? value.Substring(0, 50) : value;
    }
    [MaxLength(50)]
    public string? IdentityId { get; set; }
    public NewsSource Type { get; set; } = NewsSource.News;
    public NewsType NewsType { get; set; } = NewsType.Default;

}
public enum NewsSource
{
    News,
    Tweet,
    Weibo,
    Rss
}

public enum NewsType
{
    Default,
    /// <summary>
    /// 大公司
    /// </summary>
    Company,
    /// <summary>
    /// 开源
    /// </summary>
    OpenSource,
    /// <summary>
    /// 语言及框架
    /// </summary>
    LanguageAndFramework,
    /// <summary>
    /// 数据和AI
    /// </summary>
    DataAndAI,
    Else
}
