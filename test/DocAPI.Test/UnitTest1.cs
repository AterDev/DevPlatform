using DocAPI.Services;

namespace DocAPI.Test;

public class UnitTest1
{
    private readonly DocsSyncServices _syncService;
    private readonly DocsContext _context;
    public UnitTest1()
    {
        _syncService = DI.GetService<DocsSyncServices>();
        _context = DI.GetService<DocsContext>();
    }



    [Fact]
    public async Task ShoudSyncDocs()
    {
        var pat = "";
        await _syncService.SetPATAsync(pat);
        var repos = await _syncService.GetPublicRepositories();
        var docRepos = repos.Where(r => r.Name.Equals("ater.docs")).FirstOrDefault();

        Assert.NotNull(docRepos);

        if (docRepos != null)
            await _syncService.SyncDocsAsync(docRepos.Id);

    }
}