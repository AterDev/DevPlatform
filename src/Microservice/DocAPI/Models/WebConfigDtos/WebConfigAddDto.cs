namespace DocAPI.Models.WebConfigDtos;

public class WebConfigAddDto
{
    public Guid? Id { get; set; }
    /// <summary>
    /// 网站名称
    /// </summary>
    [MaxLength(60)]
    public string? WebSiteName { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    /// <summary>
    /// github 用户名
    /// </summary>
    [MaxLength(100)]
    public string? GithubUser { get; set; }
    /// <summary>
    /// github PAT
    /// </summary>
    [MaxLength(100)]
    public string? GithubPAT { get; set; }
    /// <summary>
    /// 同步的仓库id
    /// </summary>
    public long? RepositoryId { get; set; } = default!;
    /// <summary>
    /// 密钥
    /// </summary>
    public string? WebhookSecret { get; set; }
}
