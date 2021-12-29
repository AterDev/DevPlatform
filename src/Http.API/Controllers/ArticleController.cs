using Http.Application.Agreement;
using Http.Application.Repositories;
using Share.Models.ArticleDtos;

namespace Http.API.Controllers;

/// <summary>
/// 文章
/// </summary>
public class ArticleController : ApiController<ArticleRepository, Article, ArticleAddDto, ArticleUpdateDto, ArticleFilter, ArticleDto>
{

    FileService _fileService;
    public ArticleController(
        ILogger<ArticleController> logger,
        ArticleRepository repository,
        IUserContext userContext,
        FileService fileService
        ) : base(logger, repository, userContext)
    {
        _fileService = fileService;
    }

    /// <summary>
    /// 添加Article
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async override Task<ActionResult<Article>> AddAsync([FromBody] ArticleAddDto form)
    {
        if (_repos.Any(e => e.Title == form.Title
            && e.AccountId == _usrCtx.UserId))
        {
            return Conflict();
        }
        if (!_repos.ValidAccount())
        {
            return Forbid();
        }
        // 上录是否合法
        if (form.CatalogId.HasValue)
        {
            var catalog = _repos.ValidCatalog(form.CatalogId.Value);
            if (!catalog)
            {
                return NotFound("未找到相应的目录");
            }
        }
        return await _repos.AddAsync(form);
    }

    /// <summary>
    /// 分页筛选Article
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async override Task<ActionResult<PageResult<ArticleDto>>> FilterAsync(ArticleFilter filter)
    {
        return await _repos.GetListWithPageAsync(filter);
    }

    /// <summary>
    /// 更新Article
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async override Task<ActionResult<Article>> UpdateAsync([FromRoute] Guid id, [FromBody] ArticleUpdateDto form)
    {
        if (_repos._db.Any(e => e.Id == id))
        {
            // 名称不可以修改成其他已经存在的名称
            if (_repos._db.Any(e => e.Title == form.Title && e.Id != id))
            {
                return Conflict();
            }
            if (!_repos.ValidAccount())
            {
                return Forbid();
            }
            return await _repos.UpdateAsync(id, form);
        }
        return NotFound();
    }


    /// <summary>
    /// 删除Article
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async override Task<ActionResult<Article>> DeleteAsync([FromRoute] Guid id)
    {
        if (!_repos.ValidAccount())
        {
            return Forbid();
        }
        return await base.DeleteAsync(id);
    }

    /// <summary>
    /// 获取Article详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async override Task<ActionResult<Article>> GetDetailAsync([FromRoute] Guid id)
    {
        return await base.GetDetailAsync(id);
    }


    /// <summary>
    /// 文本编辑器上传文件
    /// </summary>
    /// <param name="upload"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    [RequestSizeLimit(10_000_000)]
    [HttpPost("UploadEditorFile")]
    public async Task<IActionResult> UploadEditorFile(IFormFile upload, string type = "editor")
    {
        var dirPath = type;
        var filePath = Path.GetTempFileName();
        var url = "";
        var localPath = "";
        if (upload.Length > 0)
        {
            using var stream = new MemoryStream();
            await upload.CopyToAsync(stream);
            var fileExt = upload.FileName.Split(".").LastOrDefault();
            var fileName = Path.GetFileName(HashCrypto.Md5Hash(DateTime.Now.ToString()) + $".{fileExt ?? "png"}");
            // 保存到本地
            localPath = Path.Combine(dirPath, fileName);
            _fileService.SaveFile(localPath, stream);
            // 删除临时文件
            System.IO.File.Delete(filePath);

            // 拼成本地host链接
            var myHostUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            url = $@" {myHostUrl}/Uploads/{localPath}";
        }
        return Ok(new
        {
            Url = url,
            LocalUrl = url
        });
    }
}
