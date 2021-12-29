using Http.Application.Repositories;

namespace Http.API.Agreement;

[ApiController]
[Route("api/[controller]")]
public class ApiControllerBase<TContext, TRepository, TEntity, TAddForm, TUpdateForm, TFilter, TDto>
    : ApiServiceBase, IApiControllerBase<TEntity, TAddForm, TUpdateForm, TFilter, TDto, Guid>
    where TRepository : Repository<TEntity, TAddForm, TUpdateForm, TFilter, TDto>
    where TContext : DbContext
    where TFilter : FilterBase
    where TEntity : BaseDB
{
    protected ILogger _logger;
    protected TRepository _repos;

    public ApiControllerBase(ILogger logger, TRepository repos)
    {
        _repos = repos;
        _logger = logger;
    }

    [HttpPost]
    public async virtual Task<ActionResult<TEntity>> AddAsync(TAddForm form)
    {
        return await _repos.AddAsync(form);
    }

    [HttpDelete("{id}")]
    public async virtual Task<ActionResult<TEntity>> DeleteAsync([FromRoute] Guid id)
    {
        if (_repos._db.Any(d => d.Id == id))
        {
            return await _repos.DeleteAsync(id);
        }
        return NotFound();
    }

    [HttpPost("filter")]
    public async virtual Task<ActionResult<PageResult<TDto>>> FilterAsync(TFilter filter)
    {
        return await _repos.GetListWithPageAsync(filter);
    }

    [HttpGet("{id}")]
    public async virtual Task<ActionResult<TEntity>> GetDetailAsync([FromRoute] Guid id)
    {
        return await _repos.GetDetailAsync(id);
    }

    [HttpPut("{id}")]
    public async virtual Task<ActionResult<TEntity>> UpdateAsync([FromRoute] Guid id, TUpdateForm form)
    {
        if (_repos._db.Any(d => d.Id == id))
        {
            return await _repos.UpdateAsync(id, form);
        }
        return NotFound();
    }
}
