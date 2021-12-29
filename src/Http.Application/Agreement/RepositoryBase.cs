namespace Http.Application.Agreement;

/// <summary>
/// 基础curd操作实现
/// </summary>
/// <typeparam name="TContext"></typeparam>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TFilter"></typeparam>
/// <typeparam name="TUpdateForm"></typeparam>
/// <typeparam name="TAddForm"></typeparam>
/// <typeparam name="TData"></typeparam> 
/// <typeparam name="TKey"></typeparam>
public class RepositoryBase<TContext, TEntity, TAddForm, TUpdateForm, TFilter, TData, TKey>
    : RepositoryBase,
    IRepositoryBase<TEntity, TAddForm, TUpdateForm, TFilter, TData, TKey>
    where TContext : DbContext
    where TEntity : class
    where TFilter : class
{
    public TContext _context;
    public DbSet<TEntity> _db;
    protected IQueryable<TEntity> _query;

    public RepositoryBase(TContext context, IMapper mapper, IUserContext userContext) : base(mapper, userContext)
    {
        _context = context;
        _db = _context.Set<TEntity>();
        _query = _db.AsQueryable();
    }

    /// <summary>
    /// 默认添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public async virtual Task<TEntity> AddAsync(TAddForm form)
    {
        var data = _mapper.Map<TAddForm, TEntity>(form);
        _db.Add(data);
        await _context.SaveChangesAsync();
        return data;
    }

    /// <summary>
    /// 删除，有关联的重写该方法
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async virtual Task<TEntity> DeleteAsync(TKey id)
    {
        var data = await _db.FindAsync(id);
        _db.Remove(data);
        await _context.SaveChangesAsync();
        return data;
    }

    /// <summary>
    /// 默认以id判断
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public async virtual Task<TEntity> Exist(object o)
    {
        var pi = o.GetType().GetProperty("Id");
        var id = (Guid)pi.GetValue(o, null);
        var exist = await _db.FindAsync(id);
        return exist;
    }

    public async virtual Task<TEntity> GetDetailAsync(TKey id)
    {
        var data = await _db.FindAsync(id);
        return data;
    }

    public virtual Task<List<TData>> GetListAsync(TFilter filter)
    {
        throw new NotImplementedException();
    }

    public virtual Task<PageResult<TData>> GetListWithPageAsync(TFilter filter)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 仅更新实体
    /// </summary>
    /// <param name="id"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public async virtual Task<TEntity> UpdateAsync(TKey id, TUpdateForm data)
    {
        var currentData = await _db.FindAsync(id);
        _context.Entry(currentData).CurrentValues.SetValues(data);
        await _context.SaveChangesAsync();
        return currentData;
    }

    public virtual bool Any(Func<TEntity, bool> predicate)
    {
        return _db.Any(predicate);
    }
}

public class RepositoryBase
{
    protected IUserContext _usrCtx;
    protected IMapper _mapper;
    public RepositoryBase(IMapper mapper, IUserContext userContext)
    {
        _mapper = mapper;
        _usrCtx = userContext;
    }
}
