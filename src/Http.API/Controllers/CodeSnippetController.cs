using Infrastructure.Data.Models;
using Share.Agreement;
using Share.Models.CodeSnippetDtos;
using Share.Repositories;

namespace App.Api.Controllers;

/// <summary>
/// 代码片段
/// </summary>
public class CodeSnippetController : ApiController<CodeSnippetRepository, CodeSnippet, CodeSnippetAddDto, CodeSnippetUpdateDto, CodeSnippetFilter, CodeSnippetDto>
{
    public IUserContext Accessor { get; }

    public CodeSnippetController(
        ILogger<CodeSnippetController> logger,
        CodeSnippetRepository repository,
         IUserContext accessor) : base(logger, repository, accessor)
    {
        Accessor = accessor;
    }

    /// <summary>
    /// 添加CodeSnippet
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async override Task<ActionResult<CodeSnippet>> AddAsync([FromBody] CodeSnippetAddDto form)
    {
        if (_repos.Any(_usrCtx.UserId.Value, form.Name, form.CodeType, form.Language))
        {
            return Conflict();
        }
        return await _repos.AddAsync(form);
    }

    /// <summary>
    /// 分页筛选CodeSnippet
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async override Task<ActionResult<PageResult<CodeSnippetDto>>> FilterAsync(CodeSnippetFilter filter)
    {
        return await _repos.GetListWithPageAsync(filter);
    }

    /// <summary>
    /// 更新CodeSnippet
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async override Task<ActionResult<CodeSnippet>> UpdateAsync([FromRoute] Guid id, [FromBody] CodeSnippetUpdateDto form)
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

    [HttpGet("exist")]
    public ActionResult<bool> ExistAsync([FromQuery] CodeSnippetUnique dto)
    {
        return _repos.Exist(dto);
    }
}
