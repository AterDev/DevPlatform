using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Http.Application.DataStore;

public class DataStore<TEntity, TUpdate, TFilter, TItem> : IDataStore<TEntity, TUpdate, TFilter, TItem>
    where TEntity : BaseDB
    where TFilter : FilterBase
{
    public readonly TContext _context;
    public readonly DbSet<TEntity> _db;
    protected readonly IQueryable<TEntity> _query;

    private ILogger _logger;
    private IUserContext _userCtx;
    public DataStore()
    {

    }

    public Task<TEntity> FindAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<TItem>> FindAsync(TFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task<PageResult<TItem>> FindWithPageAsync(TFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> AddAsync(TEntity form)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> UpdateAsync(Guid id, TUpdate dto)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> Exist(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Any(Func<TEntity, bool> predicate)
    {
        throw new NotImplementedException();
    }
}
