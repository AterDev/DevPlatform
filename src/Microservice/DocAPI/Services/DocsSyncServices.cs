using Octokit;

namespace DocAPI.Services;
/// <summary>
/// 文档同步，从github仓库同步
/// </summary>
public class DocsSyncServices
{
    private readonly DocsContext _context;
    public GitHubClient Client { get; set; }
    private readonly ApiOptions _options;
    private Octokit.User? User { get; set; }

    public DocsSyncServices(DocsContext context)
    {
        _context = context;
        Client = new GitHubClient(new ProductHeaderValue("ater.docs"));
        _options = new ApiOptions()
        {
            PageSize = 100,
        };
    }

    /// <summary>
    /// 设置person access token
    /// </summary>
    /// <param name="pat"></param>
    public async Task SetPATAsync(string pat)
    {
        Client.Credentials = new Credentials(pat);
        User = await Client.User.Current();
    }

    /// <summary>
    /// 获取仓库列表
    /// </summary>
    /// <returns></returns>
    public async Task<IReadOnlyList<Repository>> GetPublicRepositories()
    {
        //var orgs = await Client.Organization.GetAllForCurrent();
        return await Client.Repository.GetAllForCurrent();
    }

    /// <summary>
    /// 同步
    /// <param name="repositoryId">仓库id</param>
    /// </summary>
    public async Task SyncDocsAsync(long? repositoryId)
    {
        if (repositoryId == null)
        {
            repositoryId = _context.WebConfigs.Select(c => c.RepositoryId).FirstOrDefault();
        }
        if (repositoryId != null)
        {
            // 1 获取语言目录
            var languageDirs = await GetRepositoryRootAsync(repositoryId.Value);
            foreach (var lang in languageDirs)
            {
                var contents = await GetFilesAsync(repositoryId.Value, lang.Path);
                await CreateDocsRecursionAsync(repositoryId.Value, contents, lang.Name, null);
            }
        }
    }

    /// <summary>
    /// 递归处理
    /// </summary>
    /// <param name="repositoryId"></param>
    /// <param name="contents"></param>
    /// <param name="language"></param>
    /// <param name="ignoreFile"></param>
    /// <param name="parent"></param>
    public async Task CreateDocsRecursionAsync(long repositoryId, IReadOnlyList<RepositoryContent> contents, string language, RepositoryContent? parent, bool ignoreFile = false)
    {
        var dirs = contents.Where(c => c.Type.Equals("dir")).ToList();
        DocsCatalog? parentCatalog = null;
        if (parent != null)
        {
            parentCatalog = await _context.DocsCatalogs.FirstOrDefaultAsync(c => c.GitSha == parent.Sha);
        }
        if (dirs.Any())
        {
            var sort = 0;
            foreach (var d in dirs)
            {
                var exist = _context.DocsCatalogs.Any(c => c.GitSha == d.Sha);
                if (!exist)
                {
                    // 创建目录
                    var catalog = new DocsCatalog
                    {
                        Name = d.Name,
                        Sort = sort,
                        GitSha = d.Sha,
                        GitUrl = d.Url,
                        Language = language
                    };
                    if (parentCatalog != null)
                    {
                        catalog.Parent = parentCatalog;
                    }
                    _context.DocsCatalogs.Add(catalog);
                    sort++;

                    await _context.SaveChangesAsync();
                }

                // 获取子目录，递归调用
                var childContents = await GetFilesAsync(repositoryId, d.Path);
                await CreateDocsRecursionAsync(repositoryId, childContents, language, d);
            }
        }
        if (!ignoreFile)
        {
            var sort = 0;
            var files = contents.Where(c => c.Type.Equals("file")).ToList();

            if (files.Any())
            {
                // 库中不存在则添加
                var shas = files.Select(f => f.Sha).ToList();
                var existshas = _context.Docs.Where(d => shas.Contains(d.GitSha))
                    .Select(s => s.GitSha).ToList();
                if (existshas.Any()) { files = files.Where(f => !existshas.Contains(f.Sha)).ToList(); }
                foreach (var f in files)
                {
                    var filecontents = await Client.Repository.Content.GetAllContents(repositoryId, f.Path);
                    var file = filecontents.FirstOrDefault();
                    if (file == null) continue;
                    // 创建文件
                    var doc = new Docs
                    {
                        Name = file.Name,
                        GitUrl = file.Url,
                        GitSha = file.Sha,
                        Content = file.Content ?? file.EncodedContent,
                        Language = language,
                        Sort = sort,
                    };
                    if (parentCatalog != null)
                    {
                        doc.DocsCatalog = parentCatalog;
                    }
                    _context.Docs.Add(doc);
                    sort++;
                }
            }
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// 获取根目录文件夹,语言目录
    /// </summary>
    /// <param name="repositoryId"></param>
    protected async Task<List<RepositoryContent>> GetRepositoryRootAsync(long repositoryId)
    {
        var rootContent = await Client.Repository.Content.GetAllContents(repositoryId);
        return rootContent.Where(r => r.Type.Equals("dir")).ToList();
    }

    protected async Task<IReadOnlyList<RepositoryContent>> GetFilesAsync(long repositoryId, string path)
    {
        return await Client.Repository.Content.GetAllContents(repositoryId, path);
    }

}
