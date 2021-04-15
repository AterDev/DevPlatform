using AutoMapper;
using Core.Agreement;
using Share.Models;
using Core.Entity;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;

namespace Core.Services.Repositories
{
    public class AccountRepository : Repository<Account, AccountAddDto, AccountUpdateDto, AccountFilter, AccountDto>
    {
        public AccountRepository(ContextBase context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Task<PageResult<AccountDto>> GetListWithPageAsync(AccountFilter filter)
        {
            _query = _query.OrderByDescending(q => q.CreatedTime);
            return base.GetListWithPageAsync(filter);
        }
    }
}
