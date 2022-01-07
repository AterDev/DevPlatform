using Http.Application.Interface;
using Http.Application.Repositories;
using Share.Models.TagLibraryDtos;

namespace Http.API.Controllers;

/// <summary>
/// TagLibrary
/// </summary>
public class TagLibraryController : ApiController<TagLibraryRepository, TagLibrary, TagLibraryAddDto, TagLibraryUpdateDto, TagLibraryFilter, TagLibraryDto>
{
    public TagLibraryController(
        ILogger<TagLibraryController> logger,
        TagLibraryRepository repository,
         IUserContext accessor) : base(logger, repository, accessor)
    {
    }

    /// <summary>
    /// 添加TagLibrary
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public async override Task<ActionResult<TagLibrary>> AddAsync([FromBody] TagLibraryAddDto form) =>
        // if (_repos.Any(e => e.Name == form.Name))
        // {
        //     return Conflict();
        // }
        await _repos.AddAsync(form);

    /// <summary>
    /// 分页筛选TagLibrary
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    [AllowAnonymous]
    public async override Task<ActionResult<PageResult<TagLibraryDto>>> FilterAsync(TagLibraryFilter filter) => await _repos.GetListWithPageAsync(filter);

    /// <summary>
    /// 更新Library
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async override Task<ActionResult<TagLibrary>> UpdateAsync([FromRoute] Guid id, [FromBody] TagLibraryUpdateDto form)
    {
        if (_repos._db.Any(e => e.Id == id))
        {
            // 名称不可以修改成其他已经存在的名称
            // if (_repos.Any(e => e.Name == form.Name && e.Id != id))
            // {
            //    return Conflict();
            // }
            return await _repos.UpdateAsync(id, form);
        }
        return NotFound();
    }
}
