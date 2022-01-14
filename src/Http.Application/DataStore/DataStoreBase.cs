﻿namespace Http.Application.DataStore;

public class DataStoreBase<TContext, TEntity, TUpdate, TFilter, TItem> : IDataStore<TEntity, TUpdate, TFilter, TItem, Guid>
    where TEntity : BaseDB
    where TFilter : FilterBase
    where TContext : DbContext
    where TItem : class
{
    public readonly TContext _context;
    public readonly IQueryable<TEntity> _query;
    public readonly ILogger _logger;
    protected readonly DbSet<TEntity> _db;
    protected readonly IUserContext _userCtx;
    public DbSet<TEntity> Db { get => _db; }

    public DataStoreBase(TContext context, IUserContext userContext, ILogger logger)
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
    public async Task<TEntity?> FindAsync(Guid id) => await _db.FindAsync(id);

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

    /// <summary>
    /// 批量更新
    /// </summary>
    /// <returns></returns>
    public async Task<int> BatchUpdateAsync(List<Guid> ids, TUpdate dto)
    {
        try
        {
            var data = _db.Where(item => ids.Contains(item.Id))
                .ToList();
            foreach (var item in data)
            {
                item.Merge(dto);
            }
            return await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    /// <summary>
    /// 批量删除
    /// </summary>
    /// <returns></returns>
    public async Task<int> BatchDeleteAsync(List<Guid> ids)
    {
        try
        {
            var data = _db.Where(item => ids.Contains(item.Id))
                .ToList();
            _context.RemoveRange(data);
            return await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> BatchAddAsync(List<TEntity> entities)
    {
        await _db.AddRangeAsync(entities);
        return await _context.SaveChangesAsync();
    }
}
