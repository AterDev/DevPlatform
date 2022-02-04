using Share.Models.UserDtos;

namespace Http.Application.DataStore;
public class UserDataStore : IDataStore<User, UserUpdateDto, UserFilter, UserItemDto>
{
    private readonly ContextBase _context;
    public readonly ILogger<UserDataStore> _logger;
    protected readonly DbSet<User> _db;
    public IQueryable<User> _query;

    public UserDataStore(ContextBase context, ILogger<UserDataStore> logger)
    {
        _context = context;
        _logger = logger;
        _db = _context.Set<User>();
        _query = _db.AsQueryable();
    }

    public Task<User?> FindAsync(Guid id) => throw new NotImplementedException();
    public Task<List<UserItemDto>> FindAsync(UserFilter filter) => throw new NotImplementedException();
    public Task<PageResult<UserItemDto>> FindWithPageAsync(UserFilter filter) => throw new NotImplementedException();
    public Task<bool> DeleteAsync(Guid id) => throw new NotImplementedException();
    public Task<User> AddAsync(User form) => throw new NotImplementedException();
    public Task<User?> UpdateAsync(Guid id, UserUpdateDto dto) => throw new NotImplementedException();
    public Task<bool> Exist(Guid id) => throw new NotImplementedException();
    public bool Any(Func<User, bool> predicate) => throw new NotImplementedException();
}
