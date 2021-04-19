using AutoMapper;
using Core.Agreement;
using Share.Models;
using Core.Entity;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Share.Models.Common;
using System;
using Share.Utils;
using Microsoft.EntityFrameworkCore;

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


        /// <summary>
        /// Ìí¼ÓÕËºÅ
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sendEmail"></param>
        /// <returns></returns>
        public async Task<Account> AddAsync(AccountAddDto form, bool sendEmail = true)
        {
            var salt = HashCrypto.BuildSalt();
            var account = _mapper.Map<Account>(form);
            account.HashSalt = salt;
            account.Password = HashCrypto.Create(form.Password, salt);
            account.EmailConfirm = false;
            await _context.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

        /// <summary>
        /// µÇÂ¼
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AccountDetailDto SignIn(SignInForm dto)
        {
            var user = _db.Where(u => u.Email.Equals(dto.Username)
                || u.Username.Equals(dto.Username))
                .FirstOrDefault();
            if (user == null) return default;
            if (HashCrypto.Validate(dto.Password, user.HashSalt, user.Password))
            {
                return _mapper.Map<AccountDetailDto>(user);
            }
            return default;
        }
    }
}
