using DocAPI.Models.DocsCatalogDtos;
namespace DocAPI.Controllers;

/// <summary>
/// 文档目录
/// </summary>
public class DocsCatalogController : RestApiBase<DocsCatalogDataStore, DocsCatalog, DocsCatalogUpdateDto, DocsCatalogFilter, DocsCatalogItemDto>
{
    public DocsCatalogController(IUserContext user, ILogger<DocsCatalogController> logger, DocsCatalogDataStore store) : base(user, logger, store)
    {
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public override Task<ActionResult<PageResult<DocsCatalogItemDto>>> FilterAsync(DocsCatalogFilter filter)
    {
        return base.FilterAsync(filter);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public override Task<ActionResult<DocsCatalog>> AddAsync(DocsCatalog form) => base.AddAsync(form);


    /// <summary>
    /// 添加文档目录
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost("add")]
    public async Task<ActionResult<DocsCatalog>> AddInAsync([FromBody] DocsCatalogAddDto form)
    {
        if (form.ParentId == null)
        {
            var docsCatalog = new DocsCatalog();
            docsCatalog.Merge(form);
            await base.AddAsync(docsCatalog);
            return docsCatalog;
        }
        else
        {
            var parent = await _store.FindAsync(form.ParentId.Value);
            if (parent == null) return NotFound();

            var docsCatalog = new DocsCatalog();
            docsCatalog.Merge(form);
            docsCatalog.Parent = parent;
            await base.AddAsync(docsCatalog);
            return docsCatalog;
        }
    }

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    public override Task<ActionResult<DocsCatalog?>> UpdateAsync([FromRoute] Guid id, DocsCatalogUpdateDto form)
        => base.UpdateAsync(id, form);

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public override Task<ActionResult<bool>> DeleteAsync([FromRoute] Guid id)
    {
        return base.DeleteAsync(id);
    }

    /// <summary>
    /// ⚠ 批量删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public override async Task<ActionResult<int>> BatchDeleteAsync(List<Guid> ids)
    {
        // 危险操作，请确保该方法的执行权限
        //return base.BatchDeleteAsync(ids);
        return await Task.FromResult(0);
    }
}
