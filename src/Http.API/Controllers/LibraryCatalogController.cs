using Share.Models.LibraryCatalogDtos;
namespace Http.API.Controllers;

/// <summary>
/// 目录/文件目录 / 自引用
/// </summary>
public class LibraryCatalogController : RestApiBase<LibraryCatalogDataStore, LibraryCatalog, LibraryCatalogUpdateDto, LibraryCatalogFilter, LibraryCatalogItemDto>
{
    public LibraryCatalogController(IUserContext user, ILogger<LibraryCatalogController> logger, LibraryCatalogDataStore store) : base(user, logger, store)
    {
    }

    /// <summary>
    /// 关联添加
    /// </summary>
    /// <param name="id">所属对象id</param>
    /// <param name="list">数组</param>
    /// <param name="dependStore"></param>
    /// <returns></returns>
    [HttpPost("{id}")]
    public async Task<ActionResult<int>> AddInAsync([FromRoute] Guid id, List<LibraryCatalogUpdateDto> list, [FromServices] UserDataStore dependStore)
    {
        var depend = await dependStore.FindAsync(id);
        if (depend == null) return NotFound("depend not exist");
        var newList = new List<LibraryCatalog>();
        list.ForEach(item =>
        {
            var newItem = new LibraryCatalog()
            {
                Account = depend
            };
            newList.Add(newItem.Merge(item));
        });
        return await _store.BatchAddAsync(newList);
    }
    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public override Task<ActionResult<PageResult<LibraryCatalogItemDto>>> FilterAsync(LibraryCatalogFilter filter)
    {
        return base.FilterAsync(filter);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public override Task<ActionResult<LibraryCatalog>> AddAsync(LibraryCatalog form) => base.AddAsync(form);

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    public override Task<ActionResult<LibraryCatalog?>> UpdateAsync([FromRoute] Guid id, LibraryCatalogUpdateDto form)
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
    public async override Task<ActionResult<int>> BatchDeleteAsync(List<Guid> ids)
    {
        // 危险操作，请确保该方法的执行权限
        //return base.BatchDeleteAsync(ids);
        return await Task.FromResult(0);
    }
}
