using AutoMapper;
using GT.Agreement;
using GT.Agreement.Models;
using Core.Entity;
using Core.Services.Models;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using GT.Agreement.Utils;
using System;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.Repositories
{
    public class AccountRepository : Repository<Account, AccountAddDto, AccountUpdateDto, AccountFilter, AccountDto>
    {

        EmailService _email;
        public AccountRepository(CoreContext context, IMapper mapper, EmailService email) : base(context, mapper)
        {
            _email = email;
        }

        public override Task<PageResult<AccountDto>> GetListWithPageAsync(AccountFilter filter)
        {
            _query = _query.OrderByDescending(q => q.CreatedTime);
            return base.GetListWithPageAsync(filter);
        }

        /// <summary>
        /// ÃÌº”’À∫≈≤¢—È÷§” œ‰
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>

        public override async Task<Account> AddAsync(AccountAddDto form)
        {
            var salt = HashCrypto.BuildSalt();
            var account = _mapper.Map<Account>(form);
            account.HashSalt = salt;
            account.Password = HashCrypto.Create(form.Password, salt);
            account.EmailConfirm = false;

            await _context.AddAsync(account);
            await _context.SaveChangesAsync();
            await _email.SendRegisterMailAsync(account.Email, account.Id.ToString());
            return account;
        }

        /// <summary>
        /// —È÷§” œ‰
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<bool> VerifyEmailAsync(Account account)
        {
            _context.Update(account);
            return await _context.SaveChangesAsync() == 1;
        }

        /// <summary>
        /// –ﬁ∏ƒ√‹¬Î
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AccountDto> ChangePassword(Guid id, ChangePasswordDto dto)
        {
            var account = await _db.FindAsync(id);
            if (HashCrypto.Validate(dto.Password, account.HashSalt, account.Password))
            {
                var salt = HashCrypto.BuildSalt();
                account.HashSalt = salt;
                account.Password = HashCrypto.Create(dto.NewPassword, salt);
                await _context.SaveChangesAsync();
                return _mapper.Map<AccountDto>(account);
            }
            return default;
        }

        /// <summary>
        /// µ«¬º
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AccountDto SignUpUser(UserSignUpDto dto)
        {
            var user = _db.Where(u => u.Email == dto.Username
                || u.Username == dto.Username)
                .Include(u => u.Roles)
                .FirstOrDefault();
            if (user == null) return default;
            if (HashCrypto.Validate(dto.Password, user.HashSalt, user.Password))
            {
                return _mapper.Map<AccountDto>(user);
            }
            return default;
        }

    }
}
