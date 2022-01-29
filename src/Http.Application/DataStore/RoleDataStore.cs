using Microsoft.AspNetCore.Identity;
using Share.Models.RoleDtos;

namespace Http.Application.DataStore;
public class RoleDataStore : RoleManager<Role>
{
    private readonly ContextBase _context;
    protected readonly DbSet<Role> _db;
    public IQueryable<Role> _query;
    public RoleDataStore(ContextBase context, IRoleStore<Role> store, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<Role>> logger)
        : base(store, roleValidators, keyNormalizer, errors, logger)
    {
        _context = context;
        _db = _context.Set<Role>();
        _query = _db.AsQueryable();
    }

    public async Task<Role> FindAsync(Guid id) => await FindByIdAsync(id.ToString());

    /// <summary>
    /// 筛选数据，分页结构
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public async virtual Task<PageResult<RoleItemDto>> FindWithPageAsync(RoleFilter filter)
    {
        var count = _query.Count();
        if (filter.PageIndex < 1) filter.PageIndex = 1;
        if (filter.PageSize < 0) filter.PageSize = 0;
        var data = await _query.OrderByDescending(d => d.CreatedTime)
            .Skip((filter.PageIndex - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select<Role, RoleItemDto>()
            .ToListAsync();
        return new PageResult<RoleItemDto>
        {
            Count = count,
            Data = data,
            PageIndex = filter.PageIndex
        };
    }
}
