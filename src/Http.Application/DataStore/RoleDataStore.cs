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

    public Task<Role?> FindAsync(Guid id) => throw new NotImplementedException();
    public Task<List<RoleItemDto>> FindAsync(RoleFilter filter) => throw new NotImplementedException();
    public Task<PageResult<RoleItemDto>> FindWithPageAsync(RoleFilter filter) => throw new NotImplementedException();
    public Task<bool> DeleteAsync(Guid id) => throw new NotImplementedException();
    public Task<Role> AddAsync(Role form) => throw new NotImplementedException();
    public Task<Role?> UpdateAsync(Guid id, RoleUpdateDto dto) => throw new NotImplementedException();
    public Task<bool> Exist(Guid id) => throw new NotImplementedException();
    public bool Any(Func<Role, bool> predicate) => throw new NotImplementedException();
}
