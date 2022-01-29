using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Share.Models.AccountDtos;

namespace Http.Application.DataStore;
public class AccountDataStore : UserManager<Account>
{
    private readonly ContextBase _context;
    protected readonly DbSet<Account> _db;
    public IQueryable<Account> _query;

    public AccountDataStore(ContextBase context, IUserStore<Account> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<Account> passwordHasher, IEnumerable<IUserValidator<Account>> userValidators, IEnumerable<IPasswordValidator<Account>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<Account>> logger)
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _context = context;
        _db = _context.Set<Account>();
        _query = _db.AsQueryable();
    }

    public async Task<Account> FindAsync(Guid id) => await FindByIdAsync(id.ToString());

    /// <summary>
    /// 筛选数据，分页结构
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public async virtual Task<PageResult<AccountItemDto>> FindWithPageAsync(AccountFilter filter)
    {
        var count = _query.Count();
        if (filter.PageIndex < 1) filter.PageIndex = 1;
        if (filter.PageSize < 0) filter.PageSize = 0;
        var data = await _query.OrderByDescending(d => d.CreatedTime)
            .Skip((filter.PageIndex - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select<Account, AccountItemDto>()
            .ToListAsync();
        return new PageResult<AccountItemDto>
        {
            Count = count,
            Data = data,
            PageIndex = filter.PageIndex
        };
    }
}
