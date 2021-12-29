using Http.Application.Agreement;
using Http.Application.Repositories;
using Share.Models.RoleDtos;

namespace Http.API.Controllers;

/// <summary>
/// 角色
/// </summary>
public class RoleController : ApiController<RoleRepository, Role, RoleAddDto, RoleUpdateDto, RoleFilter, RoleDto>
{
    public RoleController(
        ILogger<RoleController> logger,
        RoleRepository repository,
         IUserContext accessor) : base(logger, repository, accessor)
    {
    }

    /// <summary>
    /// 添加Role
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async override Task<ActionResult<Role>> AddAsync([FromBody] RoleAddDto form)
    {
        if (_repos._db.Any(e => e.Name == form.Name))
        {
            return Conflict();
        }
        return await _repos.AddAsync(form);
    }

    /// <summary>
    /// 分页筛选Role
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async override Task<ActionResult<PageResult<RoleDto>>> FilterAsync(RoleFilter filter)
    {
        return await _repos.GetListWithPageAsync(filter);
    }

    /// <summary>
    /// 更新Role
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async override Task<ActionResult<Role>> UpdateAsync([FromRoute] Guid id, [FromBody] RoleUpdateDto form)
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
