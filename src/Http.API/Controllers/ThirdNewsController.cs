using Http.Application.Interface;
using Http.Application.Repositories;
using Share.Models.TagLibraryDtos;
using Share.Models.ThirdNewsDtos;

namespace Http.API.Controllers;

/// <summary>
/// ThirdNews
/// </summary>
public class ThirdNewsController : ApiController<ThirdNewsRepository, ThirdNews, ThirdNewsAddDto, ThirdNewsUpdateDto, ThirdNewsFilter, ThirdNewsDto>
{
    public ThirdNewsController(
        ILogger<ThirdNewsController> logger,
        ThirdNewsRepository repository, IUserContext userContext) : base(logger, repository, userContext)
    {
    }

    /// <summary>
    /// 添加ThirdNews
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async override Task<ActionResult<ThirdNews>> AddAsync([FromBody] ThirdNewsAddDto form)
    {
        // if (_repos.Any(e => e.Name == form.Name))
        // {
        //     return Conflict();
        // }
        return await _repos.AddAsync(form);
    }

    /// <summary>
    /// Get Latest week news
    /// </summary>
    /// <returns></returns>
    [HttpGet("week")]
    [AllowAnonymous]
    public async Task<List<ThirdNews>> GetWeekNewsAsync()
    {
        return await _repos.GetWeekNewsAsync();
    }

    /// <summary>
    /// 添加标签
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tags"></param>
    /// <returns></returns>
    [HttpPost("tags/{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<ThirdNews>> AddTags([FromRoute] Guid id, [FromBody] List<NewsTagsAddDto> tags)
    {
        var newsTag = await _repos._db.FindAsync(id);
        if (newsTag == null)
        {
            return NotFound();
        }
        return await _repos.AddTags(id, tags);
    }

    /// <summary>
    /// 删除标签
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("tags/{id}")]
    [AllowAnonymous]
    public async Task<int> DeleteTagAsync([FromRoute] Guid id)
    {
        return await _repos.DeleteTag(id);
    }

    /// <summary>
    /// 分页筛选ThirdNews
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    [AllowAnonymous]
    public async override Task<ActionResult<PageResult<ThirdNewsDto>>> FilterAsync(ThirdNewsFilter filter)
    {
        return await _repos.GetListWithPageAsync(filter);
    }

    /// <summary>
    /// 更新ThirdNews
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async override Task<ActionResult<ThirdNews>> UpdateAsync([FromRoute] Guid id, [FromBody] ThirdNewsUpdateDto form)
    {
        if (_repos.Any(e => e.Id == id))
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


    /// <summary>
    /// 删除ThirdNews
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async override Task<ActionResult<ThirdNews>> DeleteAsync([FromRoute] Guid id)
    {
        return await _repos.DeleteAsync(id);
    }

    /// <summary>
    /// 获取ThirdNews详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public override Task<ActionResult<ThirdNews>> GetDetailAsync([FromRoute] Guid id)
    {
        return base.GetDetailAsync(id);
    }

    /// <summary>
    /// 资讯分类处理
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="newsType"></param>
    /// <returns></returns>
    [HttpPut("type")]
    [AllowAnonymous]
    public async Task<int> SetNewsTypeAsync([FromBody] List<Guid> ids, [FromQuery] TechType newsType)
    {
        return await _repos.SetNewsTypeAsync(ids, newsType);
    }

    /// <summary>
    /// set news as deleted
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    [HttpPut("deleted")]
    [AllowAnonymous]
    public async Task<int> RemoveAsync([FromBody] List<Guid> ids)
    {
        return await _repos.RemoveAsync(ids);
    }
}
