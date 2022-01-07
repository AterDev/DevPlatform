﻿namespace Http.Application.DataStore;

public class DataStore<TContext, TEntity, TUpdate, TFilter, TItem> : IDataStore<TEntity, TUpdate, TFilter, TItem>
    where TEntity : BaseDB
    where TFilter : FilterBase
    where TContext : DbContext
    where TItem : class
{
    protected readonly TContext _context;
    protected readonly DbSet<TEntity> _db;
    protected readonly IQueryable<TEntity> _query;
    protected readonly ILogger _logger;
    protected readonly IUserContext _userCtx;

    public DataStore(TContext context, IUserContext userContext, ILogger logger)
    {
        _context = context;
        _userCtx = userContext;
        _logger = logger;
        _db = _context.Set<TEntity>();
        _query = _db.AsQueryable();
    }

    /// <summary>
    /// 获取一条数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TEntity?> FindAsync(Guid id) => await _db.FindAsync();

    /// <summary>
    /// 筛选数据
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public async Task<List<TItem>> FindAsync(TFilter filter)
    {
        return await _query.OrderByDescending(d => d.CreatedTime)
            .Select<TEntity, TItem>()
            .Skip((filter.PageIndex - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();
    }

    /// <summary>
    /// 筛选数据，分页结构
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public async Task<PageResult<TItem>> FindWithPageAsync(TFilter filter)
    {
        var count = _query.Count();
        if (filter.PageIndex < 1) filter.PageIndex = 1;
        if (filter.PageSize < 0) filter.PageSize = 0;
        var data = await _query.Skip((filter.PageIndex - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select<TEntity, TItem>()
            .ToListAsync();
        return new PageResult<TItem>
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

    public async Task<TEntity> AddAsync(TEntity data)
    {
        _db.Add(data);
        await _context.SaveChangesAsync();
        return data;
    }

    public async Task<TEntity?> UpdateAsync(Guid id, TUpdate dto)
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

    public bool Any(Func<TEntity, bool> predicate) => _db.Any(predicate);
}
