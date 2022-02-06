using System.Linq;
using Core.Utils;
using Microsoft.OData.Edm;
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

    public async Task<User?> FindAsync(Guid id) => await _db.FindAsync(id);
    public async Task<List<UserItemDto>> FindAsync(UserFilter filter)
    {
        return await _query.OrderByDescending(d => d.CreatedTime)
          .Select<User, UserItemDto>()
          .Skip((filter.PageIndex - 1) * filter.PageSize)
          .Take(filter.PageSize)
          .ToListAsync();
    }
    public async Task<PageResult<UserItemDto>> FindWithPageAsync(UserFilter filter)
    {
        var count = _query.Count();
        if (filter.PageIndex < 1) filter.PageIndex = 1;
        if (filter.PageSize < 0) filter.PageSize = 0;
        var data = await _query.OrderByDescending(d => d.CreatedTime)
            .Skip((filter.PageIndex - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select<User, UserItemDto>()
            .ToListAsync();
        return new PageResult<UserItemDto>
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
    public async Task<User> AddAsync(User data) {
        _db.Add(data);
        await _context.SaveChangesAsync();
        return data;
    }
    public async Task<User?> UpdateAsync(Guid id, UserUpdateDto dto) {
        var data = await _db.FindAsync(id);
        if (data == null) { return null; }
        // merge data and save 
        data.Merge(dto);
        await _context.SaveChangesAsync();
        return data;
    }
    public async Task<bool> Exist(Guid id) {
        var data = await _db.FindAsync(id);
        return data != null;
    }
    public bool Any(Func<User, bool> predicate) => _db.Any(predicate);
}
