using Share.Models.RoleDtos;

namespace Http.Application.DataStore;

public class RoleDataStore : IDataStore<Role, RoleUpdateDto, RoleFilter, RoleItemDto>
{
    private readonly ContextBase _context;
    public readonly ILogger<RoleDataStore> _logger;
    protected readonly DbSet<Role> _db;
    public IQueryable<Role> _query;

    public RoleDataStore(ContextBase context, ILogger<RoleDataStore> logger)
    {
        _context = context;
        _logger = logger;
        _db = _context.Set<Role>();
        _query = _db.AsQueryable();
    }

    public async Task<Role?> FindAsync(Guid id) => await _db.FindAsync(id);
    public async Task<List<RoleItemDto>> FindAsync(RoleFilter filter)
    {
        return await _query.OrderByDescending(d => d.CreatedTime)
          .Select<Role, RoleItemDto>()
          .Skip((filter.PageIndex - 1) * filter.PageSize)
          .Take(filter.PageSize)
          .ToListAsync();
    }
    public async Task<PageResult<RoleItemDto>> FindWithPageAsync(RoleFilter filter)
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
    public async Task<bool> DeleteAsync(Guid id)
    {
        var data = await _db.FindAsync(id);
        if (data == null) { return false; }
        _db.Remove(data);
        return (await _context.SaveChangesAsync() > 0);
    }
    public async Task<Role> AddAsync(Role data)
    {
        _db.Add(data);
        await _context.SaveChangesAsync();
        return data;
    }
    public async Task<Role?> UpdateAsync(Guid id, RoleUpdateDto dto)
    {
        var data = await _db.FindAsync(id);
        if (data == null) { return null; }
        // merge data and save 
        data.Merge(dto);
        await _context.SaveChangesAsync();
        return data;
    }
    public async Task<bool> Exist(Guid id)
    {
        var data = await _db.FindAsync(id);
        return data != null;
    }
    public bool Any(Func<Role, bool> predicate) => _db.Any(predicate);
}
