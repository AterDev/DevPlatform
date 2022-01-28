namespace Http.Application;

/// <summary>
///  站点维护
/// </summary>
public class WebService
{
    private ContextBase _context;
    public WebService(ContextBase context)
    {
        _context = context;
    }

    /// <summary>
    /// 初始化管理员账号
    /// </summary>
    public void InitAdminUserAccountAsync(string username, string password)
    {
    }
}
